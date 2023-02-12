@echo off
dotnet build src/Skybrud.Social.Instagram --configuration Release /t:rebuild /t:pack -p:PackageOutputPath=../../releases/nuget