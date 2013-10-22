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
	    private string _environment;

	    [XmlAttribute("Environment")]
        public string Environment
	    {
		    get { return _environment; }
		    set { _environment = value.ToLowerInvariant(); }
	    }

	    [XmlAttribute("Value")]
        public string Value { get; set; }
    }
}
