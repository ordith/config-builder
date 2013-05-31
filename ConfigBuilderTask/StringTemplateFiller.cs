/*
 * ConfigBuilder
 * https://github.com/dtinteractive/config-builder
 * 
 * Copyright (c) 2013 DT Interactive
 * Licensed under the MIT license.
 */

using System.Collections.Generic;

namespace ConfigBuilderTask
{
	public class StringTemplateFiller : ITemplateFiller
	{
		public string FillTemplate(string templateContent, IDictionary<string, string> valuesByName)
		{
			var currentContent = templateContent;

			foreach (var param in valuesByName)
			{
				currentContent = currentContent.Replace("@{" + param.Key + "}", param.Value);
			}

			return currentContent;
		}
	}
}
