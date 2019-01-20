// Copyright 1998-2018 Epic Games, Inc. All Rights Reserved.
/*===========================================================================
	Generated code exported from UnrealHeaderTool.
	DO NOT modify this manually! Edit the corresponding .h files instead!
===========================================================================*/

#include "ObjectMacros.h"
#include "ScriptMacros.h"

PRAGMA_DISABLE_DEPRECATION_WARNINGS
#ifdef BIOPUNCH3_TestBlueprintFunctionLibrary_generated_h
#error "TestBlueprintFunctionLibrary.generated.h already included, missing '#pragma once' in TestBlueprintFunctionLibrary.h"
#endif
#define BIOPUNCH3_TestBlueprintFunctionLibrary_generated_h

#define Biopunch3_Source_Biopunch3_TestBlueprintFunctionLibrary_h_15_RPC_WRAPPERS \
 \
	DECLARE_FUNCTION(execTestFunction) \
	{ \
		P_FINISH; \
		P_NATIVE_BEGIN; \
		*(int32*)Z_Param__Result=UTestBlueprintFunctionLibrary::TestFunction(); \
		P_NATIVE_END; \
	}


#define Biopunch3_Source_Biopunch3_TestBlueprintFunctionLibrary_h_15_RPC_WRAPPERS_NO_PURE_DECLS \
 \
	DECLARE_FUNCTION(execTestFunction) \
	{ \
		P_FINISH; \
		P_NATIVE_BEGIN; \
		*(int32*)Z_Param__Result=UTestBlueprintFunctionLibrary::TestFunction(); \
		P_NATIVE_END; \
	}


#define Biopunch3_Source_Biopunch3_TestBlueprintFunctionLibrary_h_15_INCLASS_NO_PURE_DECLS \
private: \
	static void StaticRegisterNativesUTestBlueprintFunctionLibrary(); \
	friend BIOPUNCH3_API class UClass* Z_Construct_UClass_UTestBlueprintFunctionLibrary(); \
public: \
	DECLARE_CLASS(UTestBlueprintFunctionLibrary, UBlueprintFunctionLibrary, COMPILED_IN_FLAGS(0), 0, TEXT("/Script/Biopunch3"), NO_API) \
	DECLARE_SERIALIZER(UTestBlueprintFunctionLibrary) \
	enum {IsIntrinsic=COMPILED_IN_INTRINSIC};


#define Biopunch3_Source_Biopunch3_TestBlueprintFunctionLibrary_h_15_INCLASS \
private: \
	static void StaticRegisterNativesUTestBlueprintFunctionLibrary(); \
	friend BIOPUNCH3_API class UClass* Z_Construct_UClass_UTestBlueprintFunctionLibrary(); \
public: \
	DECLARE_CLASS(UTestBlueprintFunctionLibrary, UBlueprintFunctionLibrary, COMPILED_IN_FLAGS(0), 0, TEXT("/Script/Biopunch3"), NO_API) \
	DECLARE_SERIALIZER(UTestBlueprintFunctionLibrary) \
	enum {IsIntrinsic=COMPILED_IN_INTRINSIC};


#define Biopunch3_Source_Biopunch3_TestBlueprintFunctionLibrary_h_15_STANDARD_CONSTRUCTORS \
	/** Standard constructor, called after all reflected properties have been initialized */ \
	NO_API UTestBlueprintFunctionLibrary(const FObjectInitializer& ObjectInitializer = FObjectInitializer::Get()); \
	DEFINE_DEFAULT_OBJECT_INITIALIZER_CONSTRUCTOR_CALL(UTestBlueprintFunctionLibrary) \
	DECLARE_VTABLE_PTR_HELPER_CTOR(NO_API, UTestBlueprintFunctionLibrary); \
DEFINE_VTABLE_PTR_HELPER_CTOR_CALLER(UTestBlueprintFunctionLibrary); \
private: \
	/** Private move- and copy-constructors, should never be used */ \
	NO_API UTestBlueprintFunctionLibrary(UTestBlueprintFunctionLibrary&&); \
	NO_API UTestBlueprintFunctionLibrary(const UTestBlueprintFunctionLibrary&); \
public:


#define Biopunch3_Source_Biopunch3_TestBlueprintFunctionLibrary_h_15_ENHANCED_CONSTRUCTORS \
	/** Standard constructor, called after all reflected properties have been initialized */ \
	NO_API UTestBlueprintFunctionLibrary(const FObjectInitializer& ObjectInitializer = FObjectInitializer::Get()) : Super(ObjectInitializer) { }; \
private: \
	/** Private move- and copy-constructors, should never be used */ \
	NO_API UTestBlueprintFunctionLibrary(UTestBlueprintFunctionLibrary&&); \
	NO_API UTestBlueprintFunctionLibrary(const UTestBlueprintFunctionLibrary&); \
public: \
	DECLARE_VTABLE_PTR_HELPER_CTOR(NO_API, UTestBlueprintFunctionLibrary); \
DEFINE_VTABLE_PTR_HELPER_CTOR_CALLER(UTestBlueprintFunctionLibrary); \
	DEFINE_DEFAULT_OBJECT_INITIALIZER_CONSTRUCTOR_CALL(UTestBlueprintFunctionLibrary)


#define Biopunch3_Source_Biopunch3_TestBlueprintFunctionLibrary_h_15_PRIVATE_PROPERTY_OFFSET
#define Biopunch3_Source_Biopunch3_TestBlueprintFunctionLibrary_h_12_PROLOG
#define Biopunch3_Source_Biopunch3_TestBlueprintFunctionLibrary_h_15_GENERATED_BODY_LEGACY \
PRAGMA_DISABLE_DEPRECATION_WARNINGS \
public: \
	Biopunch3_Source_Biopunch3_TestBlueprintFunctionLibrary_h_15_PRIVATE_PROPERTY_OFFSET \
	Biopunch3_Source_Biopunch3_TestBlueprintFunctionLibrary_h_15_RPC_WRAPPERS \
	Biopunch3_Source_Biopunch3_TestBlueprintFunctionLibrary_h_15_INCLASS \
	Biopunch3_Source_Biopunch3_TestBlueprintFunctionLibrary_h_15_STANDARD_CONSTRUCTORS \
public: \
PRAGMA_ENABLE_DEPRECATION_WARNINGS


#define Biopunch3_Source_Biopunch3_TestBlueprintFunctionLibrary_h_15_GENERATED_BODY \
PRAGMA_DISABLE_DEPRECATION_WARNINGS \
public: \
	Biopunch3_Source_Biopunch3_TestBlueprintFunctionLibrary_h_15_PRIVATE_PROPERTY_OFFSET \
	Biopunch3_Source_Biopunch3_TestBlueprintFunctionLibrary_h_15_RPC_WRAPPERS_NO_PURE_DECLS \
	Biopunch3_Source_Biopunch3_TestBlueprintFunctionLibrary_h_15_INCLASS_NO_PURE_DECLS \
	Biopunch3_Source_Biopunch3_TestBlueprintFunctionLibrary_h_15_ENHANCED_CONSTRUCTORS \
private: \
PRAGMA_ENABLE_DEPRECATION_WARNINGS


#undef CURRENT_FILE_ID
#define CURRENT_FILE_ID Biopunch3_Source_Biopunch3_TestBlueprintFunctionLibrary_h


PRAGMA_ENABLE_DEPRECATION_WARNINGS
