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
	public interface ITemplateFiller
	{
		string FillTemplate(string templateContent, IDictionary<string, string> valuesByName);
	}
}
