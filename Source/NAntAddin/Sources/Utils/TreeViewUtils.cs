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
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace NAntAddin
{
    //////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Utilities methods for the NAnt Addin tree view.
    /// </summary>
    //////////////////////////////////////////////////////////////////////////

    public static class TreeViewUtils
    {
        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Create a array of indexes for a TreeNode in a TreeView.
        /// </summary>
        /// <param name="node">The TreeNode of path.</param>
        /// <returns>The array of indexes.</returns>
        //////////////////////////////////////////////////////////////////////////

        public static int[] GetPath(TreeNode node)
        {
            // Array of index
            List<int> path = new List<int>();

            if (node != null)
            {
                while (node.Parent != null)
                {
                    // Index of node
                    path.Add(node.Index);

                    // One level up
                    node = node.Parent;
                }

                // Top level index
                path.Add(node.Index);

                // Reverse to have path from root
                path.Reverse();
            }

            return path.ToArray();
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Find a TreeNode in a TreeView.
        /// </summary>
        /// <param name="path">The array of indexes.</param>
        /// <param name="tree">The tree in which we search.</param>
        /// <returns>The TreeNode to find, null if not found.</returns>
        //////////////////////////////////////////////////////////////////////////

        public static TreeNode GetTreeNode(TreeView treeView, int[] path)
        {
            // Node to find
            TreeNode node = null;

            // Children of tree
            TreeNodeCollection nodes = treeView.Nodes;

            try
            {
                // Follow the path in children
                foreach (int index in path)
                {
                    node = nodes[index];
                    nodes = node.Nodes;
                }
            }
            catch
            {
                node = null;
            }

            return node;
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Open a context menu at the right position on a tree view.
        /// </summary>
        /// <param name="tree">The tree view.</param>
        /// <param name="contextMenu">The context menu to display.</param>
        /// <param name="evt">The mouse event.</param>
        /// <param name="mousePoint">The position of the mouse.</param>
        //////////////////////////////////////////////////////////////////////////

        public static void ShowContext(TreeView treeView, ContextMenuStrip contextMenu, MouseEventArgs evt, Point mousePoint)
        {
            // Retrieve the node under the mouse
            treeView.SelectedNode = treeView.GetNodeAt(evt.X, evt.Y);

            if (treeView.SelectedNode != null)
            {
                // Show context menu at correct position
                contextMenu.Show(mousePoint);
            }
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Return the NAntNode attached to a TreeNode.
        /// </summary>
        /// <param name="node">The TreeNode.</param>
        /// <returns>The NAntNode or null if any NAntNode is attached.</returns>
        //////////////////////////////////////////////////////////////////////////

        public static XmlNode GetNAntNode(TreeNode node)
        {
            if (node != null && node.Tag != null && node.Tag is XmlNode)
                return (XmlNode)node.Tag;

            return null;
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Determines whether a TreeNode has a NAntNode attached to it.
        /// </summary>
        /// <param name="node">The TreeNode to check.</param>
        /// <returns>True if a NAntNode is attached and false if not.</returns>
        //////////////////////////////////////////////////////////////////////////

        public static bool IsNAntNode(TreeNode node)
        {
            return GetNAntNode(node) != null;
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Determines whether a TreeNode has a NAntNode attached to it and if
        /// this node is NAnt target.
        /// </summary>
        /// <param name="node">The TreeNode to check.</param>
        /// <returns>
        /// True if a NAntNode is attached and the NAntNode is a NAnt target and
        /// false if not.
        /// </returns>
        //////////////////////////////////////////////////////////////////////////

        public static bool IsNAntTarget(TreeNode treeNode)
        {
            if (treeNode == null)
                return false;

            XmlNode nantNode = TreeViewUtils.GetNAntNode(treeNode);

            if (nantNode != null)
                return nantNode.Name == AppConstants.NANT_XML_TARGET;

            return false;
        }
    }
}
