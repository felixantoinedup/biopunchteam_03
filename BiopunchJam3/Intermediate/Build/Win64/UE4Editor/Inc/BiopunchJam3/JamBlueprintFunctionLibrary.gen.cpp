// Copyright 1998-2018 Epic Games, Inc. All Rights Reserved.
/*===========================================================================
	Generated code exported from UnrealHeaderTool.
	DO NOT modify this manually! Edit the corresponding .h files instead!
===========================================================================*/

#include "UObject/GeneratedCppIncludes.h"
#include "BiopunchJam3/JamBlueprintFunctionLibrary.h"
#ifdef _MSC_VER
#pragma warning (push)
#pragma warning (disable : 4883)
#endif
PRAGMA_DISABLE_DEPRECATION_WARNINGS
void EmptyLinkFunctionForGeneratedCodeJamBlueprintFunctionLibrary() {}
// Cross Module References
	BIOPUNCHJAM3_API UClass* Z_Construct_UClass_UJamBlueprintFunctionLibrary_NoRegister();
	BIOPUNCHJAM3_API UClass* Z_Construct_UClass_UJamBlueprintFunctionLibrary();
	ENGINE_API UClass* Z_Construct_UClass_UBlueprintFunctionLibrary();
	UPackage* Z_Construct_UPackage__Script_BiopunchJam3();
	BIOPUNCHJAM3_API UFunction* Z_Construct_UFunction_UJamBlueprintFunctionLibrary_TestFunction();
// End Cross Module References
	void UJamBlueprintFunctionLibrary::StaticRegisterNativesUJamBlueprintFunctionLibrary()
	{
		UClass* Class = UJamBlueprintFunctionLibrary::StaticClass();
		static const FNameNativePtrPair Funcs[] = {
			{ "TestFunction", &UJamBlueprintFunctionLibrary::execTestFunction },
		};
		FNativeFunctionRegistrar::RegisterFunctions(Class, Funcs, ARRAY_COUNT(Funcs));
	}
	struct Z_Construct_UFunction_UJamBlueprintFunctionLibrary_TestFunction_Statics
	{
		struct JamBlueprintFunctionLibrary_eventTestFunction_Parms
		{
			int32 ReturnValue;
		};
		static const UE4CodeGen_Private::FUnsizedIntPropertyParams NewProp_ReturnValue;
		static const UE4CodeGen_Private::FPropertyParamsBase* const PropPointers[];
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Function_MetaDataParams[];
#endif
		static const UE4CodeGen_Private::FFunctionParams FuncParams;
	};
	const UE4CodeGen_Private::FUnsizedIntPropertyParams Z_Construct_UFunction_UJamBlueprintFunctionLibrary_TestFunction_Statics::NewProp_ReturnValue = { UE4CodeGen_Private::EPropertyClass::Int, "ReturnValue", RF_Public|RF_Transient|RF_MarkAsNative, (EPropertyFlags)0x0010000000000580, 1, nullptr, STRUCT_OFFSET(JamBlueprintFunctionLibrary_eventTestFunction_Parms, ReturnValue), METADATA_PARAMS(nullptr, 0) };
	const UE4CodeGen_Private::FPropertyParamsBase* const Z_Construct_UFunction_UJamBlueprintFunctionLibrary_TestFunction_Statics::PropPointers[] = {
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UFunction_UJamBlueprintFunctionLibrary_TestFunction_Statics::NewProp_ReturnValue,
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_UJamBlueprintFunctionLibrary_TestFunction_Statics::Function_MetaDataParams[] = {
		{ "ModuleRelativePath", "JamBlueprintFunctionLibrary.h" },
	};
#endif
	const UE4CodeGen_Private::FFunctionParams Z_Construct_UFunction_UJamBlueprintFunctionLibrary_TestFunction_Statics::FuncParams = { (UObject*(*)())Z_Construct_UClass_UJamBlueprintFunctionLibrary, "TestFunction", RF_Public|RF_Transient|RF_MarkAsNative, nullptr, (EFunctionFlags)0x04042401, sizeof(JamBlueprintFunctionLibrary_eventTestFunction_Parms), Z_Construct_UFunction_UJamBlueprintFunctionLibrary_TestFunction_Statics::PropPointers, ARRAY_COUNT(Z_Construct_UFunction_UJamBlueprintFunctionLibrary_TestFunction_Statics::PropPointers), 0, 0, METADATA_PARAMS(Z_Construct_UFunction_UJamBlueprintFunctionLibrary_TestFunction_Statics::Function_MetaDataParams, ARRAY_COUNT(Z_Construct_UFunction_UJamBlueprintFunctionLibrary_TestFunction_Statics::Function_MetaDataParams)) };
	UFunction* Z_Construct_UFunction_UJamBlueprintFunctionLibrary_TestFunction()
	{
		static UFunction* ReturnFunction = nullptr;
		if (!ReturnFunction)
		{
			UE4CodeGen_Private::ConstructUFunction(ReturnFunction, Z_Construct_UFunction_UJamBlueprintFunctionLibrary_TestFunction_Statics::FuncParams);
		}
		return ReturnFunction;
	}
	UClass* Z_Construct_UClass_UJamBlueprintFunctionLibrary_NoRegister()
	{
		return UJamBlueprintFunctionLibrary::StaticClass();
	}
	struct Z_Construct_UClass_UJamBlueprintFunctionLibrary_Statics
	{
		static UObject* (*const DependentSingletons[])();
		static const FClassFunctionLinkInfo FuncInfo[];
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Class_MetaDataParams[];
#endif
		static const FCppClassTypeInfoStatic StaticCppClassTypeInfo;
		static const UE4CodeGen_Private::FClassParams ClassParams;
	};
	UObject* (*const Z_Construct_UClass_UJamBlueprintFunctionLibrary_Statics::DependentSingletons[])() = {
		(UObject* (*)())Z_Construct_UClass_UBlueprintFunctionLibrary,
		(UObject* (*)())Z_Construct_UPackage__Script_BiopunchJam3,
	};
	const FClassFunctionLinkInfo Z_Construct_UClass_UJamBlueprintFunctionLibrary_Statics::FuncInfo[] = {
		{ &Z_Construct_UFunction_UJamBlueprintFunctionLibrary_TestFunction, "TestFunction" }, // 3718879569
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_UJamBlueprintFunctionLibrary_Statics::Class_MetaDataParams[] = {
		{ "IncludePath", "JamBlueprintFunctionLibrary.h" },
		{ "ModuleRelativePath", "JamBlueprintFunctionLibrary.h" },
	};
#endif
	const FCppClassTypeInfoStatic Z_Construct_UClass_UJamBlueprintFunctionLibrary_Statics::StaticCppClassTypeInfo = {
		TCppClassTypeTraits<UJamBlueprintFunctionLibrary>::IsAbstract,
	};
	const UE4CodeGen_Private::FClassParams Z_Construct_UClass_UJamBlueprintFunctionLibrary_Statics::ClassParams = {
		&UJamBlueprintFunctionLibrary::StaticClass,
		DependentSingletons, ARRAY_COUNT(DependentSingletons),
		0x001000A0u,
		FuncInfo, ARRAY_COUNT(FuncInfo),
		nullptr, 0,
		nullptr,
		&StaticCppClassTypeInfo,
		nullptr, 0,
		METADATA_PARAMS(Z_Construct_UClass_UJamBlueprintFunctionLibrary_Statics::Class_MetaDataParams, ARRAY_COUNT(Z_Construct_UClass_UJamBlueprintFunctionLibrary_Statics::Class_MetaDataParams))
	};
	UClass* Z_Construct_UClass_UJamBlueprintFunctionLibrary()
	{
		static UClass* OuterClass = nullptr;
		if (!OuterClass)
		{
			UE4CodeGen_Private::ConstructUClass(OuterClass, Z_Construct_UClass_UJamBlueprintFunctionLibrary_Statics::ClassParams);
		}
		return OuterClass;
	}
	IMPLEMENT_CLASS(UJamBlueprintFunctionLibrary, 2286235031);
	static FCompiledInDefer Z_CompiledInDefer_UClass_UJamBlueprintFunctionLibrary(Z_Construct_UClass_UJamBlueprintFunctionLibrary, &UJamBlueprintFunctionLibrary::StaticClass, TEXT("/Script/BiopunchJam3"), TEXT("UJamBlueprintFunctionLibrary"), false, nullptr, nullptr, nullptr);
	DEFINE_VTABLE_PTR_HELPER_CTOR(UJamBlueprintFunctionLibrary);
PRAGMA_ENABLE_DEPRECATION_WARNINGS
#ifdef _MSC_VER
#pragma warning (pop)
#endif
