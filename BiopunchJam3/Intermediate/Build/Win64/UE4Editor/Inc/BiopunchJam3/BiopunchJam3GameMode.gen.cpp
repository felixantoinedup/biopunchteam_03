// Copyright 1998-2018 Epic Games, Inc. All Rights Reserved.
/*===========================================================================
	Generated code exported from UnrealHeaderTool.
	DO NOT modify this manually! Edit the corresponding .h files instead!
===========================================================================*/

#include "UObject/GeneratedCppIncludes.h"
#include "BiopunchJam3/BiopunchJam3GameMode.h"
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
	struct Z_Construct_UClass_ABiopunchJam3GameMode_Statics
	{
		static UObject* (*const DependentSingletons[])();
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Class_MetaDataParams[];
#endif
		static const FCppClassTypeInfoStatic StaticCppClassTypeInfo;
		static const UE4CodeGen_Private::FClassParams ClassParams;
	};
	UObject* (*const Z_Construct_UClass_ABiopunchJam3GameMode_Statics::DependentSingletons[])() = {
		(UObject* (*)())Z_Construct_UClass_AGameModeBase,
		(UObject* (*)())Z_Construct_UPackage__Script_BiopunchJam3,
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ABiopunchJam3GameMode_Statics::Class_MetaDataParams[] = {
		{ "HideCategories", "Info Rendering MovementReplication Replication Actor Input Movement Collision Rendering Utilities|Transformation" },
		{ "IncludePath", "BiopunchJam3GameMode.h" },
		{ "ModuleRelativePath", "BiopunchJam3GameMode.h" },
		{ "ShowCategories", "Input|MouseInput Input|TouchInput" },
	};
#endif
	const FCppClassTypeInfoStatic Z_Construct_UClass_ABiopunchJam3GameMode_Statics::StaticCppClassTypeInfo = {
		TCppClassTypeTraits<ABiopunchJam3GameMode>::IsAbstract,
	};
	const UE4CodeGen_Private::FClassParams Z_Construct_UClass_ABiopunchJam3GameMode_Statics::ClassParams = {
		&ABiopunchJam3GameMode::StaticClass,
		DependentSingletons, ARRAY_COUNT(DependentSingletons),
		0x008802A8u,
		nullptr, 0,
		nullptr, 0,
		nullptr,
		&StaticCppClassTypeInfo,
		nullptr, 0,
		METADATA_PARAMS(Z_Construct_UClass_ABiopunchJam3GameMode_Statics::Class_MetaDataParams, ARRAY_COUNT(Z_Construct_UClass_ABiopunchJam3GameMode_Statics::Class_MetaDataParams))
	};
	UClass* Z_Construct_UClass_ABiopunchJam3GameMode()
	{
		static UClass* OuterClass = nullptr;
		if (!OuterClass)
		{
			UE4CodeGen_Private::ConstructUClass(OuterClass, Z_Construct_UClass_ABiopunchJam3GameMode_Statics::ClassParams);
		}
		return OuterClass;
	}
	IMPLEMENT_CLASS(ABiopunchJam3GameMode, 3464374104);
	static FCompiledInDefer Z_CompiledInDefer_UClass_ABiopunchJam3GameMode(Z_Construct_UClass_ABiopunchJam3GameMode, &ABiopunchJam3GameMode::StaticClass, TEXT("/Script/BiopunchJam3"), TEXT("ABiopunchJam3GameMode"), false, nullptr, nullptr, nullptr);
	DEFINE_VTABLE_PTR_HELPER_CTOR(ABiopunchJam3GameMode);
PRAGMA_ENABLE_DEPRECATION_WARNINGS
#ifdef _MSC_VER
#pragma warning (pop)
#endif
