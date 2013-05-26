﻿//////////////////////////////////////////////////////////////////////////
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

    partial class AboutBox : Form
    {
        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Default constructor.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public AboutBox()
        {
            InitializeComponent();
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
            // Get the assembly version
            Version addinVersion = Assembly.GetExecutingAssembly().GetName().Version;
            m_LabelVersion.Text = "Version " + addinVersion.ToString();
        }
    }
}
