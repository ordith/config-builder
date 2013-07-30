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
		private readonly Dictionary<string, string> _defaultData = new Dictionary<string, string>();
		private readonly Dictionary<string, Dictionary<string, string>> _data = new Dictionary<string, Dictionary<string, string>>();
		private readonly List<string> _environments = new List<string>();

		public IEnumerable<string> Environments { get { return _environments; } }

		public void AddDefault(string parameterType, string defaultValue)
		{
			_defaultData[parameterType] = defaultValue;
		}

		public void FillDefaults()
		{
			foreach (var defaultNameAndValue in _defaultData)
			{
				foreach (var environmentParameterCollection in _data)
				{
					//If the environment's parameters don't contain a parameter name, fill it with the default value
					if (!environmentParameterCollection.Value.ContainsKey(defaultNameAndValue.Key))
					{
						environmentParameterCollection.Value[defaultNameAndValue.Key] = defaultNameAndValue.Value;
					}
				}
			}
		}

		public void AddParameter(ConfigParameterValue parameter, string name)
		{
			if (!_data.ContainsKey(parameter.Environment))
			{
				_data[parameter.Environment] = new Dictionary<string, string>();
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
