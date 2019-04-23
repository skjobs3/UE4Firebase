// Copyright 1998-2019 Epic Games, Inc. All Rights Reserved.

#include "UE4FirebaseGameMode.h"
#include "UE4FirebaseHUD.h"
#include "UE4FirebaseCharacter.h"
#include "UObject/ConstructorHelpers.h"

AUE4FirebaseGameMode::AUE4FirebaseGameMode()
	: Super()
{
	// set default pawn class to our Blueprinted character
	static ConstructorHelpers::FClassFinder<APawn> PlayerPawnClassFinder(TEXT("/Game/FirstPersonCPP/Blueprints/FirstPersonCharacter"));
	DefaultPawnClass = PlayerPawnClassFinder.Class;

	// use our custom HUD class
	HUDClass = AUE4FirebaseHUD::StaticClass();
}
