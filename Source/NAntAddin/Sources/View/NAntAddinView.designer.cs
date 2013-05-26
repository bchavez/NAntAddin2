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

namespace NAntAddin
{
    partial class NAntAddinView
    {
        //////////////////////////////////////////////////////////////////////////
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////
        
        private System.ComponentModel.IContainer components = null;

        //////////////////////////////////////////////////////////////////////////
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //////////////////////////////////////////////////////////////////////////

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NAntAddinView));
            this.m_Toolbar = new System.Windows.Forms.ToolStrip();
            this.m_BtnOpen = new System.Windows.Forms.ToolStripButton();
            this.m_BtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.m_BtnStart = new System.Windows.Forms.ToolStripButton();
            this.m_BtnStop = new System.Windows.Forms.ToolStripButton();
            this.m_BtnOptions = new System.Windows.Forms.ToolStripButton();
            this.m_BtnInfo = new System.Windows.Forms.ToolStripButton();
            this.btnOption = new System.Windows.Forms.ToolStripButton();
            this.m_OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.m_TreeImages = new System.Windows.Forms.ImageList(this.components);
            this.m_MenuContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_MenuStart = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MenuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MenuExpandAll = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MenuCollapseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MenuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_MenuOption = new System.Windows.Forms.ToolStripMenuItem();
            this.m_SplitContainer = new System.Windows.Forms.SplitContainer();
            this.m_TreeView = new System.Windows.Forms.TreeView();
            this.m_ItemProperties = new System.Windows.Forms.PropertyGrid();
            this.m_PropertyTitle = new System.Windows.Forms.Label();
            this.m_MenuStop = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_Toolbar.SuspendLayout();
            this.m_MenuContext.SuspendLayout();
            this.m_SplitContainer.Panel1.SuspendLayout();
            this.m_SplitContainer.Panel2.SuspendLayout();
            this.m_SplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_Toolbar
            // 
            this.m_Toolbar.AllowMerge = false;
            this.m_Toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.m_Toolbar.ImageScalingSize = new System.Drawing.Size(18, 16);
            this.m_Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_BtnOpen,
            this.m_BtnRefresh,
            this.m_BtnStart,
            this.m_BtnStop,
            this.m_BtnOptions,
            this.m_BtnInfo});
            this.m_Toolbar.Location = new System.Drawing.Point(0, 0);
            this.m_Toolbar.Name = "m_Toolbar";
            this.m_Toolbar.Size = new System.Drawing.Size(307, 25);
            this.m_Toolbar.TabIndex = 0;
            this.m_Toolbar.Text = "toolStrip1";
            // 
            // m_BtnOpen
            // 
            this.m_BtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_BtnOpen.Image = ((System.Drawing.Image)(resources.GetObject("m_BtnOpen.Image")));
            this.m_BtnOpen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_BtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_BtnOpen.Name = "m_BtnOpen";
            this.m_BtnOpen.Size = new System.Drawing.Size(23, 22);
            this.m_BtnOpen.Text = "Open";
            this.m_BtnOpen.ToolTipText = "Open new script";
            this.m_BtnOpen.Click += new System.EventHandler(this.OnSelectFile);
            // 
            // m_BtnRefresh
            // 
            this.m_BtnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_BtnRefresh.Image = global::NAntAddin.Properties.Resources.refresh;
            this.m_BtnRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_BtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_BtnRefresh.Name = "m_BtnRefresh";
            this.m_BtnRefresh.Size = new System.Drawing.Size(23, 22);
            this.m_BtnRefresh.Text = "Refresh";
            this.m_BtnRefresh.ToolTipText = "Reload current script";
            this.m_BtnRefresh.Click += new System.EventHandler(this.OnReload);
            // 
            // m_BtnStart
            // 
            this.m_BtnStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_BtnStart.Image = global::NAntAddin.Properties.Resources.start;
            this.m_BtnStart.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_BtnStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_BtnStart.Name = "m_BtnStart";
            this.m_BtnStart.Size = new System.Drawing.Size(23, 22);
            this.m_BtnStart.Text = "Start";
            this.m_BtnStart.ToolTipText = "Start selected target";
            this.m_BtnStart.Click += new System.EventHandler(this.OnStartTarget);
            // 
            // m_BtnStop
            // 
            this.m_BtnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_BtnStop.Image = global::NAntAddin.Properties.Resources.stop;
            this.m_BtnStop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_BtnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_BtnStop.Name = "m_BtnStop";
            this.m_BtnStop.Size = new System.Drawing.Size(23, 22);
            this.m_BtnStop.Text = "Stop";
            this.m_BtnStop.ToolTipText = "Stop running target";
            this.m_BtnStop.Click += new System.EventHandler(this.OnStopTarget);
            // 
            // m_BtnOptions
            // 
            this.m_BtnOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_BtnOptions.Image = global::NAntAddin.Properties.Resources.options;
            this.m_BtnOptions.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_BtnOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_BtnOptions.Name = "m_BtnOptions";
            this.m_BtnOptions.Size = new System.Drawing.Size(23, 22);
            this.m_BtnOptions.Text = "Options";
            this.m_BtnOptions.ToolTipText = "Display options";
            this.m_BtnOptions.Click += new System.EventHandler(this.OnOptions);
            // 
            // m_BtnInfo
            // 
            this.m_BtnInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_BtnInfo.Image = global::NAntAddin.Properties.Resources.help;
            this.m_BtnInfo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_BtnInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_BtnInfo.Name = "m_BtnInfo";
            this.m_BtnInfo.Size = new System.Drawing.Size(23, 22);
            this.m_BtnInfo.Text = "Info";
            this.m_BtnInfo.ToolTipText = "About NAntAddin";
            this.m_BtnInfo.Click += new System.EventHandler(this.OnAbout);
            // 
            // btnOption
            // 
            this.btnOption.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOption.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOption.Name = "btnOption";
            this.btnOption.Size = new System.Drawing.Size(23, 22);
            this.btnOption.Text = "options";
            this.btnOption.ToolTipText = "Options";
            this.btnOption.Click += new System.EventHandler(this.OnOptions);
            // 
            // m_OpenFileDialog
            // 
            this.m_OpenFileDialog.FileName = "openFileDialog1";
            // 
            // m_TreeImages
            // 
            this.m_TreeImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_TreeImages.ImageStream")));
            this.m_TreeImages.TransparentColor = System.Drawing.Color.Transparent;
            this.m_TreeImages.Images.SetKeyName(0, "ant3.gif");
            this.m_TreeImages.Images.SetKeyName(1, "properties.gif");
            this.m_TreeImages.Images.SetKeyName(2, "targets_public.gif");
            this.m_TreeImages.Images.SetKeyName(3, "targets_private.gif");
            this.m_TreeImages.Images.SetKeyName(4, "targets_all.gif");
            this.m_TreeImages.Images.SetKeyName(5, "target.gif");
            this.m_TreeImages.Images.SetKeyName(6, "property.gif");
            this.m_TreeImages.Images.SetKeyName(7, "task.gif");
            this.m_TreeImages.Images.SetKeyName(8, "error.gif");
            // 
            // m_MenuContext
            // 
            this.m_MenuContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_MenuStart,
            this.m_MenuStop,
            this.m_MenuSeparator1,
            this.m_MenuEdit,
            this.m_MenuExpandAll,
            this.m_MenuCollapseAll,
            this.m_MenuSeparator2,
            this.m_MenuOption});
            this.m_MenuContext.Name = "menuContext";
            this.m_MenuContext.Size = new System.Drawing.Size(153, 170);
            // 
            // m_MenuStart
            // 
            this.m_MenuStart.Image = ((System.Drawing.Image)(resources.GetObject("m_MenuStart.Image")));
            this.m_MenuStart.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_MenuStart.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.m_MenuStart.Name = "m_MenuStart";
            this.m_MenuStart.Size = new System.Drawing.Size(152, 22);
            this.m_MenuStart.Text = "Start";
            this.m_MenuStart.Click += new System.EventHandler(this.OnStartTarget);
            // 
            // m_MenuEdit
            // 
            this.m_MenuEdit.Name = "m_MenuEdit";
            this.m_MenuEdit.Size = new System.Drawing.Size(152, 22);
            this.m_MenuEdit.Text = "Edit target...";
            this.m_MenuEdit.Click += new System.EventHandler(this.OnEditTarget);
            // 
            // m_MenuExpandAll
            // 
            this.m_MenuExpandAll.Name = "m_MenuExpandAll";
            this.m_MenuExpandAll.Size = new System.Drawing.Size(152, 22);
            this.m_MenuExpandAll.Text = "Expand All";
            this.m_MenuExpandAll.Click += new System.EventHandler(this.OnExpandAll);
            // 
            // m_MenuCollapseAll
            // 
            this.m_MenuCollapseAll.Name = "m_MenuCollapseAll";
            this.m_MenuCollapseAll.Size = new System.Drawing.Size(152, 22);
            this.m_MenuCollapseAll.Text = "Collapse All";
            this.m_MenuCollapseAll.Click += new System.EventHandler(this.OnCollapseAll);
            // 
            // m_MenuSeparator2
            // 
            this.m_MenuSeparator2.Name = "m_MenuSeparator2";
            this.m_MenuSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // m_MenuOption
            // 
            this.m_MenuOption.Image = global::NAntAddin.Properties.Resources.options;
            this.m_MenuOption.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_MenuOption.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.m_MenuOption.Name = "m_MenuOption";
            this.m_MenuOption.Size = new System.Drawing.Size(152, 22);
            this.m_MenuOption.Text = "Options...";
            this.m_MenuOption.Click += new System.EventHandler(this.OnOptions);
            // 
            // m_SplitContainer
            // 
            this.m_SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_SplitContainer.Location = new System.Drawing.Point(0, 25);
            this.m_SplitContainer.Name = "m_SplitContainer";
            this.m_SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // m_SplitContainer.Panel1
            // 
            this.m_SplitContainer.Panel1.Controls.Add(this.m_TreeView);
            // 
            // m_SplitContainer.Panel2
            // 
            this.m_SplitContainer.Panel2.Controls.Add(this.m_ItemProperties);
            this.m_SplitContainer.Panel2.Controls.Add(this.m_PropertyTitle);
            this.m_SplitContainer.Size = new System.Drawing.Size(307, 345);
            this.m_SplitContainer.SplitterDistance = 229;
            this.m_SplitContainer.TabIndex = 3;
            // 
            // m_TreeView
            // 
            this.m_TreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_TreeView.HideSelection = false;
            this.m_TreeView.ImageIndex = 0;
            this.m_TreeView.ImageList = this.m_TreeImages;
            this.m_TreeView.Location = new System.Drawing.Point(0, 0);
            this.m_TreeView.Name = "m_TreeView";
            this.m_TreeView.SelectedImageIndex = 0;
            this.m_TreeView.Size = new System.Drawing.Size(307, 229);
            this.m_TreeView.TabIndex = 3;
            this.m_TreeView.DoubleClick += new System.EventHandler(this.OnDoubleClick);
            this.m_TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnNodeSelected);
            this.m_TreeView.Click += new System.EventHandler(this.OnClick);
            // 
            // m_ItemProperties
            // 
            this.m_ItemProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_ItemProperties.HelpVisible = false;
            this.m_ItemProperties.Location = new System.Drawing.Point(0, 13);
            this.m_ItemProperties.Name = "m_ItemProperties";
            this.m_ItemProperties.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.m_ItemProperties.Size = new System.Drawing.Size(307, 99);
            this.m_ItemProperties.TabIndex = 1;
            this.m_ItemProperties.ToolbarVisible = false;
            // 
            // m_PropertyTitle
            // 
            this.m_PropertyTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_PropertyTitle.Location = new System.Drawing.Point(0, 0);
            this.m_PropertyTitle.Name = "m_PropertyTitle";
            this.m_PropertyTitle.Size = new System.Drawing.Size(307, 13);
            this.m_PropertyTitle.TabIndex = 2;
            this.m_PropertyTitle.Text = "Properties:";
            // 
            // m_MenuStop
            // 
            this.m_MenuStop.Image = global::NAntAddin.Properties.Resources.stop;
            this.m_MenuStop.Name = "m_MenuStop";
            this.m_MenuStop.Size = new System.Drawing.Size(152, 22);
            this.m_MenuStop.Text = "Stop";
            this.m_MenuStop.Click += new System.EventHandler(this.OnStopTarget);
            // 
            // m_MenuSeparator1
            // 
            this.m_MenuSeparator1.Name = "m_MenuSeparator1";
            this.m_MenuSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // NAntAddinView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_SplitContainer);
            this.Controls.Add(this.m_Toolbar);
            this.Name = "NAntAddinView";
            this.Size = new System.Drawing.Size(307, 370);
            this.Load += new System.EventHandler(this.OnLoad);
            this.m_Toolbar.ResumeLayout(false);
            this.m_Toolbar.PerformLayout();
            this.m_MenuContext.ResumeLayout(false);
            this.m_SplitContainer.Panel1.ResumeLayout(false);
            this.m_SplitContainer.Panel2.ResumeLayout(false);
            this.m_SplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Main toolbar.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        private System.Windows.Forms.ToolStrip m_Toolbar;

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Open file dialog.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        private System.Windows.Forms.OpenFileDialog m_OpenFileDialog;

        //////////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Split between tree and property grid.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        private System.Windows.Forms.SplitContainer m_SplitContainer;

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// NAnt task property.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        private System.Windows.Forms.PropertyGrid m_ItemProperties;

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Context menu.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        private System.Windows.Forms.ContextMenuStrip m_MenuContext;

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Start menu item.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        private System.Windows.Forms.ToolStripMenuItem m_MenuStart;

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Option menu item.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        private System.Windows.Forms.ToolStripMenuItem m_MenuOption;

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Option button.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        private System.Windows.Forms.ToolStripButton btnOption;

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Expand All menu item.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        private System.Windows.Forms.ToolStripMenuItem m_MenuExpandAll;

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Collapse All menu item.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        private System.Windows.Forms.ToolStripMenuItem m_MenuCollapseAll;

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Menu separator.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        private System.Windows.Forms.ToolStripSeparator m_MenuSeparator2;

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Open button.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        private System.Windows.Forms.ToolStripButton m_BtnOpen;

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Refresh button.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        private System.Windows.Forms.ToolStripButton m_BtnRefresh;

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Start button.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        private System.Windows.Forms.ToolStripButton m_BtnStart;

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Stop button.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        private System.Windows.Forms.ToolStripButton m_BtnStop;

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Option button.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        private System.Windows.Forms.ToolStripButton m_BtnOptions;

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Info button.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        private System.Windows.Forms.ToolStripButton m_BtnInfo;

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// NAnt tree image list.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        private System.Windows.Forms.ImageList m_TreeImages;
        private System.Windows.Forms.Label m_PropertyTitle;
        private System.Windows.Forms.ToolStripMenuItem m_MenuEdit;
        private System.Windows.Forms.TreeView m_TreeView;
        private System.Windows.Forms.ToolStripMenuItem m_MenuStop;
        private System.Windows.Forms.ToolStripSeparator m_MenuSeparator1;
    }
}
