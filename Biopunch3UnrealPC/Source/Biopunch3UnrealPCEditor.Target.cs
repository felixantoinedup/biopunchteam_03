// Copyright 1998-2018 Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;
using System.Collections.Generic;

public class Biopunch3UnrealPCEditorTarget : TargetRules
{
	public Biopunch3UnrealPCEditorTarget(TargetInfo Target) : base(Target)
	{
		Type = TargetType.Editor;
		ExtraModuleNames.Add("Biopunch3UnrealPC");
	}
}
