/*
 * ConfigBuilder
 * https://github.com/dtinteractive/config-builder
 * 
 * Copyright (c) 2013 DT Interactive
 * Licensed under the MIT license.
 */

using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;

namespace ConfigBuilderTask.Schema
{
    public class CreateConfigTask
    {
        [XmlAttribute("NameFormat")]
        public string NameFormat { get; set; }
        [XmlAttribute("InputFile")]
        public string InputFile { get; set; }
		[XmlAttribute("OutputFolderFormat")]
		public string OutputFolderFormat { get; set; }
		[XmlAttribute("IncludeProjects")]
		public string IncludeProjects { get; set; }
		[XmlAttribute("ExcludeProjects")]
		public string ExcludeProjects { get; set; }


		private bool UseInclude
		{
			get { return !string.IsNullOrWhiteSpace(IncludeProjects); }
		}

	    private bool _checkedProjectList = false;
	    private string[] _projectsList;
	    private IEnumerable<string> ProjectsList
	    {
		    get
		    {
				if (!_checkedProjectList)
				{
					_checkedProjectList = true;
					if (UseInclude)
					{
						if (!string.IsNullOrWhiteSpace(IncludeProjects))
						{
							_projectsList = IncludeProjects.Split(',').Trim().ToArray();	
						}
					}
					else
					{
						if (!string.IsNullOrWhiteSpace(ExcludeProjects))
						{
							_projectsList = ExcludeProjects.Split(',').Trim().ToArray();
						}
					}
			    }

			    return _projectsList ?? new string[0];
		    }
	    }

		public bool ProjectIsIncluded(string project)
		{
			return  ProjectsList.Contains(project) == UseInclude;
		}
    }
}
