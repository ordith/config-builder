/*
 * ConfigBuilder
 * https://github.com/dtinteractive/config-builder
 * 
 * Copyright (c) 2013 DT Interactive
 * Licensed under the MIT license.
 */

using System.Xml.Serialization;

namespace ConfigBuilderTask.Schema
{
    public class ConfigParameter
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }
        public ConfigParameterValue[] Values { get; set; }
    }
}
