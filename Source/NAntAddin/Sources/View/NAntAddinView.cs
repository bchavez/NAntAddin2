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
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using EnvDTE80;

namespace NAntAddin
{
    //////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// UserControl for the NAnt Addin.
    /// </summary>
    //////////////////////////////////////////////////////////////////////////

    public partial class NAntAddinView : UserControl
    {
        // Private attributes
        private ViewController m_ViewController;

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Default constructor.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public NAntAddinView()
        {
            InitializeComponent();
            m_ViewController = new ViewController();
            m_ViewController.NAntProcess.TargetCompleted += new NAntProcess.TargetCompletedHandler(OnTargetCompleted);
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets the selected node.
        /// </summary>
        /// <value>The selected node.</value>
        //////////////////////////////////////////////////////////////////////////
        
        public XmlNode SelectedNode
        {
            get
            {
                XmlNode nantNode = TreeViewUtils.GetNAntNode(m_TreeView.SelectedNode);
                return nantNode;
            }
        }

        //////////////////////////////////////////////////////////////////////////

        public ViewController ViewController
        {
            get { return m_ViewController; }
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Refresh the state of buttons
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        private void RefreshView()
        {
            bool isNAntRunning   = m_ViewController.IsWorking;
            bool isNodeStartable = TreeViewUtils.IsNAntTarget(m_TreeView.SelectedNode);

            // Refresh buttons
            m_BtnStart.Enabled   = isNodeStartable & !isNAntRunning;
            m_BtnRefresh.Enabled = !isNAntRunning && this.ViewController.Filename != null;
            m_BtnInfo.Enabled    = true;
            m_BtnOptions.Enabled = !isNAntRunning;
            m_BtnStop.Enabled    = isNAntRunning;

            // Refresh menus
            m_MenuStart.Enabled  = isNodeStartable && !isNAntRunning;
            m_MenuStop.Enabled   = isNodeStartable && isNAntRunning;
            m_MenuEdit.Enabled   = isNodeStartable && !isNAntRunning;
            m_MenuOption.Enabled = !isNAntRunning;
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// The UserControl has been loaded.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        //////////////////////////////////////////////////////////////////////////

        public void OnLoad(object sender, EventArgs e)
        {
            RefreshView();
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// The refresh button has been clicked or a new file has been loaded.
        /// The current TreeView will be reloaded.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        //////////////////////////////////////////////////////////////////////////

        public void OnReload(object sender, EventArgs e)
        {
            // Save current selected node
            int[] selectedNodePath = TreeViewUtils.GetPath(m_TreeView.SelectedNode);

            // Load file if any
            if (m_ViewController.Filename == null)
            {
                m_TreeView.Nodes.Clear();
                m_ItemProperties.SelectedObject = null;
            }
            else
            {
                try
                {
                    // Load the file
                    m_ViewController.LoadFile(m_ViewController.Filename);

                    // Create a corresponding visual tree
                    TreeViewFactory.CreateTree(m_TreeView, m_ViewController.NAntTree, m_ViewController.Filename);
                }
                catch (Exception e1)
                {
                    MessageBox.Show("Error while loading file '"
                        + m_ViewController.Filename + "'."
                        + "\n"
                        + e1.Message,
                        "NAntAddin Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

            // Retrieve current TreeNode
            m_TreeView.SelectedNode = TreeViewUtils.GetTreeNode(m_TreeView, selectedNodePath);

            // Autoselect the first node, by default
            if (m_TreeView.SelectedNode == null && m_TreeView.Nodes.Count > 0)
                m_TreeView.SelectedNode = m_TreeView.Nodes[0];

            RefreshView();
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// A node of the tree view has been selected.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        //////////////////////////////////////////////////////////////////////////

        private void OnNodeSelected(object sender, TreeViewEventArgs e)
        {
            // Get the selected node
            XmlNode selectedNode = TreeViewUtils.GetNAntNode(e.Node);

            m_ViewController.CurrentNode = selectedNode;

            // Check if node can be display in property pane
            if (selectedNode != null)
                m_ItemProperties.SelectedObject = m_ViewController.CurrentNode.Descriptor;
            else
                m_ItemProperties.SelectedObject = null;

            // Refresh button
            RefreshView();
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// A file has been selected with the file dialog box.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        //////////////////////////////////////////////////////////////////////////

        private void OnSelectFile(object sender, EventArgs e)
        {
            // File dialog settings
            m_OpenFileDialog.InitialDirectory = m_ViewController.SolutionFolder;
            m_OpenFileDialog.Filter           = m_ViewController.FileFilter;
            m_OpenFileDialog.FileName         = m_ViewController.Filename;

            // Show it
            if (m_OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Update controller and refresh view
                m_ViewController.Filename = m_OpenFileDialog.FileName;
                OnReload(sender, e);
            }
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Open the script file at the selected target location.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event.</param>
        //////////////////////////////////////////////////////////////////////////

        private void OnEditTarget(object sender, EventArgs e)
        {
            m_ViewController.SelectNodeLine();
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Display the context menu when the TreeView is clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        //////////////////////////////////////////////////////////////////////////

        private void OnClick(object sender, EventArgs e)
        {
            // Check right click
            MouseEventArgs evt = e as MouseEventArgs;
            if (evt.Button == MouseButtons.Right)
            {
                // Open the context menu at the good position.
                TreeViewUtils.ShowContext(m_TreeView, m_MenuContext, evt, MousePosition);
            }
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// A double click has been done on a node.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        //////////////////////////////////////////////////////////////////////////

        private void OnDoubleClick(object sender, EventArgs e)
        {
            if (TreeViewUtils.IsNAntTarget(m_TreeView.SelectedNode))
                OnStartTarget(sender, e);
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// The Collapse All contextual menu item has been selected.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        //////////////////////////////////////////////////////////////////////////

        private void OnCollapseAll(object sender, EventArgs e)
        {
            m_TreeView.SelectedNode.Collapse();
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// The Expand All context menu item has been selected.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        //////////////////////////////////////////////////////////////////////////

        private void OnExpandAll(object sender, EventArgs e)
        {
            m_TreeView.SelectedNode.ExpandAll();
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Display AboutBox dialog
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        //////////////////////////////////////////////////////////////////////////

        private void OnAbout(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Display OptionsBox dialog
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        //////////////////////////////////////////////////////////////////////////

        private void OnOptions(object sender, EventArgs e)
        {
            if (new OptionsView().ShowDialog() == DialogResult.OK)
            {
                OnReload(sender, e);
            }
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// The start button has been clicked to run a NAnt target task.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        //////////////////////////////////////////////////////////////////////////

        private void OnStartTarget(object sender, EventArgs e)
        {
            m_ViewController.StartTarget();
            RefreshView();
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// The stop button has been clicked to stop a NAnt target task.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event.</param>
        //////////////////////////////////////////////////////////////////////////

        private void OnStopTarget(object sender, EventArgs e)
        {
            m_ViewController.StopTarget();
            RefreshView();
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// The current NAntProcess has been cancelled and stopped.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event.</param>
        //////////////////////////////////////////////////////////////////////////

        public void OnTargetCompleted(object sender, EventArgs e)
        {
            RefreshView();
            this.Focus();
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// A solution has been opened, so a default build file is looked out
        /// recursively through the solution. By default the file 'default.build' 
        /// is loaded. If none available, the first *.build file is loaded.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public void OnSolutionOpened()
        {
            // If autoload specified, just load default build file
            if (Properties.Settings.Default.NANT_AUTOLOAD)
            {
                m_ViewController.Filename = m_ViewController.DefaultBuildFile;
                OnReload(this, null);
            }
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// A solution has been closed.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public void OnSolutionClosed()
        {
            // If NAnt process is running, stop it
            if (m_ViewController.IsWorking)
                OnStopTarget(this, new EventArgs());

            // If autoload specified, just clean current build file
            if (Properties.Settings.Default.NANT_AUTOLOAD)
            {
                m_ViewController.Filename = null;
                OnReload(this, null);
            }
        }
    }
}
