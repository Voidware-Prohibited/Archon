// MIT

#pragma once

#include "CoreMinimal.h"
#include "Engine/DeveloperSettings.h"
#include "ArchonArchitectureSettings.generated.h"

/**
 * 
 */
UCLASS(config = Archon, DefaultConfig)
class ARCHON_API UArchonArchitectureSettings : public UDeveloperSettings
{
	GENERATED_BODY()

public:
	UArchonArchitectureSettings();

	UPROPERTY(Config, EditAnywhere, Category = "Architecture")
	bool bEOSIntegration {false};

	// True = Integrate with Abraxas, False = Local Mode
	UPROPERTY(Config, EditAnywhere, Category = "Architecture")
	bool bAbraxasIntegration {false};

	UPROPERTY(Config, EditAnywhere, Category = "Architecture")
	bool bClimaIntegration {false};

	UPROPERTY(Config, EditAnywhere, Category = "Architecture")
	bool bChronosIntegration {false};

	UPROPERTY(Config, EditAnywhere, Category = "Architecture")
	bool bEchelonIntegration {false};

	UPROPERTY(Config, EditAnywhere, Category = "Architecture")
	bool bKairosIntegration {false};

	UPROPERTY(Config, EditAnywhere, Category = "Architecture")
	bool bChorosIntegration {false};

	UPROPERTY(Config, EditAnywhere, Category = "Architecture")
	FString AbraxasAddress;

	UPROPERTY(Config, EditAnywhere, Category = "Architecture|EOS")
	FString EOSApiKey;

	UPROPERTY(Config, EditAnywhere, Category = "Architecture|Abraxas")
	FString AbraxasApiKey;

#if WITH_EDITOR
	virtual FName GetCategoryName() const override { return TEXT("Plugins"); }
	virtual FText GetSectionText() const override { return NSLOCTEXT("Archon", "ArchonSectionText", "Archon Settings"); }
	virtual FText GetSectionDescription() const override { return NSLOCTEXT("Archon", "ArchonSectionDesc", "Configure Archon Architecture Settings"); }
#endif
};
