// Copyright Epic Games, Inc. All Rights Reserved.

#include "Archon.h"
#include "Utility/ArchonLog.h"

#if WITH_EDITOR
#include "MessageLogModule.h"
#endif

#define LOCTEXT_NAMESPACE "FArchonModule"

void FArchonModule::StartupModule()
{
	IModuleInterface::StartupModule();
	
#if WITH_EDITOR
	auto& MessageLog{FModuleManager::LoadModuleChecked<FMessageLogModule>(FName{TEXTVIEW("MessageLog")})};

	FMessageLogInitializationOptions MessageLogOptions;
	MessageLogOptions.bShowFilters = true;
	MessageLogOptions.bAllowClear = true;
	MessageLogOptions.bDiscardDuplicates = true;

	MessageLog.RegisterLogListing(ArchonLog::MessageLogName, LOCTEXT("MessageLogLabel", "Archon"), MessageLogOptions);
#endif
}

void FArchonModule::ShutdownModule()
{
	IModuleInterface::ShutdownModule();
}

#undef LOCTEXT_NAMESPACE
	
IMPLEMENT_MODULE(FArchonModule, Archon)