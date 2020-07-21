# BuildXL Installer

## What is BuildXL Installer

In a short way: BuildXL Installer is a WiX-based setup wizard for [BuildXL](https://github.com/microsoft/BuildXL).

And in a long way:

Microsoft Build Accelerator (also known as [BuildXL](https://github.com/microsoft/BuildXL)) is a build engine developed to perform lots of builds at the same time (Microsoft says that you can run 30,000+ builds per day).

This tool is built for big datacenters, since they may need to build hundreds of gigabytes/terabytes of code and this tool makes that process easier and quicker.

The problem is that (originally) you need to compile BuildXL before using it, and you may get some errors while you perform this action. And that is what BuildXL Installer does:

It is a setup wizard that installs a modern version of BuildXL into your computer, adds that folder to PATH (so you can run BuildXL from any place) and replaces the icon of the `.dsc` files with the BuildXL logo.

## Installing BuildXL using BuildXL Installer

All you need is to visit the project website ([gh-pages.lumito.net/BuildXL-Installer](https://gh-pages.lumito.net/BuildXL-Installer/index.html)), then go to the downloads section and finally, download the latest version of BuildXL.

Please note that some versions may not be tested, so they may have bugs.

## Building BuildXL Installer from source code

### Requirements

-   Visual Studio 2019.
-   Windows Installer XML toolset (WiX toolset) version 3.11.x. ATTENTION: ANY OTHER VERSION WILL NOT WORK.
-   Windows Software Development Kit (Windows SDK).
-   A x64 Windows version.

### Building source code
| [![MSBuild and WiX](https://github.com/LumitoLuma/BuildXLSetup/workflows/MSBuild%20and%20WiX/badge.svg)](https://github.com/LumitoLuma/BuildXLSetup/actions?query=workflow%3A"MSBuild+and+WiX") | [![Build status](https://ci.appveyor.com/api/projects/status/rjved60lof4p0sb9?svg=true)](https://ci.appveyor.com/project/LumitoLuma/BuildXLSetup) |
|-|-|

1.  Download (or `git clone`) the latest version of the source code
2.  Open Visual Studio 2019 Developer Command Prompt in the folder location
3.  '`cd src`'
4.  After that, run `nmake.exe`
5.  Wait a few minutes...
6.  Done! Check BuildXL.Setup\bin\x64\Debug folder.

## Contributing

If you want to contribute to the source code, please fork this repository, make the changes you want and finally, create a pull request.

**© 2019-2020, William Kent (some modifications made by [Lumito](https://github.com/LumitoLuma))**