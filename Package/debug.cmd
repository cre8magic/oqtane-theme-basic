@echo off
set TargetFramework=%1
set ProjectName=%2

rem workaround, part 2/2, to ensure that *.nuspectemplate files are renamed back to *.nuspec
for /r "..\Client\wwwroot\Themes\Templates" %%f in (*.nuspectemplate) do ren "%%f" "%%~nf.nuspec"

xcopy "..\Client\bin\Debug\%TargetFramework%\%ProjectName%.Client.Oqtane.dll" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\%TargetFramework%\" /Y
xcopy "..\Client\bin\Debug\%TargetFramework%\%ProjectName%.Client.Oqtane.pdb" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\%TargetFramework%\" /Y
xcopy "..\Client\wwwroot\*" "..\..\oqtane.framework\Oqtane.Server\wwwroot\" /Y /S /I