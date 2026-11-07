#pragma once

#include "NativeGameplayTags.h"
#include "Components/ArchonGameStateComponent.h"
#include "ArchonGameStateInterface.generated.h"

UINTERFACE(Blueprintable)
class UArchonGameStateInterface : public UInterface {
	GENERATED_BODY()
};

class ARCHON_API IArchonGameStateInterface {
	GENERATED_BODY()

public:
	UFUNCTION(BlueprintImplementableEvent, BlueprintCallable, Category = "Archon Game State Interface")
	TSoftObjectPtr<UArchonGameStateComponent> GetArchonGameStateComponent();
};