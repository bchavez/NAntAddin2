//////////////////////////////////////////////////////////////////////////
//
// Copyright © 2010 Netlogics Sarl
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
//////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.IO;

namespace NAntAddin
{
    //////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Create an instance of XmlTree from a file
    /// </summary>
    //////////////////////////////////////////////////////////////////////////

    internal static class XmlTreeFactory
    {
        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Build a XmlTree from a xml NAnt script file.
        /// </summary>
        /// <param name="filename">Xml fileName.</param>
        /// <param name="showInclude">Add include file in tree.</param>
        /// <returns>XmlTree for the script file.</returns>
        //////////////////////////////////////////////////////////////////////////

        internal static XmlTree CreateXmlTree(string filename, bool showInclude)
        {
            XmlTree nodeTree = null;

            try
            {
                // Parse the file
                XmlNode rootNode = ParseXmlFile(filename);

                // Create the tree from the root node
                if (rootNode != null)
                {
                    nodeTree = new XmlTree(rootNode);

                    // Insert include script in the three
                    if (showInclude)
                    {
                        // Folder of the script to resolve include
                        string folder = Path.GetDirectoryName(filename);
                        ParseIncludeFiles(folder, nodeTree);
                    }
                }
            }
            catch
            {
                // The exception has to be catched by the caller
                throw;
            }

            return nodeTree;
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Parse the script file.
        /// </summary>
        /// <param name="filename">Script file to parse.</param>
        /// <returns>The XmlNode of the script.</returns>
        //////////////////////////////////////////////////////////////////////////

        public static XmlNode ParseXmlFile(string filename)
        {
            XmlNode rootNode = null;
            XmlNode currentNode = null;

            Stack<XmlNode> nodes = new Stack<XmlNode>();

            // Reader of xml node
            XmlTextReader xmlReader = new XmlTextReader(filename);

            // Read to end of file
            while (!xmlReader.EOF)
            {
                // Consume node
                xmlReader.Read();

                switch (xmlReader.NodeType)
                {
                    // ==> Node content
                    case XmlNodeType.Element:

                        // Create a new node with parsing information
                        currentNode = new XmlNode(xmlReader.LocalName.ToLower(), xmlReader.Value, xmlReader.LineNumber);

                        // First node read : initialize root 
                        if (nodes.Count == 0)
                        {
                            rootNode = currentNode;
                            nodes.Push(rootNode);
                        }
                        else
                        {
                            // Add current node to its parent
                            XmlNode parent = nodes.Peek();
                            parent.Add(currentNode);

                            // Don't push empty nodes onto the stack
                            if (!xmlReader.IsEmptyElement)
                                nodes.Push(currentNode);
                        }

                        // Add attribute to current node
                        if (xmlReader.HasAttributes)
                        {
                            while (xmlReader.MoveToNextAttribute())
                            {
                                currentNode.Add(xmlReader.Name, xmlReader.Value);
                            }
                        }
                        break;

                    // ==> End tag
                    case XmlNodeType.EndElement:

                        // Pop the top node 
                        nodes.Pop();
                        break;

                    // Other tags
                    default:
                        // Ignored
                        break;
                }
            }

            // Update root node
            rootNode.Add("file", filename);

            return rootNode;
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Insert script tree from include file in a XmlTree.
        /// </summary>
        /// <param name="folder">Folder base of the includer file.</param>
        /// <param name="tree">XmlTree to be updated.</param>
        //////////////////////////////////////////////////////////////////////////

        private static void ParseIncludeFiles(string folder, XmlTree tree)
        {
            foreach (XmlNode include in tree.Includes)
            {
                // Path of included file
                string includedPath = "";

                try
                {
                    // Try to combine the folder base and include path
                    includedPath = Path.Combine(folder, include[AppConstants.NANT_XML_BUILDFILE]);
                }
                catch
                {
                }

                // Build tree from file
                XmlTree subTree = XmlTreeFactory.CreateXmlTree(includedPath.ToString(), true);

                // Add to the main tree
                tree.Root.Add(subTree.Root.Children);
            }
        }
    }
}
