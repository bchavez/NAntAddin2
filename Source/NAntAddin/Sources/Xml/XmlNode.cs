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
using System.ComponentModel;
using System.Text;

namespace NAntAddin
{
    //////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Implementation of XmlNode.
    /// </summary>
    /// <seealso cref="NAntNode"/>
    //////////////////////////////////////////////////////////////////////////

    public class XmlNode
    {
        // Private attributes
        private string m_Name;
        private string m_Text;
        private int    m_LineNumber;
        private IDictionary<string, string> m_Attributes;
        private IList<XmlNode> m_Children;

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Initialization of a node.
        /// </summary>
        /// <param name="name">Name of a XML node.</param>
        /// <param name="text">Text of a XML node.</param>
        /// <param name="lineNumber">Start line number of a XML node.</param>
        //////////////////////////////////////////////////////////////////////////

        internal XmlNode(string name, string text, int lineNumber)
        {
            m_Name  = name;
            m_Text  = text;
            m_LineNumber  = lineNumber;
            m_Attributes = new Dictionary<string, string>();
            m_Children   = new List<XmlNode>();
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Get the name.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public string Name
        {
            get { return m_Name; }
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Get the text.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public string Text
        {
            get { return m_Text; }
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Get the line.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public int LineNumber
        {
            get { return m_LineNumber; }
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Get the list of children.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public IList<XmlNode> Children
        {
            get { return m_Children; }
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Get the list of attribute name.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public ICollection<string> Attributes
        {
            get { return m_Attributes.Keys; }
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Return a type descriptor associated to current node
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public ICustomTypeDescriptor Descriptor
        {
            get { return new XmlDescriptor(this); }
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Get the value of an attribute.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        //////////////////////////////////////////////////////////////////////////

        public string this[string attributeName]
        {
            get
            {
                if (m_Attributes.ContainsKey(attributeName))
                    return m_Attributes[attributeName];
                return null;
            }
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Add an attribute.
        /// </summary>
        /// <param name="key">The name of the attribute to add.</param>
        /// <param name="value">The value of the attribute to add.</param>
        //////////////////////////////////////////////////////////////////////////

        public void Add(string key, string value)
        {
            m_Attributes.Add(key, value);
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
	    /// Add a child node.
	    /// </summary>
	    /// <param name="child">The child to add.</param>
        //////////////////////////////////////////////////////////////////////////

        public void Add(XmlNode child)
        {
            m_Children.Add(child);            
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Add a list of children node.
        /// </summary>
        /// <param name="nodeList">The list of chidren to add.</param>
        //////////////////////////////////////////////////////////////////////////

        public void Add(IList<XmlNode> nodeList)
        {
            if (nodeList != null)
            {
                foreach (XmlNode node in nodeList)
                    this.Add(node);
            }
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Determines whether the node has the specified attribute.
        /// </summary>
        /// <param name="attributeName">The attribute name to check.</param>
        /// <returns>Returns true if the attribute exists and false if not.</returns>
        //////////////////////////////////////////////////////////////////////////

        public bool HasAttribute(string attributeName)
        {
            return this[attributeName] != null;
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Pretty print output of a node.
        /// </summary>
        /// <returns>The pretty print string.</returns>
        //////////////////////////////////////////////////////////////////////////

        public override string ToString()
        {
            return ToStringRecursive(0);
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Internal method to indent the output of ToString.
        /// </summary>
        /// <param name="level">The level of indentation.</param>
        /// <returns>The print string of a node.</returns>
        //////////////////////////////////////////////////////////////////////////

        public string ToStringRecursive(int level)
        {
            StringBuilder stringBuilder = new StringBuilder();

            // Indent
            for (int i = 0; i < level; i++)
                stringBuilder.Append("   ");

            // Name of node
            stringBuilder.Append(Name);

            // List of attributes if any
            if (m_Attributes != null)
            {
                ICollection<string> keys = m_Attributes.Keys;
                foreach (string key in keys)
                {
                    // Attribute name
                    stringBuilder.Append(" ");
                    stringBuilder.Append(key);

                    // Attribute value
                    stringBuilder.Append("=");
                    stringBuilder.Append(m_Attributes[key]);
                }
            }

            stringBuilder.Append("\n");

            // List of children if any
            if (m_Children != null)
            {
                // Recursively append each child
                foreach (XmlNode child in m_Children)
                    stringBuilder.Append(child.ToStringRecursive(level + 1));
            }

            return stringBuilder.ToString();
        }
    }
}
