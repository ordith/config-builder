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

* Install ConfigBuilder
* Create a ConfigValues.xml file
	* Create each Template file you want and the output directory
	* Define the parameters and values for each environment
	* (Optional) Add a Working Environment for local development

### Installing ConfigBuilder

ConfigBuilder has a Nuget Package you can use to add it to your build.

	Install-Package ConfigBuilder

This will add ConfigBuilder as a build step to the project that you install the package to.

### Create ConfigValues.xml 

ConfigBuilder uses a **Values** file and any number of **Template**s that you desire.

By default, the ConfigBuilder task looks for the **Values** file relative to your project directory - **../ConfigValues.xml**. 
This normally is your root solution folder. If you want to change the location of this file, edit the path in your ConfigBuilder task in your .csproj file.

The Values file defines what templates you have and what parameter values you want to replace in those templates.

Take a look at the [Example Config Values File](/Example/ConfigValues.xml) to see the format.

To start, define a **CreateConfigTask** like the [Example Config Values File](/Example/ConfigValues.xml) and create a Template.App.Config file like the [Example Template file](/Example/Template.App.config).

Add any number of **ConfigParameter**s to the ConfigValues.xml. In your template file, reference the parameters with @{**NAME**}.

Build your project. The App.config files should be generated wherever your CreateConfigTask has defined the output folder. If you have a WorkingEnvironment and WorkingEnvironmentFolder, an App.config file should be generated there as well.


##Example

The [Example Folder](/Example/) has the `Values` file, `Template` file, and the output App.config files.

* [Example Config Values](/Example/ConfigValues.xml)
* [Example Template file](/Example/Template.App.config)
* [Example Working Environment file](/Example/App.config)
