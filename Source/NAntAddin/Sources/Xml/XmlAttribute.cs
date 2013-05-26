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
using System.ComponentModel;

namespace NAntAddin
{
    //////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Simple implementation of the PropertyDescriptor abstract class.
    /// This class is responsible to describe a single property visualized
    /// by the PropertyGrid as simple row (property-name and property-value). 
    /// class PropertyDescriptor.
    /// </summary>
    //////////////////////////////////////////////////////////////////////////

    internal class XmlAttribute : PropertyDescriptor
    {
        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Owner of the key.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        private IDictionary<string, object> m_Dictionary;

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Key to describe.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        private string m_Key;

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Initialize the key descriptor.
        /// </summary>
        /// <param name="dictionary">Dictionary of attributes.</param>
        /// <param name="key">The key.</param>
        //////////////////////////////////////////////////////////////////////////

        internal XmlAttribute(IDictionary<string, object> dictionary, string key)
            : base(key, null)
        {
            this.m_Dictionary = dictionary;
            this.m_Key = key;
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Get the type of the dictionary entry for key.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public override Type PropertyType
        {
            get { return m_Dictionary[m_Key].GetType(); }
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Set the value for the entry key.
        /// </summary>
        /// <param name="component">Unused.</param>
        /// <param name="value">The value of the key entry.</param>
        //////////////////////////////////////////////////////////////////////////

        public override void SetValue(object component, object value)
        {
            m_Dictionary[m_Key] = value;
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Return the value for the entry key.
        /// </summary>
        /// <param name="component">Unused.</param>
        /// <returns>The value of the key entry.</returns>
        //////////////////////////////////////////////////////////////////////////

        public override object GetValue(object component)
        {
            return m_Dictionary[m_Key];
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Determines whether the key is read only.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public override bool IsReadOnly
        {
            get { return false; }
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Get the Component Type.
        /// </summary>
        //////////////////////////////////////////////////////////////////////////

        public override Type ComponentType
        {
            get { return null; }
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Determines whether the component can be reseted.
        /// </summary>
        /// <param name="component">Unused.</param>
        /// <returns>False.</returns>
        //////////////////////////////////////////////////////////////////////////

        public override bool CanResetValue(object component)
        {
            return false;
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Resest the component.
        /// </summary>
        /// <param name="component">Unused.</param>
        //////////////////////////////////////////////////////////////////////////

        public override void ResetValue(object component)
        {
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Determines whether the component should be serialized.
        /// </summary>
        /// <param name="component">Unused.</param>
        /// <returns>False.</returns>
        //////////////////////////////////////////////////////////////////////////

        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
    }
}
