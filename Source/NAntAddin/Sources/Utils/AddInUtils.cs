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

    public static class AddInUtils
    {
        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Create a view of the addin
        /// The view should be a UserControl which will be created directly
        /// embedded within the Window representing the AddIn in VisualStudio.
        /// the Window container of the Addin on screee,
        /// </summary>
        /// <param name="addInApplication"></param>
        /// <param name="addInInstance"></param>
        /// <param name="addInView"></param>
        /// <param name="viewGuid"></param>
        /// <param name="viewCaption"></param>
        /// <param name="viewClass"></param>
        /// <param name="viewIcon"></param>
        /// <returns></returns>
        //////////////////////////////////////////////////////////////////////////

        public static Window CreateAddinView(DTE2 addInApplication, AddIn addInInstance, ref object addInView, string viewGuid, string viewCaption, Type viewClass, Bitmap viewIcon)
        {
            Windows2 dteWindows = (Windows2) addInApplication.Windows;
            Window addInWindow = dteWindows.CreateToolWindow2(addInInstance, viewClass.Assembly.Location, viewClass.FullName, viewCaption, viewGuid, ref addInView);

            if (addInWindow != null)
            {
                // Set the tab icon
                if (viewIcon != null)
                {
                    StdPicture tabPicture = AddInUtils.CreatePicture(viewIcon);
                    addInWindow.SetTabPicture(tabPicture);
                }

                addInWindow.Linkable   = true;
                addInWindow.IsFloating = false;
                addInWindow.Activate();
            }

            return addInWindow;
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmapIcon"></param>
        /// <returns></returns>
        //////////////////////////////////////////////////////////////////////////

        public static StdPicture CreatePicture(Bitmap bitmapIcon)
        {
            return (StdPicture)AxHostWrapper.GetOlePicture(bitmapIcon); ;
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Private internal class exploiting protected method GetIPictureDispFromPicture
        /// implemented by AxHost to convert activex images (workaround).
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        private class AxHostWrapper : AxHost
        {
            public AxHostWrapper() : base(null) { }
            public static IPictureDisp GetOlePicture(Image image)
            {
                return (IPictureDisp)AxHost.GetIPictureDispFromPicture(image);
            }
        }
    }
}
