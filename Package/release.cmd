@echo off
set TargetFramework=%1
set ProjectName=%2

rem workaround, part 1/2, to ensure that *.nuspec files being included in the nupkg as *.nuspectemplate using nuget.exe
rem in nuget.exe source code, there is a hardcoded list of file extensions that are always excluded when a package is built, regardless of the `-NoDefaultExcludes` option.  
rem These extensions include: `.nupkg`, `.snupkg`, `.nuspec`, `.nupkg.sha512`, `.snupkg.sha512`, `.snk`  
for /r "..\Client\wwwroot\Themes\Templates" %%f in (*.nuspec) do ren "%%f" "%%~nf.nuspectemplate"

del "*.nupkg"
"..\..\oqtane.framework\oqtane.package\nuget.exe" pack %ProjectName%.nuspec -NoDefaultExcludes -Properties targetframework=%TargetFramework%;projectname=%ProjectName%
xcopy "*.nupkg" "..\..\oqtane.framework\Oqtane.Server\Packages\" /Y