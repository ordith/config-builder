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
    public class ConfigParameterValue
    {
        [XmlAttribute("Environment")]
        public string Environment { get; set; }
        [XmlAttribute("Value")]
        public string Value { get; set; }
    }
}
