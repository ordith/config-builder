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
	public class OrganizedParameters
	{
		private readonly SortedDictionary<string, SortedDictionary<string, string>> _data = new SortedDictionary<string, SortedDictionary<string, string>>();
		private readonly List<string> _environments = new List<string>();

		public IEnumerable<string> Environments { get { return _environments; } } 
 
		public void AddParameter(ConfigParameterValue parameter, string name)
		{
			if (!_data.ContainsKey(parameter.Environment))
			{
				_data[parameter.Environment] = new SortedDictionary<string, string>();
				_environments.Add(parameter.Environment);
			}

			_data[parameter.Environment][name] = parameter.Value;
		}

		public IDictionary<string, string> GetParametersWithNamesByEnvironment(string environment)
		{
			return _data.ContainsKey(environment) ? _data[environment] : null;
		}
	}
}
