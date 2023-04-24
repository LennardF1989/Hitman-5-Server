#include "hook_sniper.h"

void SniperHook::InitializeOptions()
{
	WebServiceUrl = IniFile.Get("sniper", "webserviceurl", "http://localhost/sniper");
}

void SniperHook::PreInitializeHook()
{
	//Do nothing
}

void SniperHook::PostInitializeHook()
{
	auto ptrWebServiceUrl = (void*)0x113D5E8;
	strcpy((char*)ptrWebServiceUrl, WebServiceUrl.substr(0, 256).c_str());
}