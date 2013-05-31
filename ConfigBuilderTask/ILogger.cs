/*
 * ConfigBuilder
 * https://github.com/dtinteractive/config-builder
 * 
 * Copyright (c) 2013 DT Interactive
 * Licensed under the MIT license.
 */

namespace ConfigBuilderTask
{
    public interface ILogger
    {
        void LogError(string message);
        void LogWarning(string message);
        void LogMessage(string message);
    }
}
