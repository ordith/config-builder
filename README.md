config-builder
==============

## What is it?

ConfigBuilder is a custom MSBuild task that can be used to build configs based on a template and parameter values that you define.

You can define parameter values per environment, define a selected environment to use, and define templates that the configs are based on.

ConfigBuilder is built to be simple- it replaces parameneters using a token. 

In contrast to Microsoft's configuration templating: 
*It does not require advanced knowledge of XSLT to create a template-based config. 
*All of your parameter values are in one, readable, place.

## Getting Started

ConfigBuilder has a Nuget Package you can use to add it to your build.

	Install-Package ConfigBuilder

This will add ConfigBuilder as a build step to the project that you install the package to.

ConfigBuilder uses a `Values` file and any number of `Template`s that you desire.

By default, the `Values` file is relative to your project directory - `../ConfigValues.xml`. By default, this would be in your root solution folder.


##Example

The [Example Folder](/Example/) has the `Values` file, `Template` file, and the output App.config files.

* [Example Config Values](/Example/ConfigValues.xml)
* [Example Template file](/Example/Template.App.config)
* [Example Working Environment file](/Example/App.config)
