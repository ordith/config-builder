/*
 * ConfigBuilder
 * https://github.com/dtinteractive/config-builder
 * 
 * Copyright (c) 2013 DT Interactive
 * Licensed under the MIT license.
 */

using System.IO;
using System.Xml.Serialization;
using ConfigBuilderTask.Schema;

namespace ConfigBuilderTask
{
    public class ConfigValuesReader : IConfigValuesReader
    {
        private readonly ILogger _logger;

        public ConfigValuesReader(ILogger logger)
        {
            _logger = logger;
        }

        public ConfigValues ReadTemplate(string filePath)
        {
            var writer = new XmlSerializer(typeof(ConfigValues));

            ConfigValues returnValue;
            using(var fileStream = new StreamReader(filePath))
            {
                returnValue = (ConfigValues)writer.Deserialize(fileStream);
                fileStream.Close();
            }

            return returnValue;
        }
    }
}
