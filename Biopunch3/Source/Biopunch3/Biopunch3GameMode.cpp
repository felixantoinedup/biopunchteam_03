// Copyright 1998-2018 Epic Games, Inc. All Rights Reserved.

#include "Biopunch3GameMode.h"
#include "Biopunch3Character.h"
#include "UObject/ConstructorHelpers.h"

ABiopunch3GameMode::ABiopunch3GameMode()
{
	// set default pawn class to our Blueprinted character
	static ConstructorHelpers::FClassFinder<APawn> PlayerPawnBPClass(TEXT("/Game/ThirdPersonCPP/Blueprints/ThirdPersonCharacter"));
	if (PlayerPawnBPClass.Class != NULL)
	{
		DefaultPawnClass = PlayerPawnBPClass.Class;
	}
}
