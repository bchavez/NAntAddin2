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
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace NAntAddin
{
    //////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// NAnt Addin tree view factory.
    /// </summary>
    //////////////////////////////////////////////////////////////////////////

    public static class TreeViewFactory
    {
        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Build the NAnt Addin tree view from an NAntTree.
        /// </summary>
        /// <param name="treeView">The NAnt Addin tree.</param>
        /// <param name="nantTree">The NAntTree.</param>
        /// <param name="title">The title to display.</param>
        //////////////////////////////////////////////////////////////////////////

        public static void CreateTree(TreeView treeView, XmlTree nantTree, string title)
        {
            if (nantTree == null)
                return;

            // Initialize the treeview and its root node
            treeView.Nodes.Clear();

            // Create root node
            TreeNode rootNode = new TreeNode(title);
            rootNode.Tag = nantTree.Root;
            treeView.Nodes.Add(rootNode);


            // Build properties
            if (nantTree.Properties != null)
            {
                TreeNode treeNode = TreeViewFactory.CreateTreeNode(nantTree.Properties, "Properties");
                rootNode.Nodes.Add(treeNode);
            }

            // Build targets in two groups
            if (Properties.Settings.Default.NANT_SPLIT_TARGETS)
            {
                // Build public targets
                if (nantTree.PublicTargets != null)
                {
                    TreeNode publicNodes = TreeViewFactory.CreateTreeNode(nantTree.PublicTargets, "Public targets");
                    rootNode.Nodes.Add(publicNodes);
                    publicNodes.Expand();
                }

                // Build private targets
                if (nantTree.PrivateTargets != null)
                {
                    TreeNode privateNodes = TreeViewFactory.CreateTreeNode(nantTree.PrivateTargets, "Private targets");
                    rootNode.Nodes.Add(privateNodes);
                }
            }
            // Build target all together
            else
            {
                // Build all targets
                if (nantTree.AllTargets != null)
                {
                    TreeNode allNodes = TreeViewFactory.CreateTreeNode(nantTree.AllTargets, "Targets");
                    rootNode.Nodes.Add(allNodes);
                    allNodes.Expand();
                }
            }

            // Build icon
            TreeViewFactory.CreateIcons(treeView);

            // Finally expand the root node
            rootNode.Expand();
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Build a branch of NAnt Addin tree view from a list of NAntNode.
        /// </summary>
        /// <param name="nodes">The list of NAntNode to add.</param>
        /// <param name="title">The title of the branch.</param>
        /// <returns>The root node of the branch.</returns>
        //////////////////////////////////////////////////////////////////////////

        public static TreeNode CreateTreeNode(IList<XmlNode> nodes, string title)
        {
            // Parent node of the branch
            TreeNode rootNode = new TreeNode(title);

            // Children
            List<TreeNode> nodeChildren = new List<TreeNode>();

            // Build children
            foreach (XmlNode node in nodes)
            {
                // Build a child and add to root
                TreeNode child = CreateTreeNode(node);
                nodeChildren.Add(child);
            }

            // Add all children
            rootNode.Nodes.AddRange(nodeChildren.ToArray());

            return rootNode;
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Build recursivly a node of a branch from an NAntNode.
        /// </summary>
        /// <param name="nantNode">The NAntNode to build.</param>
        /// <returns>The root of the branch.</returns>
        //////////////////////////////////////////////////////////////////////////

        public static TreeNode CreateTreeNode(XmlNode nantNode)
        {
            // Set the title of node with nantNode name
            string title = nantNode.Name;
            
            // For target/property we take the name of the target/property
            if (nantNode.Name == AppConstants.NANT_XML_TARGET 
                || nantNode.Name == AppConstants.NANT_XML_PROPERTY)
                title = nantNode["name"];

            // Initialize the root node
            TreeNode root = new TreeNode(title);

            // Attache nantNode to tree view node
            root.Tag = nantNode;

            // Retrieve the children of node
            IList<XmlNode> children = nantNode.Children;

            if (children != null)
            {
                // Build each child recurvively
                foreach (XmlNode child in children)
                {
                    if (nantNode.Name != AppConstants.NANT_XML_TARGET)
                    {
                        // Build a node and add to parent
                        TreeNode node = CreateTreeNode(child);
                        root.Nodes.Add(node);
                    }
                }
            }

            return root;
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Set the icon to the NAnt Addin tree view.
        /// </summary>
        /// <param name="tree">The tree view to iconize.</param>
        //////////////////////////////////////////////////////////////////////////

        private static void CreateIcons(TreeView tree)
        {
            // Default icon for the tree
            tree.ImageIndex = tree.SelectedImageIndex = AppConstants.ICON_TASK;

            // Select the root node
            TreeNode root = tree.Nodes[0];

            // If no children
            if (root.Nodes.Count == 0)
            {
                // Error
                root.ImageIndex = root.SelectedImageIndex = AppConstants.ICON_ERROR;
            }
            else
            {
                // Working node
                TreeNode node = null;

                // Set NAnt icon
                root.ImageIndex = root.SelectedImageIndex = AppConstants.ICON_NANT;

                // Select property node
                node = root.Nodes[0];

                // Set properties icon
                node.ImageIndex = node.SelectedImageIndex = AppConstants.ICON_PROPERTIES;

                // For each property set icon property
                foreach (TreeNode child in node.Nodes)
                    child.ImageIndex = child.SelectedImageIndex = AppConstants.ICON_PROPERTY;

                // Target in two groups
                if (Properties.Settings.Default.NANT_SPLIT_TARGETS)
                {
                    // Select public targets node
                    node = root.Nodes[1];

                    // Set public target icon
                    node.ImageIndex = node.SelectedImageIndex = AppConstants.ICON_TARGETS_PUBLIC;

                    // For each target set target icon
                    foreach (TreeNode child in node.Nodes)
                        child.ImageIndex = child.SelectedImageIndex = AppConstants.ICON_TARGET;

                    // Select private targets node
                    node = root.Nodes[2];

                    // Set private target icon
                    node.ImageIndex = node.SelectedImageIndex = AppConstants.ICON_TARGETS_PRIVATE;

                    // For each target set target icon
                    foreach (TreeNode child in node.Nodes)
                        child.ImageIndex = child.SelectedImageIndex = AppConstants.ICON_TARGET;
                }

                // Target all together
                else
                {
                    // Select targets node
                    node = root.Nodes[1];

                    // Set document target icon
                    node.ImageIndex = node.SelectedImageIndex = AppConstants.ICON_TARGETS_ALL;

                    // For each target set target icon
                    foreach (TreeNode child in node.Nodes)
                        child.ImageIndex = child.SelectedImageIndex = AppConstants.ICON_TARGET;
                }
            }
        }
    }
}
