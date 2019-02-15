// Copyright 1998-2018 Epic Games, Inc. All Rights Reserved.

#include "Biopunch3UnrealPCGameMode.h"
#include "Biopunch3UnrealPCCharacter.h"
#include "UObject/ConstructorHelpers.h"

ABiopunch3UnrealPCGameMode::ABiopunch3UnrealPCGameMode()
{
	// set default pawn class to our Blueprinted character
	static ConstructorHelpers::FClassFinder<APawn> PlayerPawnBPClass(TEXT("/Game/ThirdPersonCPP/Blueprints/ThirdPersonCharacter"));
	if (PlayerPawnBPClass.Class != NULL)
	{
		DefaultPawnClass = PlayerPawnBPClass.Class;
	}
}
