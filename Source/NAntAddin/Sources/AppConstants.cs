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
using System.Collections.Generic;
using System.Text;

namespace NAntAddin
{
    //////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Constants definition for the model of a NAntAddin.
    /// </summary>
    /// <seealso cref="NAntTree"/>
    //////////////////////////////////////////////////////////////////////////

    public static class AppConstants
    {
        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Xml tree constants.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public const string NANT_XML_TARGET      = "target";
        public const string NANT_XML_INCLUDE     = "include";
        public const string NANT_XML_PROPERTY    = "property";
        public const string NANT_XML_DESCRIPTION = "description";
        public const string NANT_XML_BUILDFILE   = "buildfile";

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Index of icon properties in TreeView ImageList.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public static int ICON_NANT            = 0;
        public static int ICON_PROPERTIES      = 1;
        public static int ICON_TARGETS_PUBLIC  = 2;
        public static int ICON_TARGETS_PRIVATE = 3;
        public static int ICON_TARGETS_ALL     = 4;
        public static int ICON_TARGET          = 5;
        public static int ICON_PROPERTY        = 6;
        public static int ICON_TASK            = 7;
        public static int ICON_ERROR           = 8;
    }
}
