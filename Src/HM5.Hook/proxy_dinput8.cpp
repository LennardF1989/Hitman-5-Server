#include "proxy.h"

#if HOOK_TYPE == HOOK_TYPE_DINPUT8

#include "hook.h"
#include <iostream>
#include "MinHook.h"

typedef HRESULT(WINAPI* tDirectInput8Create)(HINSTANCE hinst, DWORD dwVersion, REFIID riidltf, LPVOID* ppvOut, LPUNKNOWN punkOuter);
tDirectInput8Create oDirectInput8Create;

void LoadProxyDll()
{
	LogFile << "LoadProxyDLL: ";

	wchar_t syspath[512];
	GetSystemDirectory(syspath, 512);
	wcscat_s(syspath, L"\\dinput8.dll");

	const HMODULE hLibrary = LoadLibrary(syspath);

	if (!hLibrary) {
		LogFile << "Fail!" << std::endl;

		return;
	}

	oDirectInput8Create = (tDirectInput8Create)(void*)GetProcAddress(hLibrary, "DirectInput8Create");

	LogFile << "Done!" << std::endl;
}

#pragma comment(linker, "/export:DirectInput8Create=_DirectInput8Create@20")
extern "C" __declspec(dllexport) HRESULT WINAPI DirectInput8Create(HINSTANCE hinst, DWORD dwVersion, REFIID riidltf, LPVOID * ppvOut, LPUNKNOWN punkOuter)
{
	LogFile << "DirectInput8Create" << std::endl;

	for (const auto& hook : Hooks)
	{
		hook->PreInitializeHook();
	}

	return oDirectInput8Create(hinst, dwVersion, riidltf, ppvOut, punkOuter);
}

#endif