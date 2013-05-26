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

    partial class OptionsView
    {

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Required designer variable.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////
        
        private System.ComponentModel.IContainer components = null;

        //////////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////////

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
            this.m_BtnCancel = new System.Windows.Forms.Button();
            this.m_GroupBox = new System.Windows.Forms.GroupBox();
            this.m_FieldAutoload = new System.Windows.Forms.CheckBox();
            this.m_FieldVerbose = new System.Windows.Forms.CheckBox();
            this.m_FieldAutoClear = new System.Windows.Forms.CheckBox();
            this.m_TargetGroupBox = new System.Windows.Forms.GroupBox();
            this.m_FieldGlobal = new System.Windows.Forms.RadioButton();
            this.m_FieldSplit = new System.Windows.Forms.RadioButton();
            this.m_LabelParam = new System.Windows.Forms.Label();
            this.m_LabelExe = new System.Windows.Forms.Label();
            this.m_FieldParams = new System.Windows.Forms.TextBox();
            this.m_BtnBrowse = new System.Windows.Forms.Button();
            this.m_FieldCommand = new System.Windows.Forms.TextBox();
            this.m_SelectFile = new System.Windows.Forms.OpenFileDialog();
            this.m_GroupBox.SuspendLayout();
            this.m_TargetGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_BtnOk
            // 
            this.m_BtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_BtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_BtnOk.Location = new System.Drawing.Point(215, 245);
            this.m_BtnOk.Name = "m_BtnOk";
            this.m_BtnOk.Size = new System.Drawing.Size(75, 23);
            this.m_BtnOk.TabIndex = 24;
            this.m_BtnOk.Text = "&Ok";
            this.m_BtnOk.Click += new System.EventHandler(this.OnSave);
            // 
            // m_BtnCancel
            // 
            this.m_BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_BtnCancel.Location = new System.Drawing.Point(297, 245);
            this.m_BtnCancel.Name = "m_BtnCancel";
            this.m_BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.m_BtnCancel.TabIndex = 24;
            this.m_BtnCancel.Text = "&Cancel";
            // 
            // m_GroupBox
            // 
            this.m_GroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_GroupBox.Controls.Add(this.m_FieldAutoload);
            this.m_GroupBox.Controls.Add(this.m_FieldVerbose);
            this.m_GroupBox.Controls.Add(this.m_FieldAutoClear);
            this.m_GroupBox.Controls.Add(this.m_TargetGroupBox);
            this.m_GroupBox.Controls.Add(this.m_LabelParam);
            this.m_GroupBox.Controls.Add(this.m_LabelExe);
            this.m_GroupBox.Controls.Add(this.m_FieldParams);
            this.m_GroupBox.Controls.Add(this.m_BtnBrowse);
            this.m_GroupBox.Controls.Add(this.m_FieldCommand);
            this.m_GroupBox.Location = new System.Drawing.Point(12, 12);
            this.m_GroupBox.Name = "m_GroupBox";
            this.m_GroupBox.Size = new System.Drawing.Size(358, 224);
            this.m_GroupBox.TabIndex = 25;
            this.m_GroupBox.TabStop = false;
            this.m_GroupBox.Text = "Settings";
            // 
            // m_FieldAutoload
            // 
            this.m_FieldAutoload.AutoSize = true;
            this.m_FieldAutoload.Checked = true;
            this.m_FieldAutoload.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_FieldAutoload.Location = new System.Drawing.Point(201, 174);
            this.m_FieldAutoload.Name = "m_FieldAutoload";
            this.m_FieldAutoload.Size = new System.Drawing.Size(125, 17);
            this.m_FieldAutoload.TabIndex = 14;
            this.m_FieldAutoload.Text = "Autoload NAnt Script";
            this.m_FieldAutoload.UseVisualStyleBackColor = true;
            // 
            // m_FieldVerbose
            // 
            this.m_FieldVerbose.AutoSize = true;
            this.m_FieldVerbose.Checked = true;
            this.m_FieldVerbose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_FieldVerbose.Location = new System.Drawing.Point(201, 128);
            this.m_FieldVerbose.Name = "m_FieldVerbose";
            this.m_FieldVerbose.Size = new System.Drawing.Size(100, 17);
            this.m_FieldVerbose.TabIndex = 13;
            this.m_FieldVerbose.Text = "Verbose Output";
            this.m_FieldVerbose.UseVisualStyleBackColor = true;
            // 
            // m_FieldAutoClear
            // 
            this.m_FieldAutoClear.AutoSize = true;
            this.m_FieldAutoClear.Checked = true;
            this.m_FieldAutoClear.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_FieldAutoClear.Location = new System.Drawing.Point(201, 151);
            this.m_FieldAutoClear.Name = "m_FieldAutoClear";
            this.m_FieldAutoClear.Size = new System.Drawing.Size(115, 17);
            this.m_FieldAutoClear.TabIndex = 4;
            this.m_FieldAutoClear.Text = "Autoclean Console";
            this.m_FieldAutoClear.UseVisualStyleBackColor = true;
            // 
            // m_TargetGroupBox
            // 
            this.m_TargetGroupBox.Controls.Add(this.m_FieldGlobal);
            this.m_TargetGroupBox.Controls.Add(this.m_FieldSplit);
            this.m_TargetGroupBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_TargetGroupBox.Location = new System.Drawing.Point(18, 113);
            this.m_TargetGroupBox.Name = "m_TargetGroupBox";
            this.m_TargetGroupBox.Size = new System.Drawing.Size(162, 87);
            this.m_TargetGroupBox.TabIndex = 11;
            this.m_TargetGroupBox.TabStop = false;
            this.m_TargetGroupBox.Text = "Target grouping";
            // 
            // m_FieldGlobal
            // 
            this.m_FieldGlobal.AutoSize = true;
            this.m_FieldGlobal.Location = new System.Drawing.Point(19, 26);
            this.m_FieldGlobal.Name = "m_FieldGlobal";
            this.m_FieldGlobal.Size = new System.Drawing.Size(55, 17);
            this.m_FieldGlobal.TabIndex = 0;
            this.m_FieldGlobal.Text = "Global";
            this.m_FieldGlobal.UseVisualStyleBackColor = true;
            // 
            // m_FieldSplit
            // 
            this.m_FieldSplit.AutoSize = true;
            this.m_FieldSplit.Checked = true;
            this.m_FieldSplit.Location = new System.Drawing.Point(19, 49);
            this.m_FieldSplit.Name = "m_FieldSplit";
            this.m_FieldSplit.Size = new System.Drawing.Size(115, 17);
            this.m_FieldSplit.TabIndex = 1;
            this.m_FieldSplit.TabStop = true;
            this.m_FieldSplit.Text = "Split Public/Private";
            this.m_FieldSplit.UseVisualStyleBackColor = true;
            // 
            // m_LabelParam
            // 
            this.m_LabelParam.AutoSize = true;
            this.m_LabelParam.Location = new System.Drawing.Point(18, 65);
            this.m_LabelParam.Name = "m_LabelParam";
            this.m_LabelParam.Size = new System.Drawing.Size(92, 13);
            this.m_LabelParam.TabIndex = 3;
            this.m_LabelParam.Text = "NAnt parameters :";
            // 
            // m_LabelExe
            // 
            this.m_LabelExe.AutoSize = true;
            this.m_LabelExe.Location = new System.Drawing.Point(18, 26);
            this.m_LabelExe.Name = "m_LabelExe";
            this.m_LabelExe.Size = new System.Drawing.Size(107, 13);
            this.m_LabelExe.TabIndex = 3;
            this.m_LabelExe.Text = "NAnt command path:";
            // 
            // m_FieldParams
            // 
            this.m_FieldParams.Location = new System.Drawing.Point(18, 81);
            this.m_FieldParams.Name = "m_FieldParams";
            this.m_FieldParams.Size = new System.Drawing.Size(321, 20);
            this.m_FieldParams.TabIndex = 3;
            // 
            // m_BtnBrowse
            // 
            this.m_BtnBrowse.Location = new System.Drawing.Point(317, 40);
            this.m_BtnBrowse.Name = "m_BtnBrowse";
            this.m_BtnBrowse.Size = new System.Drawing.Size(24, 24);
            this.m_BtnBrowse.TabIndex = 2;
            this.m_BtnBrowse.Text = "...";
            this.m_BtnBrowse.UseVisualStyleBackColor = true;
            this.m_BtnBrowse.Click += new System.EventHandler(this.OnSelectPath);
            // 
            // m_FieldCommand
            // 
            this.m_FieldCommand.Location = new System.Drawing.Point(18, 42);
            this.m_FieldCommand.Name = "m_FieldCommand";
            this.m_FieldCommand.Size = new System.Drawing.Size(300, 20);
            this.m_FieldCommand.TabIndex = 0;
            // 
            // OptionsView
            // 
            this.AcceptButton = this.m_BtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_BtnCancel;
            this.ClientSize = new System.Drawing.Size(384, 271);
            this.Controls.Add(this.m_GroupBox);
            this.Controls.Add(this.m_BtnCancel);
            this.Controls.Add(this.m_BtnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsView";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NAntAddin Options";
            this.Load += new System.EventHandler(this.OnLoad);
            this.m_GroupBox.ResumeLayout(false);
            this.m_GroupBox.PerformLayout();
            this.m_TargetGroupBox.ResumeLayout(false);
            this.m_TargetGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_BtnOk;
        private System.Windows.Forms.Button m_BtnCancel;
        private System.Windows.Forms.GroupBox m_GroupBox;
        private System.Windows.Forms.CheckBox m_FieldVerbose;
        private System.Windows.Forms.CheckBox m_FieldAutoClear;
        private System.Windows.Forms.GroupBox m_TargetGroupBox;
        private System.Windows.Forms.RadioButton m_FieldGlobal;
        private System.Windows.Forms.RadioButton m_FieldSplit;
        private System.Windows.Forms.Label m_LabelParam;
        private System.Windows.Forms.Label m_LabelExe;
        private System.Windows.Forms.TextBox m_FieldParams;
        private System.Windows.Forms.Button m_BtnBrowse;
        private System.Windows.Forms.TextBox m_FieldCommand;
        private System.Windows.Forms.OpenFileDialog m_SelectFile;
        private System.Windows.Forms.CheckBox m_FieldAutoload;

    }
}
