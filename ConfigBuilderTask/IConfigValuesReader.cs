/*
 * ConfigBuilder
 * https://github.com/dtinteractive/config-builder
 * 
 * Copyright (c) 2013 DT Interactive
 * Licensed under the MIT license.
 */

using ConfigBuilderTask.Schema;

namespace ConfigBuilderTask
{
    public interface IConfigValuesReader
    {
        ConfigValues ReadTemplate(string fileName);
    }
}
