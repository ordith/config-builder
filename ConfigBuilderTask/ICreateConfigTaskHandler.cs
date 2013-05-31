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
    public interface ICreateConfigTaskHandler
    {
	    void HandleTask(CreateConfigTask task, OrganizedParameters parameters, string selectedEnvironment,
	                      DirectoryInfo selectedEnvironmentFolder);
    }
}
