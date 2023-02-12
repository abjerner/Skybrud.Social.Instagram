@echo off
dotnet build src/Skybrud.Social.Instagram --configuration Debug /t:rebuild /t:pack -p:PackageOutputPath=c:/nuget