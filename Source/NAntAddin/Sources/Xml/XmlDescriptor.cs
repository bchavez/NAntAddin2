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
    /// This class implements everything required to describe a nant-node
    /// and its attributes. It implements the ICustomTypeDescriptor and can
    /// be used to display an nant-node within a PropertyGrid.
    /// </summary>
    //////////////////////////////////////////////////////////////////////////

    internal class XmlDescriptor : ICustomTypeDescriptor
    {
        // Private attributes
        private IDictionary<string, object> m_Dictionary;

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Initialize an adpater for a XmlNode attached to TreeNode
        /// </summary>
        /// <param name="node">Xml node to adapt</param>
        //////////////////////////////////////////////////////////////////////////

        internal XmlDescriptor(XmlNode node)
        {
            m_Dictionary = new Dictionary<string, object>();
            ICollection<string> attributes = node.Attributes;

            // Extract all node's attributes
            foreach (string attribute in attributes)
                m_Dictionary.Add(attribute, node[attribute]);
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Return the component name.
        /// </summary>
        /// <returns>The component name.</returns>
        //////////////////////////////////////////////////////////////////////////

        public string GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Return the default event.
        /// </summary>
        /// <returns>The default event descriptor.</returns>
        //////////////////////////////////////////////////////////////////////////

        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Return the class name.
        /// </summary>
        /// <returns>The class name.</returns>
        //////////////////////////////////////////////////////////////////////////

        public string GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Return the events for attributes.
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <returns>The event descriptor collection.</returns>
        //////////////////////////////////////////////////////////////////////////

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Return the events.
        /// </summary>
        /// <returns>The event descriptor collection.</returns>
        //////////////////////////////////////////////////////////////////////////

        EventDescriptorCollection System.ComponentModel.ICustomTypeDescriptor.GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Return the converter.
        /// </summary>
        /// <returns>The type converter.</returns>
        //////////////////////////////////////////////////////////////////////////

        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Return the property owner.
        /// </summary>
        /// <param name="propDescriptor">The property descriptor.</param>
        /// <returns>Return the dicionary.</returns>
        //////////////////////////////////////////////////////////////////////////

        public object GetPropertyOwner(PropertyDescriptor propDescriptor)
        {
            return m_Dictionary;
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Return the attributes.
        /// </summary>
        /// <returns>The attribute collection.</returns>
        //////////////////////////////////////////////////////////////////////////

        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Return the editor.
        /// </summary>
        /// <param name="editorBaseType">The base type editor.</param>
        /// <returns>The editor.</returns>
        //////////////////////////////////////////////////////////////////////////

        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Return the default property.
        /// </summary>
        /// <returns>null</returns>
        //////////////////////////////////////////////////////////////////////////

        public PropertyDescriptor GetDefaultProperty()
        {
            return null;
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Return the properties.
        /// </summary>
        /// <returns>The property descriptor collection.</returns>
        //////////////////////////////////////////////////////////////////////////

        PropertyDescriptorCollection System.ComponentModel.ICustomTypeDescriptor.GetProperties()
        {
            return ((ICustomTypeDescriptor)this).GetProperties(new Attribute[0]);
        }

        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Return a custom collection of property descriptor.
        /// </summary>
        /// <param name="attributes">Unused</param>
        /// <returns>The custom property descriptor collection.</returns>
        //////////////////////////////////////////////////////////////////////////

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            List<XmlAttribute> descriptors = new List<XmlAttribute>();

            // For each attribute, create a property-descriptor
            foreach (string key in m_Dictionary.Keys)
                descriptors.Add(new XmlAttribute(m_Dictionary, key));

            // Create a property-descriptor collection
            return new PropertyDescriptorCollection(descriptors.ToArray());
        }
    }
}
