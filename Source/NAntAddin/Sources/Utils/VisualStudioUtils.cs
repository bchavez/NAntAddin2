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
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;

using EnvDTE;
using EnvDTE80;
using stdole;

namespace NAntAddin
{
    //////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// </summary>
    //////////////////////////////////////////////////////////////////////////

    public static class VisualStudioUtils
    {
        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public static Solution2 GetSolution(DTE2 applicationObject)
        {
            Solution2 solution = applicationObject.Solution as Solution2;
            
            if (solution.IsOpen)
                return applicationObject.Solution as Solution2;

            return null;
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Open a file in the VisualStudio editor.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public static void ShowFile(DTE2 applicationObject, string filename)
        {
            applicationObject.ItemOperations.OpenFile(filename, EnvDTE.Constants.vsViewKindAny);
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public static void ShowWindow(DTE2 applicationObject, string windowTitle)
        {
            if (windowTitle == "Output")
                applicationObject.Windows.Item(Constants.vsWindowKindOutput).Activate();
            else
                applicationObject.Windows.Item(windowTitle).Activate();
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public static void ShowDocument(DTE2 applicationObject, string documentTitle)
        {
            applicationObject.Documents.Item(documentTitle).Activate();
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Activate the console.
        /// </summary>
        /// <param name="title">The title of the output window.</param>
        //////////////////////////////////////////////////////////////////////////

        public static void ShowErrors(DTE2 applicationObject)
        {
            applicationObject.ToolWindows.ErrorList.Parent.Activate();
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Show the editor with specified file and select specified line.
        /// The file must be opened.
        /// </summary>
        /// <param name="title">The title of the addin.</param>
        /// <param name="fileName">The line to show.</param>
        /// <param name="lineNumber">The file name.</param>
        //////////////////////////////////////////////////////////////////////////

        public static void ShowLine(DTE2 applicationObject, string filename, int lineNumber, bool selectLine)
        {
            if (lineNumber > 0)
            {
                try
                {
                    // Retrieve the document
                    Document document = applicationObject.Documents.Item(filename);

                    // Select the node's line
                    TextSelection selection = (TextSelection)document.Selection;
                    selection.GotoLine(lineNumber, selectLine);
                }
                catch (ArgumentException)
                {
                    // Do nothing
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public static OutputWindowPane GetConsole(DTE2 applicationObject, string title)
        {
            OutputWindow outputWindow = applicationObject.ToolWindows.OutputWindow;

            // Scan all output panes
            foreach (OutputWindowPane outputPane in outputWindow.OutputWindowPanes)
            {
                if (outputPane.Name == title)
                    return outputPane;
            }

            // If the pane is not found, create a new one
            return outputWindow.OutputWindowPanes.Add(title);
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Return the solution configuration mode (Debug, Release...)
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public static string GetSolutionConfiguration(DTE2 applicationObject)
        {
            string configurationMode = null;

            if (applicationObject.Solution != null
                && applicationObject.Solution.SolutionBuild != null
                && applicationObject.Solution.SolutionBuild.ActiveConfiguration != null)
            {
                configurationMode = applicationObject.Solution.SolutionBuild.ActiveConfiguration.Name;
            }

            return configurationMode;
        }
    }
}
