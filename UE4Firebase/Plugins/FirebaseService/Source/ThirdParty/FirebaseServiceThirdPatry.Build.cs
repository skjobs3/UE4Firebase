// Copyright 1998-2019 Epic Games, Inc. All Rights Reserved.

using System;
using System.IO;
using UnrealBuildTool;

public class FirebaseServiceThirdPatry : ModuleRules
{
    private string FirebaseDirectory
    {
        get
        {
            return Path.Combine(ModuleDirectory, "firebase_cpp_sdk");
        }
    }

	public FirebaseServiceThirdPatry(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;
        Type = ModuleType.External;

        PublicIncludePaths.AddRange(
            new string[] {
                // ... add other public include paths required here ...
			}
            );
				
		
		PrivateIncludePaths.AddRange(
			new string[] {
				// ... add other private include paths required here ...
			}
			);
			
		
		PublicDependencyModuleNames.AddRange(
			new string[]
			{
				// ... add other public dependencies that you statically link with here ...
			}
			);
			
		
		PrivateDependencyModuleNames.AddRange(
			new string[]
			{
				// ... add private dependencies that you statically link with here ...	
			}
			);
		
		
		DynamicallyLoadedModuleNames.AddRange(
			new string[]
			{
				// ... add any modules that your module loads dynamically here ...
			}
			);

        ConfigureFirebase();
	}

    private void ConfigureFirebase()
    {
        // Configure include paths
        PublicIncludePaths.Add(Path.Combine(FirebaseDirectory, "include"));

        // Link libraries
        string librariesPath = "";
        string[] libraries = new string[] { };

        switch(Target.Platform)
        {
            case UnrealTargetPlatform.Win64:
                {
                    string buildType;

                    switch (Target.Configuration)
                    {
                        case UnrealTargetConfiguration.DebugGame:
                        case UnrealTargetConfiguration.Debug:
                        case UnrealTargetConfiguration.Development:
                            buildType = "Debug";
                            break;

                        default:
                            buildType = "Release";
                            break;
                    }

                    librariesPath = Path.Combine(FirebaseDirectory, "libs", "windows", "VS2015", "MD", "x64", buildType);
                    libraries = new string[]
                    {
                        "firebase_app.lib",
                        "firebase_auth.lib",
                        "firebase_database.lib"
                    };
                }
                break;

            //#TODO:Mac
            //#TODO:IOS
            //#TODO:Android

            default:
                //#TODO:
                break;
        }

        PublicLibraryPaths.Add(librariesPath);
        PublicAdditionalLibraries.AddRange(libraries);
    }
}
