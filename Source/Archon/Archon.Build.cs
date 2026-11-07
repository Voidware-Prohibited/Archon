// Copyright Epic Games, Inc. All Rights Reserved.

using System.Linq;
using UnrealBuildTool;

public class Archon : ModuleRules
{
	public Archon(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;
		IncludeOrderVersion = EngineIncludeOrderVersion.Latest;
        		
		// [CD/CI] For Code Coverage to run properly you can toggle optimization based on a custom flag: WITH_COVERAGE=1
		// To Activate, run build with: -define:WITH_COVERAGE=1
		if (Target.GlobalDefinitions.Contains("WITH_COVERAGE=1"))
		{
			OptimizeCode = CodeOptimization.Never;
			bUseUnity = false;
		}
        
		CppCompileWarningSettings.NonInlinedGenCppWarningLevel = WarningLevel.Warning;
		
		
		PublicDependencyModuleNames.AddRange(
			[
				"Core",
				"DeveloperSettings", "GameplayAbilities"
				// ... add other public dependencies that you statically link with here ...
			]
		);
			
		
		PrivateDependencyModuleNames.AddRange(
			[
				"CoreUObject",
				"Engine",
				"Slate",
				"SlateCore"
				// ... add private dependencies that you statically link with here ...	
			]
		);
		
		if (Target.Type == TargetRules.TargetType.Editor)
		{
			PrivateDependencyModuleNames.AddRange([
				"MessageLog"
			]);
		}
		
		// Integration Modules
		
		// Get ConfigHierarchy to fetch this plugins .ini settings
		ConfigHierarchy GameConfig = ConfigCache.ReadHierarchy(ConfigHierarchyType.Game, Target.ProjectFile.Directory, Target.Platform);
		
		// Chronos Integration 
		bool bEnableChronosIntegration;
		if (GameConfig.GetBool("/Script/Archon.UArchonArchitectureSettings", "bChronosIntegration", out bEnableChronosIntegration) && bEnableChronosIntegration)
		{
			PublicDependencyModuleNames.Add("Chronos");
			PublicDefinitions.Add("WITH_CHRONOS_INTEGRATION=1");
		}
		else
		{
			PublicDefinitions.Add("WITH_CHRONOS_INTEGRATION=0");
		}
		
		// Clima Integration 
		bool bEnableClimaIntegration;
		if (GameConfig.GetBool("/Script/Archon.UArchonArchitectureSettings", "bClimaIntegration", out bEnableClimaIntegration) && bEnableClimaIntegration)
		{
			PublicDependencyModuleNames.Add("Clima");
			PublicDefinitions.Add("WITH_CLIMA_INTEGRATION=1");
		}
		else
		{
			PublicDefinitions.Add("WITH_CLIMA_INTEGRATION=0");
		}
		
		// Echelon Integration 
		bool bEnableEchelonIntegration;
		if (GameConfig.GetBool("/Script/Archon.UArchonArchitectureSettings", "bEchelonIntegration", out bEnableEchelonIntegration) && bEnableEchelonIntegration)
		{
			PublicDependencyModuleNames.Add("Echelon");
			PublicDefinitions.Add("WITH_CHRONOS_INTEGRATION=1");
		}
		else
		{
			PublicDefinitions.Add("WITH_CHRONOS_INTEGRATION=0");
		}
		
		// Kairos Integration 
		bool bEnableKairosIntegration;
		if (GameConfig.GetBool("/Script/Archon.UArchonArchitectureSettings", "bKairosIntegration", out bEnableKairosIntegration) && bEnableKairosIntegration)
		{
			PublicDependencyModuleNames.Add("Kairos");
			PublicDefinitions.Add("WITH_KAIROS_INTEGRATION=1");
		}
		else
		{
			PublicDefinitions.Add("WITH_KAIROS_INTEGRATION=0");
		}
		
		// Choros Integration 
		bool bEnableChorosIntegration;
		if (GameConfig.GetBool("/Script/Archon.UArchonArchitectureSettings", "bChorosIntegration", out bEnableChorosIntegration) && bEnableChorosIntegration)
		{
			PublicDependencyModuleNames.Add("Choros");
			PublicDefinitions.Add("WITH_CHOROS_INTEGRATION=1");
		}
		else
		{
			PublicDefinitions.Add("WITH_CHOROS_INTEGRATION=0");
		}
		
		// Abraxas Integration 
		bool bEnableAbraxasIntegration;
		if (GameConfig.GetBool("/Script/Archon.UArchonArchitectureSettings", "bAbraxasIntegration", out bEnableAbraxasIntegration) && bEnableAbraxasIntegration)
		{
			PublicDependencyModuleNames.AddRange(["Http", "Json", "JsonUtilities"]);
			PublicDefinitions.Add("WITH_ABRAXAS_INTEGRATION=1");
		}
		else
		{
			PublicDefinitions.Add("WITH_ABRAXAS_INTEGRATION=0");
		}
		
		// EOS Integration 
		bool bEnableEosIntegration;
		if (GameConfig.GetBool("/Script/Archon.UArchonArchitectureSettings", "bEOSIntegration", out bEnableEosIntegration) && bEnableEosIntegration)
		{
			PublicDependencyModuleNames.AddRange(["Http", "Json", "JsonUtilities"]);
			PublicDefinitions.Add("WITH_EOS_INTEGRATION=1");
		}
		else
		{
			PublicDefinitions.Add("WITH_EOS_INTEGRATION=0");
		}
	}
}
