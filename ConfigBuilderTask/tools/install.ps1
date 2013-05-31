param($installPath, $toolsPath, $package, $project)

Set-Location (Get-ChildItem $Project.FullName).DirectoryName
$relInstallPath = $installPath | Resolve-Path -Relative

$buildProject = Get-MsBuildProject
$usingTask2 = $buildProject.Xml.AddUsingTask("ConfigBuilder", $relInstallPath + "\lib\ConfigBuilderTask.dll", $null)

$target = $buildProject.Xml.AddTarget("BuildConfig")

$target.BeforeTargets = "BeforeBuild"

$task = $target.AddTask("ConfigBuilder")

$task.SetParameter("ValuesFilePath", "../ConfigValues.xml")
$task.SetParameter("ProjectName", "`$(MSBuildProjectName)")

$buildProject.Save()

$project.Save()