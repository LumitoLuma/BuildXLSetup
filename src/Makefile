all:
   nuget.exe restore
   cd BuildXL.Setup.BuildTasks
   msbuild.exe /m /p:Configuration=Debug /p:Platform=x64 /t:Restore
   msbuild.exe /m /p:Configuration=Debug /p:Platform=x64
   cd..
   cd BuildXL.ShellResources
   if not exist obj\x64\Debug\ (mkdir obj\x64\Debug\)
   if not exist bin\x64\Debug\ (mkdir bin\x64\Debug\)
   rc.exe /D _UNICODE /D UNICODE /l"0x0409" /fo"obj\x64\Debug\BuildXL.ShellResources.res" BuildXL.ShellResources.rc
   link.exe /ERRORREPORT:QUEUE /OUT:"bin\x64\Debug\BuildXL.ShellResources.dll" /INCREMENTAL kernel32.lib user32.lib gdi32.lib winspool.lib comdlg32.lib advapi32.lib shell32.lib ole32.lib oleaut32.lib uuid.lib odbc32.lib odbccp32.lib /MANIFEST /MANIFESTUAC:"level='asInvoker' uiAccess='false'" /manifest:embed /DEBUG:FASTLINK /PDB:"bin\x64\Debug\BuildXL.ShellResources.pdb" /SUBSYSTEM:WINDOWS /TLBID:1 /NOENTRY /DYNAMICBASE /NXCOMPAT /IMPLIB:"bin\x64\Debug\BuildXL.ShellResources.lib" /MACHINE:X64 /DLL obj\x64\Debug\BuildXL.ShellResources.res
   cd..
   cd BuildXL.Setup
   if not exist obj\x64\Debug\ (mkdir obj\x64\Debug\)
   if not exist obj\x64\Debug\moved-aside\ (mkdir obj\x64\Debug\moved-aside\)
   if not exist bin\x64\Debug\ (mkdir bin\x64\Debug\)
   ..\BuildXL.Setup.BuildTasks\bin\x64\Debug\netstandard2.0\NuGet.exe install -OutputDirectory obj\x64\Debug\BxlNuGet -Source https://pkgs.dev.azure.com/ms/BuildXL/_packaging/BuildXL/nuget/v3/index.json Microsoft.BuildXL.win-x64 -Version 0.1.0-20201107.0
   move obj\x64\Debug\BxlNuGet\Microsoft.BuildXL.win-x64.0.1.0-20201107.0\Microsoft.BuildXL.win-x64.0.1.0-20201107.0.nupkg obj\x64\Debug\moved-aside\Microsoft.BuildXL.win-x64.0.1.0-20201107.0.nupkg >NUL 2>NUL
   del /s /f /q obj\x64\Debug\BxlNuGet\Microsoft.BuildXL.win-x64.0.1.0-20201107.0\*.pdb >NUL 2>NUL
   "C:\Program Files (x86)\WiX Toolset v3.11\bin\Heat.exe" dir obj\x64\Debug\BxlNuGet\Microsoft.BuildXL.win-x64.0.1.0-20201107.0 -cg BuildXL.NuGet -dr INSTALLFOLDER -scom -sreg -srd -var var.BxlNuGetDir -ag -sfrag -out obj\x64\Debug\_BuildXL.NuGet_dir.wxs
   "C:\Program Files (x86)\WiX Toolset v3.11\bin\candle.exe" -dBxlNuGetDir=obj\x64\Debug\BxlNuGet\Microsoft.BuildXL.win-x64.0.1.0-20201107.0 -dConfiguration=Debug -dOutDir=bin\x64\Debug\ -dPlatform=x64 -dProjectDir=. -dProjectExt=.wixproj -dProjectFileName=BuildXL.Setup.wixproj -dProjectName=BuildXL.Setup -dProjectPath=.\BuildXL.Setup.wixproj -dTargetDir=.\bin\x64\Debug\ -dTargetExt=.msi -dTargetFileName=BuildXL.Setup.msi -dTargetName=BuildXL.Setup -dTargetPath=.\bin\x64\Debug\BuildXL.Setup.msi -dBuildXL.ShellResources.Configuration=Debug -d"BuildXL.ShellResources.FullConfiguration=Debug|x64" -dBuildXL.ShellResources.Platform=x64 -dBuildXL.ShellResources.ProjectDir=..\BuildXL.ShellResources\ -dBuildXL.ShellResources.ProjectExt=.vcxproj -dBuildXL.ShellResources.ProjectFileName=BuildXL.ShellResources.vcxproj -dBuildXL.ShellResources.ProjectName=BuildXL.ShellResources -dBuildXL.ShellResources.ProjectPath=..\BuildXL.ShellResources\BuildXL.ShellResources.vcxproj -dBuildXL.ShellResources.TargetDir=..\BuildXL.ShellResources\bin\x64\Debug\ -dBuildXL.ShellResources.TargetExt=.dll -dBuildXL.ShellResources.TargetFileName=BuildXL.ShellResources.dll -dBuildXL.ShellResources.TargetName=BuildXL.ShellResources -dBuildXL.ShellResources.TargetPath=..\BuildXL.ShellResources\bin\x64\Debug\BuildXL.ShellResources.dll -out obj\x64\Debug\ -arch x64 -ext "C:\Program Files (x86)\WiX Toolset v3.11\bin\WixUtilExtension.dll" -ext "C:\Program Files (x86)\WiX Toolset v3.11\bin\WixUIExtension.dll" Product.wxs ShellIntegration.wxs obj\x64\Debug\_BuildXL.NuGet_dir.wxs
   "C:\Program Files (x86)\WiX Toolset v3.11\bin\Light.exe" -out .\bin\x64\Debug\BuildXL.Setup.msi -pdbout .\bin\x64\Debug\BuildXL.Setup.wixpdb -cultures:null -ext "C:\Program Files (x86)\WiX Toolset v3.11\bin\WixUtilExtension.dll" -ext "C:\Program Files (x86)\WiX Toolset v3.11\bin\WixUIExtension.dll" -contentsfile obj\x64\Debug\BuildXL.Setup.wixproj.BindContentsFileListnull.txt -outputsfile obj\x64\Debug\BuildXL.Setup.wixproj.BindOutputsFileListnull.txt -builtoutputsfile obj\x64\Debug\BuildXL.Setup.wixproj.BindBuiltOutputsFileListnull.txt -wixprojectfile .\BuildXL.Setup.wixproj obj\x64\Debug\Product.wixobj obj\x64\Debug\ShellIntegration.wixobj obj\x64\Debug\_BuildXL.NuGet_dir.wixobj
   rem COMPILATION DONE!

clean:
   cd BuildXL.Setup
   if exist bin (rd /s /q bin)
   if exist obj (rd /s /q obj)
   cd..
   cd BuildXL.Setup.BuildTasks
   if exist bin (rd /s /q bin)
   if exist obj (rd /s /q obj)
   cd..
   cd BuildXL.ShellResources
   if exist bin (rd /s /q bin)
   if exist obj (rd /s /q obj)
   cd..