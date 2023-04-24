#include "hook_absolution.h"

bool AbsolutionHook::SkipLauncher = false;
std::string AbsolutionHook::WebServiceUrl;
AbsolutionHook::tGetApplicationOptionBool AbsolutionHook::oGetApplicationOptionBool = nullptr;
AbsolutionHook::tZWebServiceClientManagerCreate AbsolutionHook::oZWebServiceClientManagerCreate = nullptr;

bool __cdecl AbsolutionHook::GetApplicationOptionBool(ZString* sName, bool bDefault)
{
	if (strcmp(sName->m_chars, "EnableSplashScreen") == 0 && SkipLauncher)
	{
		LogFile << "SkipLauncher" << std::endl;

		return false;
	}

	return oGetApplicationOptionBool(sName, bDefault);
}

//Source: https://tresp4sser.wordpress.com/2012/10/06/how-to-hook-thiscall-functions/
void* __fastcall AbsolutionHook::ZWebServiceClientManagerCreate(void* instance, void* _, const char* baseUrl, void* callback)
{
	LogFile << "ZWebServiceClientManagerCreate" << baseUrl << std::endl;

	return oZWebServiceClientManagerCreate(instance, WebServiceUrl.c_str(), callback);
}

void AbsolutionHook::InitializeOptions()
{
	SkipLauncher = IniFile.GetBoolean("hm5", "skiplauncher", false);
	WebServiceUrl = IniFile.Get("hm5", "webserviceurl", "http://localhost/hm5");
}

void AbsolutionHook::PreInitializeHook()
{
	void* ptrGetApplicationOptionBool = (void*)0x00612930;
	void* ptrZWebServiceClientManagerCreate = (void*)0x00BE22CF;

	MH_STATUS skipLauncherHook = MH_CreateHook(
		ptrGetApplicationOptionBool,
		GetApplicationOptionBool,
		reinterpret_cast<void**>(&oGetApplicationOptionBool)
	);

	MH_STATUS webServiceurlHook = MH_CreateHook(
		ptrZWebServiceClientManagerCreate,
		ZWebServiceClientManagerCreate,
		reinterpret_cast<void**>(&oZWebServiceClientManagerCreate)
	);

	LogStatus("SkipLauncher hook", skipLauncherHook);
	LogStatus("SkipLauncher enable", MH_EnableHook(ptrGetApplicationOptionBool));

	LogStatus("WebServiceUrl hook", webServiceurlHook);
	LogStatus("WebServiceUrl enable", MH_EnableHook(ptrZWebServiceClientManagerCreate));
}

void AbsolutionHook::PostInitializeHook()
{
	//Do nothing
}