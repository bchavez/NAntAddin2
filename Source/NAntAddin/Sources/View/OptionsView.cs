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
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace NAntAddin
{
    //////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// About box form
    /// </summary>
    //////////////////////////////////////////////////////////////////////////

    partial class OptionsView : Form
    {
        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Default constructor.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public OptionsView()
        {
            InitializeComponent();
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Load the properties.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public void LoadOptions()
        {
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Save the properties.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public void SaveOptions()
        {
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Initialize the view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //////////////////////////////////////////////////////////////////////////

        private void OnLoad(object sender, EventArgs e)
        {
            m_FieldCommand.Text = Properties.Settings.Default.NANT_COMMAND;
            m_FieldParams.Text = Properties.Settings.Default.NANT_PARAMS;
            m_FieldSplit.Checked = Properties.Settings.Default.NANT_SPLIT_TARGETS;
            m_FieldGlobal.Checked = !Properties.Settings.Default.NANT_SPLIT_TARGETS;
            m_FieldAutoClear.Checked = Properties.Settings.Default.NANT_CLEAR_OUTPUT;
            m_FieldVerbose.Checked = Properties.Settings.Default.NANT_VERBOSE;
            m_FieldAutoload.Checked = Properties.Settings.Default.NANT_AUTOLOAD;
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// The button to choose a location for NAnt executable has been clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        //////////////////////////////////////////////////////////////////////////

        private void OnSelectPath(object sender, EventArgs e)
        {
            m_SelectFile.InitialDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;
            m_SelectFile.Filter = "Exe files (*.exe)|*.exe";
            m_SelectFile.FileName = m_FieldCommand.Text;

            if (m_SelectFile.ShowDialog() == DialogResult.OK)
            {
                m_FieldCommand.Text = Path.Combine(m_SelectFile.FileName, m_SelectFile.FileName);
            }
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Called on ok. Save the options.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        private void OnSave(object sender, EventArgs e)
        {
            Properties.Settings.Default.NANT_COMMAND = m_FieldCommand.Text;
            Properties.Settings.Default.NANT_PARAMS = m_FieldParams.Text;
            Properties.Settings.Default.NANT_SPLIT_TARGETS = m_FieldSplit.Checked;
            Properties.Settings.Default.NANT_CLEAR_OUTPUT = m_FieldAutoClear.Checked;
            Properties.Settings.Default.NANT_VERBOSE = m_FieldVerbose.Checked;
            Properties.Settings.Default.NANT_AUTOLOAD = m_FieldAutoload.Checked;

            Properties.Settings.Default.Save();
            Close();
        }
    }
}
