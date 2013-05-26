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
using System.Text;
using System.ComponentModel;
using System.Configuration;
using System.Collections.Generic;

using EnvDTE;
using EnvDTE80;

namespace NAntAddin
{
    //////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Controller of the NAnt Addin.
    /// </summary>
    //////////////////////////////////////////////////////////////////////////

    public class ViewController
    {
        // Private attributes
        private string m_Filename;
        private XmlTree m_NantTree;
        private XmlNode m_CurrentNode;
        private DTE2 m_ApplicationObject;
        private NAntProcess m_NAntProcess;

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Default constructor
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public ViewController()
        {
            m_NAntProcess = new NAntProcess(this);
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Get or set current DTE2 attribute (extensibility instance).
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public DTE2 ApplicationObject
        {
            get { return m_ApplicationObject; }
            set 
            {
                // Propagate value to NAntProcess aggregate
                m_ApplicationObject = value;
                m_NAntProcess.ApplicationObject = value;
            }
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Get or set NAnt the current script file.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public string Filename
        {
            get { return m_Filename; }
            set { m_Filename = value; }
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Get the NAntTree of the NAnt script file.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public XmlTree NAntTree
        {
            get { return m_NantTree; }
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Get the NAntTree of the NAnt script file.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public NAntProcess NAntProcess
        {
            get { return m_NAntProcess; }
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Get the current active NAntNode.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public XmlNode CurrentNode
        {
            get { return m_CurrentNode; }
            set { m_CurrentNode = value; }
        }


        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Get the state of the controller.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public bool IsWorking
        {
            get { return m_NAntProcess.IsWorking; }
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Get the filter required to select all nant files
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public string FileFilter
        {
            get
            {
                return 
                    "Build files (*.build)|*.build|"
                    + "NAnt files (*.nant)|*.nant|"
                    + "Xml files (*.xml)|*.xml|"
                    + "All files  (*.*)|*.*";
            }
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Get the solution folder, or null if no solution loaded
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public string SolutionFolder
        {
            get
            {
                Solution2 solution = VisualStudioUtils.GetSolution(m_ApplicationObject);

                if (solution == null)
                    return null;

                return solution.FullName;
            }
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Return the default build script
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public string DefaultBuildFile
        {
            get
            {
                string filename = null;

                // First check if a solultion is loaded
                Solution2 solution = VisualStudioUtils.GetSolution(m_ApplicationObject);

                if (solution == null)
                    return null;

                // Get all build files in solution
                string[] buildFiles = Directory.GetFiles(Path.GetDirectoryName(solution.FullName), "*.build", SearchOption.AllDirectories);

                foreach (string file in buildFiles)
                {
                    if (file.ToLower().EndsWith("default.build"))
                    {
                        filename = file;
                        break;
                    }
                }

                if (m_Filename == null && buildFiles.Length > 0)
                {
                    filename = buildFiles[0];
                }

                return filename;
            }
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Load NAnt script file in the controller.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public void LoadFile(string filename)
        {
            if (m_Filename != null)
            {
                m_NantTree = XmlTreeFactory.CreateXmlTree(filename, false);
            }
            else
            {
                m_NantTree = null;
            }
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Select the line of NAntNode in the VisualStudio editor.
        /// </summary>
        /// <param name="nantNode">The node</param>
        //////////////////////////////////////////////////////////////////////////

        public void SelectNodeLine()
        {
            // First load the file into VisualStudio
            VisualStudioUtils.ShowFile(m_ApplicationObject, m_Filename);

            // Refocus AddIn (lost while opening the file)
            VisualStudioUtils.ShowWindow(m_ApplicationObject, "NAntAddin");

            // Display the node's line within the file
            VisualStudioUtils.ShowLine(m_ApplicationObject, m_Filename, m_CurrentNode.LineNumber, false);

            // Finally display the document
            VisualStudioUtils.ShowDocument(m_ApplicationObject, m_Filename);
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Initialize the thread for NAnt process.
        /// </summary>
        /// <param name="targetNode">The target to run.</param>
        //////////////////////////////////////////////////////////////////////////

        public void StartTarget()
        {
            if (!m_NAntProcess.IsWorking)
            {
                m_NAntProcess.Filename   = m_Filename;
                m_NAntProcess.TargetNode = m_CurrentNode;

                // Sets focus to console
                VisualStudioUtils.ShowWindow(m_ApplicationObject, "Output");

                m_NAntProcess.Start();
            }
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Stop the current NAnt process.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public void StopTarget()
        {
            if (m_NAntProcess.IsWorking)
                m_NAntProcess.Stop();
        }
    }
}
