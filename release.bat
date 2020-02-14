@echo off
"C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\MSBuild\Current\Bin\msbuild.exe" src/Skybrud.Social.Instagram /t:rebuild /t:pack /p:Configuration=Release /p:BuildTools=1 /p:PackageOutputPath=../../releases/nuget
