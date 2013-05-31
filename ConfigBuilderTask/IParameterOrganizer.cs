/*
 * ConfigBuilder
 * https://github.com/dtinteractive/config-builder
 * 
 * Copyright (c) 2013 DT Interactive
 * Licensed under the MIT license.
 */

using System.Collections.Generic;
using ConfigBuilderTask.Schema;

namespace ConfigBuilderTask
{
	public interface IParameterOrganizer
	{
		OrganizedParameters OrganizeParameters(IEnumerable<ConfigParameter> parameters);
	}
}
