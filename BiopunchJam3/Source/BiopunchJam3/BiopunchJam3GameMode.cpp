// Copyright 1998-2018 Epic Games, Inc. All Rights Reserved.

#include "BiopunchJam3GameMode.h"
#include "BiopunchJam3Character.h"
#include "UObject/ConstructorHelpers.h"

ABiopunchJam3GameMode::ABiopunchJam3GameMode()
{
	// set default pawn class to our Blueprinted character
	static ConstructorHelpers::FClassFinder<APawn> PlayerPawnBPClass(TEXT("/Game/ThirdPersonCPP/Blueprints/ThirdPersonCharacter"));
	if (PlayerPawnBPClass.Class != NULL)
	{
		DefaultPawnClass = PlayerPawnBPClass.Class;
	}
}
