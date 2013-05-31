/*
 * ConfigBuilder
 * https://github.com/dtinteractive/config-builder
 * 
 * Copyright (c) 2013 DT Interactive
 * Licensed under the MIT license.
 */

using System.IO;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace ConfigBuilderTask
{
    public class ConfigBuilder : Task, ILogger
    {
        private readonly IConfigValuesReader _templateReader;
        private readonly ICreateConfigTaskHandler _templateTaskHandler;
	    private readonly IParameterOrganizer _parameterOrganizer;

        [Required]
        public string ValuesFilePath { get; set; }
		[Required]
		public string ProjectName { get; set; }

        public ConfigBuilder()
        {
            //Dependency Injection needed??
            _templateReader = new ConfigValuesReader(this);
            _templateTaskHandler = new CreateConfigTaskHandler(this);
	        _parameterOrganizer = new ParameterOrganizer();
        }

        public override bool Execute()
        {
            var template = _templateReader.ReadTemplate(ValuesFilePath);

	        DirectoryInfo directory;
			if (template.IsWorkingEnvironmentEnabled())
			{
				directory = new DirectoryInfo(template.WorkingEnvironmentFolder);

				if (!directory.Exists)
				{
					directory.Create();
				}
			}
			else
			{
				directory = null;
			}

	        var organizedParameters = _parameterOrganizer.OrganizeParameters(template.Parameters);
			
            foreach (var task in template.Tasks)
			{
				if (string.IsNullOrWhiteSpace(ProjectName) || task.ProjectIsIncluded(ProjectName))
				{
					_templateTaskHandler.HandleTask(task, organizedParameters, template.WorkingEnvironment, directory);	
				}
            }

            return true;
        }

        public void LogError(string message)
        {
            Log.LogError(message);
        }

        public void LogWarning(string message)
        {
            Log.LogWarning(message);
        }

        public void LogMessage(string message)
        {
            Log.LogMessage(message);
        }
    }
}
