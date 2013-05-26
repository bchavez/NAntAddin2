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
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;

namespace NAntAddin
{
    //////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Implementation of XmlTree which represents and tree of XmlNode
    /// </summary>
    //////////////////////////////////////////////////////////////////////////

    public class XmlTree
    {
        // Private attributes
        private XmlNode m_RootNode;
        private delegate bool Filter(XmlNode node);

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Initialize the tree with a root node.
        /// </summary>
        /// <param name="rootNode">The root.</param>
        //////////////////////////////////////////////////////////////////////////

        internal XmlTree(XmlNode rootNode)
        {
            m_RootNode = rootNode;
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Return the root of the NAnt script : represents the project.
        /// </summary>
        /// <returns>The root node</returns>
        //////////////////////////////////////////////////////////////////////////

        public XmlNode Root
        {
            get { return m_RootNode; }
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Filter the list of XmlNode subnode by a criteria.
        /// </summary>
        /// <param name="filter">A delegate that takes an XmlNode and return a bool.</param>
        /// <returns>The filtered list</returns>
        //////////////////////////////////////////////////////////////////////////

        private IList<XmlNode> ListFilter(Filter filter) 
        {
            List<XmlNode> result = new List<XmlNode>();

            // If project has not children
            if (this.Root.Children == null)
                return result;

            // Filter children with filter passed in argument
            foreach (XmlNode node in this.Root.Children)
            {
                // If the node match the filter cryteria
                // we add it to the list
                if (filter(node))
                    result.Add(node);
            }

            return result;
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Get the list of nodes that are include.
        /// </summary>
        /// <seealso cref="XmlNode"/>
        //////////////////////////////////////////////////////////////////////////

        public IList<XmlNode> Includes
        {
            get
            {
                return ListFilter(
                    new Filter(
                        delegate(XmlNode node) { return node.Name == AppConstants.NANT_XML_INCLUDE; }
                    )
                );
            }
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Get the list of nodes that are not target nor include.
        /// </summary>
        /// <seealso cref="XmlNode"/>
        //////////////////////////////////////////////////////////////////////////

        public IList<XmlNode> Properties
        {
            get
            {
                return ListFilter(
                    new Filter(
                        delegate(XmlNode node) { 
                            return node.Name != AppConstants.NANT_XML_TARGET
                            && node.Name != AppConstants.NANT_XML_INCLUDE;
                        }
                    )
                );
            }
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Get the list of nodes that are target with a description.
        /// </summary>
        /// <seealso cref="XmlNode"/>
        //////////////////////////////////////////////////////////////////////////

        public IList<XmlNode> PublicTargets
        {
            get
            {
                return ListFilter(
                    new Filter(
                        delegate(XmlNode node) {
                            return node.Name == AppConstants.NANT_XML_TARGET
                            && node.HasAttribute(AppConstants.NANT_XML_DESCRIPTION);
                        }
                    )
                );
            }
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Get the list of nodes that are target without a description.
        /// </summary>
        /// <seealso cref="XmlNode"/>
        //////////////////////////////////////////////////////////////////////////

        public IList<XmlNode> PrivateTargets
        {
            get
            {
                return ListFilter(
                    new Filter(
                        delegate(XmlNode node) {
                            return node.Name == AppConstants.NANT_XML_TARGET
                            && !node.HasAttribute(AppConstants.NANT_XML_DESCRIPTION);
                        }
                    )
                );
            }
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Get the list of nodes that are target.
        /// </summary>
        /// <seealso cref="XmlNode"/>
        //////////////////////////////////////////////////////////////////////////

        public IList<XmlNode> AllTargets
        {
            get
            {
                return ListFilter(
                    new Filter(
                        delegate(XmlNode node) {
                            return node.Name == AppConstants.NANT_XML_TARGET;
                        }
                    )
                );
            }
        }
    }
}
