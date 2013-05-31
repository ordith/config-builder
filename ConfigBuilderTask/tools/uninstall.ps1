param($installPath, $toolsPath, $package, $project)

$buildProject = Get-MsBuildProject

$usingTask = $($buildProject.Xml.UsingTasks | where { $_.TaskName -ieq "ConfigBuilder" })
$target = $($buildProject.Xml.Targets | where { $_.Name -ieq "BuildConfig" })

$buildProject.Xml.RemoveChild($target)
$buildProject.Xml.RemoveChild($usingTask)

$buildProject.Save()

$project.Save()