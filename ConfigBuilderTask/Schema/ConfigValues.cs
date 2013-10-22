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
    public class ConfigValues
    {
	    private string _workingEnvironment;

	    [XmlAttribute("WorkingEnvironment")]
        public string WorkingEnvironment
	    {
		    get { return _workingEnvironment; }
		    set { _workingEnvironment = value.ToLowerInvariant(); }
	    }

	    [XmlAttribute("WorkingEnvironmentFolder")]
	    public string WorkingEnvironmentFolder { get; set; }
        public CreateConfigTask[] Tasks { get; set; }
        public ConfigParameter[] Parameters { get; set; }

		public bool IsWorkingEnvironmentEnabled()
		{
			return !string.IsNullOrWhiteSpace(WorkingEnvironment) && !string.IsNullOrWhiteSpace(WorkingEnvironmentFolder);
		}
    }
}
