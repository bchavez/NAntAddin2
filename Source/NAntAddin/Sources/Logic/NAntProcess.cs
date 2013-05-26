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
using System.ComponentModel;

using EnvDTE;
using EnvDTE80;

namespace NAntAddin
{
    //////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// </summary>
    //////////////////////////////////////////////////////////////////////////

    public class NAntProcess
    {
        // Private attributes
        private string m_Filename;
        private XmlNode m_TargetNode;
        private DTE2 m_ApplicationObject;
        private ViewController m_ViewController;
        private BackgroundWorker m_BackgroundWorker;
        private System.Diagnostics.Process m_NAntProcess;

        // Public events/delegate
        public event TargetCompletedHandler TargetCompleted;
        public delegate void TargetCompletedHandler(object sender, EventArgs e);

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public NAntProcess(ViewController viewController)
        {
            m_ViewController = viewController;
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public string Filename
        {
            get { return m_Filename; }
            set { m_Filename = value; }
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public DTE2 ApplicationObject
        {
            get { return m_ApplicationObject; }
            set { m_ApplicationObject = value; }
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public XmlNode TargetNode
        {
            get { return m_TargetNode; }
            set { m_TargetNode = value; }
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public bool IsWorking
        {
            get { return m_BackgroundWorker != null && m_BackgroundWorker.IsBusy; }
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public void Start()
        {
            // Initialize backround worker
            m_BackgroundWorker = new BackgroundWorker();
            m_BackgroundWorker.WorkerReportsProgress = true;
            m_BackgroundWorker.WorkerSupportsCancellation = true;
            m_BackgroundWorker.DoWork += new DoWorkEventHandler(OnStart);
            m_BackgroundWorker.ProgressChanged += new ProgressChangedEventHandler(OnProgress);
            m_BackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnComplete);

            // Run task
            m_BackgroundWorker.RunWorkerAsync();

            // Autoclear console, if required
            if (Properties.Settings.Default.NANT_CLEAR_OUTPUT)
            {
                VisualStudioUtils.GetConsole(m_ApplicationObject, "NAntAddin").Clear();
            }

            // Trace start build
            WriteConsole(Environment.NewLine + "[NAntAddin]: Target '" + m_TargetNode["name"] + "' started..." + Environment.NewLine + Environment.NewLine);
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public void Stop()
        {
            m_BackgroundWorker.CancelAsync();
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public void WriteConsole(string message)
        {
            VisualStudioUtils.GetConsole(m_ApplicationObject, "NAntAddin").OutputString(message);
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        private void OnStart(object sender, DoWorkEventArgs e)
        {
            var nantCommand   = Properties.Settings.Default.NANT_COMMAND;
            var nantArguments = string.Format(Properties.Settings.Default.NANT_PARAMS,  m_Filename, m_TargetNode["name"]);

            var workingDir = Path.GetDirectoryName( m_Filename );

            if ( !Path.IsPathRooted( nantCommand ) && !string.IsNullOrEmpty(workingDir) )
            {//if the path is not rooted, then make it relative to the mFileName path.
                nantCommand = Path.Combine( workingDir, nantCommand );
            }

            try
            {
                string nantOutput = null;

                // Create and initialize the process
                m_NAntProcess = new System.Diagnostics.Process();

                m_NAntProcess.StartInfo.UseShellExecute = false;
                m_NAntProcess.StartInfo.RedirectStandardError = true;
                m_NAntProcess.StartInfo.RedirectStandardOutput = true;
                m_NAntProcess.StartInfo.CreateNoWindow = true;
                m_NAntProcess.StartInfo.FileName = nantCommand;
                m_NAntProcess.StartInfo.WorkingDirectory = workingDir;
                m_NAntProcess.StartInfo.Arguments = nantArguments;

                // Start process
                m_NAntProcess.Start();

                // Read standard output and write string in console
                while ((nantOutput = m_NAntProcess.StandardOutput.ReadLine()) != null)
                {
                    if (m_BackgroundWorker.CancellationPending)
                    {
                        if (!m_NAntProcess.HasExited)
                        {
                            m_NAntProcess.Kill();
                            m_NAntProcess.WaitForExit();
                            e.Cancel = true;
                        }
                    }
                    else
                    {
                        nantOutput += System.Environment.NewLine;
                        m_BackgroundWorker.ReportProgress(0, nantOutput);
                    }
                }
            }
            catch (Exception e1)
            {
                // Trace exception on console
                WriteConsole("[NAntAddin]: Unexpected error occured while executing command: "
                    + Environment.NewLine
                    + "\t" + nantCommand + nantArguments
                    + Environment.NewLine
                    + Environment.NewLine
                    + "An exception has been raised with the following stacktrace:"
                    + Environment.NewLine
                    + "   " + e1.Message
                    + Environment.NewLine
                    + e1.StackTrace 
                    + Environment.NewLine
                    + Environment.NewLine
                    + "Please check that NAnt command path is properly configured within NAntAddin options."
                    + Environment.NewLine
                );
            }
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Reports background vorker progress.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //////////////////////////////////////////////////////////////////////////

        private void OnProgress(object sender, ProgressChangedEventArgs e)
        {
            string progressString = e.UserState as string;

            if (Properties.Settings.Default.NANT_VERBOSE)
                WriteConsole(progressString);
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        private void OnComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            m_BackgroundWorker = null;
            m_NAntProcess      = null;

            if (e.Cancelled)
                WriteConsole(Environment.NewLine + "[NAntAddin]: Target '" + m_TargetNode["name"] + "' aborted !" + Environment.NewLine);
            else
                WriteConsole(Environment.NewLine + "[NAntAddin]: Target '" + m_TargetNode["name"] + "' completed." + Environment.NewLine);

            // Notify listeners that the process has exited
            if (TargetCompleted != null)
                TargetCompleted.Invoke(this, new EventArgs());
        }
    }
}