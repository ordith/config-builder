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
	public class ParameterOrganizer : IParameterOrganizer
	{
		public OrganizedParameters OrganizeParameters(IEnumerable<ConfigParameter> parameters)
		{
			var returnValue = new OrganizedParameters();

			foreach (var parameter in parameters)
			{
				if (parameter.DefaultValue != null)
				{
					returnValue.AddDefault(parameter.Name, parameter.DefaultValue);
				}

				foreach (var value in parameter.Values)
				{
					returnValue.AddParameter(value, parameter.Name);
				}
			}

			returnValue.FillDefaults();

			return returnValue;
		}
	}
}
