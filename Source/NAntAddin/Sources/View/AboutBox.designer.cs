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
    //////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// GUI components.
    /// </summary>
    //////////////////////////////////////////////////////////////////////////
    
    partial class AboutBox
    {
        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Required designer variable.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////
        
        private System.ComponentModel.IContainer components = null;

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Button to close the window.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        private System.Windows.Forms.Button m_BtnOk;

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">If true dispose this and parent and only parent
        /// otherwise.</param>
        //////////////////////////////////////////////////////////////////////////
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_BtnOk = new System.Windows.Forms.Button();
            this.m_LabelTitle = new System.Windows.Forms.Label();
            this.m_LabelVersion = new System.Windows.Forms.Label();
            this.m_LabelSubtitle = new System.Windows.Forms.Label();
            this.m_LabelCopyright = new System.Windows.Forms.Label();
            this.m_GroupBox = new System.Windows.Forms.GroupBox();
            this.m_LabelCountry = new System.Windows.Forms.Label();
            this.m_GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_BtnOk
            // 
            this.m_BtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_BtnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_BtnOk.Location = new System.Drawing.Point(110, 167);
            this.m_BtnOk.Name = "m_BtnOk";
            this.m_BtnOk.Size = new System.Drawing.Size(75, 23);
            this.m_BtnOk.TabIndex = 24;
            this.m_BtnOk.Text = "&OK";
            // 
            // m_LabelTitle
            // 
            this.m_LabelTitle.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_LabelTitle.Location = new System.Drawing.Point(7, 16);
            this.m_LabelTitle.Name = "m_LabelTitle";
            this.m_LabelTitle.Size = new System.Drawing.Size(269, 23);
            this.m_LabelTitle.TabIndex = 25;
            this.m_LabelTitle.Text = "NAntAddin";
            this.m_LabelTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // m_LabelVersion
            // 
            this.m_LabelVersion.Location = new System.Drawing.Point(7, 69);
            this.m_LabelVersion.Name = "m_LabelVersion";
            this.m_LabelVersion.Size = new System.Drawing.Size(269, 13);
            this.m_LabelVersion.TabIndex = 26;
            this.m_LabelVersion.Text = "Version 1.x.x";
            this.m_LabelVersion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // m_LabelSubtitle
            // 
            this.m_LabelSubtitle.Location = new System.Drawing.Point(7, 39);
            this.m_LabelSubtitle.Name = "m_LabelSubtitle";
            this.m_LabelSubtitle.Size = new System.Drawing.Size(269, 13);
            this.m_LabelSubtitle.TabIndex = 26;
            this.m_LabelSubtitle.Text = "for Microsoft VisualStudio 2010";
            this.m_LabelSubtitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // m_LabelCopyright
            // 
            this.m_LabelCopyright.Location = new System.Drawing.Point(7, 108);
            this.m_LabelCopyright.Name = "m_LabelCopyright";
            this.m_LabelCopyright.Size = new System.Drawing.Size(269, 13);
            this.m_LabelCopyright.TabIndex = 26;
            this.m_LabelCopyright.Text = "Copyright © 2006-2010 - Netlogics Software";
            this.m_LabelCopyright.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // m_GroupBox
            // 
            this.m_GroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_GroupBox.Controls.Add(this.m_LabelTitle);
            this.m_GroupBox.Controls.Add(this.m_LabelCountry);
            this.m_GroupBox.Controls.Add(this.m_LabelCopyright);
            this.m_GroupBox.Controls.Add(this.m_LabelSubtitle);
            this.m_GroupBox.Controls.Add(this.m_LabelVersion);
            this.m_GroupBox.Location = new System.Drawing.Point(12, 5);
            this.m_GroupBox.Name = "m_GroupBox";
            this.m_GroupBox.Size = new System.Drawing.Size(282, 156);
            this.m_GroupBox.TabIndex = 27;
            this.m_GroupBox.TabStop = false;
            // 
            // m_LabelCountry
            // 
            this.m_LabelCountry.Location = new System.Drawing.Point(8, 121);
            this.m_LabelCountry.Name = "m_LabelCountry";
            this.m_LabelCountry.Size = new System.Drawing.Size(269, 13);
            this.m_LabelCountry.TabIndex = 26;
            this.m_LabelCountry.Text = "Geneva - Switzerland";
            this.m_LabelCountry.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AboutBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 193);
            this.Controls.Add(this.m_GroupBox);
            this.Controls.Add(this.m_BtnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NAntAddin AboutBox";
            this.Load += new System.EventHandler(this.OnLoad);
            this.m_GroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label m_LabelTitle;
        private System.Windows.Forms.Label m_LabelVersion;
        private System.Windows.Forms.Label m_LabelSubtitle;
        private System.Windows.Forms.Label m_LabelCopyright;
        private System.Windows.Forms.GroupBox m_GroupBox;
        private System.Windows.Forms.Label m_LabelCountry;
    }
}
