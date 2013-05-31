/*
 * ConfigBuilder
 * https://github.com/dtinteractive/config-builder
 * 
 * Copyright (c) 2013 DT Interactive
 * Licensed under the MIT license.
 */

using System.IO;
using ConfigBuilderTask.Schema;

namespace ConfigBuilderTask
{
    public class CreateConfigTaskHandler : ICreateConfigTaskHandler
    {
        private readonly ILogger _logger;
	    private readonly ITemplateFiller _templateFiller;

        public CreateConfigTaskHandler(ILogger logger)
        {
            _logger = logger;
			_templateFiller = new StringTemplateFiller();
        }

        public void HandleTask(CreateConfigTask task, OrganizedParameters parameters, string workingEnvironment, DirectoryInfo workingEnvironmentFolder)
        {
	        string fileContents = ReadFile(task);
			if (string.IsNullOrWhiteSpace(fileContents))
			{
				_logger.LogError(string.Format("Missing Input File: {0}", task.InputFile));
				return;
			}
			
			foreach (var environment in parameters.Environments)
            {
	            string environmentDirectory = string.Format(task.OutputFolderFormat, environment);
				var environmentBaseFileName = string.Format(task.NameFormat, environment);
	            string environmentFileName = environmentDirectory + environmentBaseFileName;

				var filesDirectory = new FileInfo(environmentFileName).Directory;

				if (!filesDirectory.Exists)
				{
					filesDirectory.Create();
				}

				string currentContent = _templateFiller.FillTemplate(fileContents, parameters.GetParametersWithNamesByEnvironment(environment));

                using (var writer = new StreamWriter(environmentFileName))
                {
                    writer.Write(currentContent);
                    writer.Close();
                }

				if (workingEnvironmentFolder != null && environment == workingEnvironment)
				{
					var selectedEnvironmentFileName = Path.Combine(workingEnvironmentFolder.FullName, environmentBaseFileName);

					using (var writer = new StreamWriter(selectedEnvironmentFileName))
					{
						writer.Write(currentContent);
						writer.Close();
					}
				}
            }
        }

		private string ReadFile(CreateConfigTask task)
		{
			string fileContents = string.Empty;

			if ((new FileInfo(task.InputFile)).Exists)
			{
				using (var reader = new StreamReader(task.InputFile))
				{
					fileContents = reader.ReadToEnd();
					reader.Close();
				}
			}

			return fileContents;
		}
    }
}
