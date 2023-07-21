#pragma once

#include "hook.h"

#include <string>

class AbsolutionHook final : IHook
{
public:
	void InitializeOptions() override;
	void PreInitializeHook() override;
	void PostInitializeHook() override;

private:
	static bool SkipLauncher;
	static std::string WebServiceUrl;

	struct ZString
	{
		unsigned int m_length;
		const char* m_chars;
	};

	typedef bool(__cdecl* tGetApplicationOptionBool)(ZString* sName, bool bDefault);
	typedef void* (__thiscall* tZWebServiceClientManagerCreate)(void* instance, const char* baseUrl, void* callback);

	static bool __cdecl GetApplicationOptionBool(ZString* sName, bool bDefault);
	static void* __fastcall ZWebServiceClientManagerCreate(void* instance, void* _, const char* baseUrl, void* callback);

	static tGetApplicationOptionBool oGetApplicationOptionBool;
	static tZWebServiceClientManagerCreate oZWebServiceClientManagerCreate;
};
