// Copyright 1998-2018 Epic Games, Inc. All Rights Reserved.
/*===========================================================================
	Generated code exported from UnrealHeaderTool.
	DO NOT modify this manually! Edit the corresponding .h files instead!
===========================================================================*/

#include "GeneratedCppIncludes.h"
#include "BiopunchJam3GameMode.h"
#ifdef _MSC_VER
#pragma warning (push)
#pragma warning (disable : 4883)
#endif
PRAGMA_DISABLE_DEPRECATION_WARNINGS
void EmptyLinkFunctionForGeneratedCodeBiopunchJam3GameMode() {}
// Cross Module References
	BIOPUNCHJAM3_API UClass* Z_Construct_UClass_ABiopunchJam3GameMode_NoRegister();
	BIOPUNCHJAM3_API UClass* Z_Construct_UClass_ABiopunchJam3GameMode();
	ENGINE_API UClass* Z_Construct_UClass_AGameModeBase();
	UPackage* Z_Construct_UPackage__Script_BiopunchJam3();
// End Cross Module References
	void ABiopunchJam3GameMode::StaticRegisterNativesABiopunchJam3GameMode()
	{
	}
	UClass* Z_Construct_UClass_ABiopunchJam3GameMode_NoRegister()
	{
		return ABiopunchJam3GameMode::StaticClass();
	}
	UClass* Z_Construct_UClass_ABiopunchJam3GameMode()
	{
		static UClass* OuterClass = nullptr;
		if (!OuterClass)
		{
			static UObject* (*const DependentSingletons[])() = {
				(UObject* (*)())Z_Construct_UClass_AGameModeBase,
				(UObject* (*)())Z_Construct_UPackage__Script_BiopunchJam3,
			};
#if WITH_METADATA
			static const UE4CodeGen_Private::FMetaDataPairParam Class_MetaDataParams[] = {
				{ "HideCategories", "Info Rendering MovementReplication Replication Actor Input Movement Collision Rendering Utilities|Transformation" },
				{ "IncludePath", "BiopunchJam3GameMode.h" },
				{ "ModuleRelativePath", "BiopunchJam3GameMode.h" },
				{ "ShowCategories", "Input|MouseInput Input|TouchInput" },
			};
#endif
			static const FCppClassTypeInfoStatic StaticCppClassTypeInfo = {
				TCppClassTypeTraits<ABiopunchJam3GameMode>::IsAbstract,
			};
			static const UE4CodeGen_Private::FClassParams ClassParams = {
				&ABiopunchJam3GameMode::StaticClass,
				DependentSingletons, ARRAY_COUNT(DependentSingletons),
				0x00880288u,
				nullptr, 0,
				nullptr, 0,
				nullptr,
				&StaticCppClassTypeInfo,
				nullptr, 0,
				METADATA_PARAMS(Class_MetaDataParams, ARRAY_COUNT(Class_MetaDataParams))
			};
			UE4CodeGen_Private::ConstructUClass(OuterClass, ClassParams);
		}
		return OuterClass;
	}
	IMPLEMENT_CLASS(ABiopunchJam3GameMode, 1282888079);
	static FCompiledInDefer Z_CompiledInDefer_UClass_ABiopunchJam3GameMode(Z_Construct_UClass_ABiopunchJam3GameMode, &ABiopunchJam3GameMode::StaticClass, TEXT("/Script/BiopunchJam3"), TEXT("ABiopunchJam3GameMode"), false, nullptr, nullptr, nullptr);
	DEFINE_VTABLE_PTR_HELPER_CTOR(ABiopunchJam3GameMode);
PRAGMA_ENABLE_DEPRECATION_WARNINGS
#ifdef _MSC_VER
#pragma warning (pop)
#endif
