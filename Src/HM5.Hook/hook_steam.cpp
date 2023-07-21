// ReSharper disable CppClangTidyClangDiagnosticGnuZeroVariadicMacroArguments
#include "hook_steam.h"

#include <cinttypes>

//NOTE: For some reason, I can't call a function through the VTable...
class IFakeSteamUser
{
public:
	virtual void vtable0();
	virtual void vtable1();
	virtual void vtable2();
	virtual void vtable3();
	virtual void vtable4();
	virtual void vtable5();
	virtual void vtable6();
	virtual void vtable7();
	virtual void vtable8();
	virtual void vtable9();
	virtual void vtable10();
	virtual void vtable11();
	virtual void vtable12();
	virtual uint32_t GetAuthSessionTicket(void* pTicket, int cbMaxTicket, uint32_t* pcbTicket) = 0;
	virtual void vtable14();
	virtual void vtable15();
	virtual void CancelAuthTicket(uint32_t hAuthTicket) = 0;
};

template<typename F>
F GetOriginalFunction(uint64_t originalFunction, F) {
	return reinterpret_cast<F>(originalFunction);
}

#define VIRTUAL(TYPE) __declspec(noinline) TYPE __fastcall // NOLINT(bugprone-macro-parentheses)
#define PARAMS(...) const void* ECX, const void* EDX, __VA_ARGS__
#define ARGS(...) ECX, EDX, __VA_ARGS__
#define THIS ECX
#define ORIGINAL_HOOK(FUNC, ...) GetOriginalFunction(o##FUNC, FUNC)(__VA_ARGS__)
#define ORIGINAL(FUNC, ...) GetOriginalFunction(o##FUNC, FUNC)(ARGS(__VA_ARGS__))

bool EnableAuthentication;
bool DisableNameResolving;

uintptr_t oSteamFriends;
uintptr_t oSteamUser;

uintptr_t oISteamFriends_GetFriendPersonaName;
uintptr_t oISteamUser_RequestEncryptedAppTicket;
uintptr_t oISteamUser_GetEncryptedAppTicket;

uint32_t lastAuthSessionTicketHandle;
static constexpr uint32_t MAX_TICKET_SIZE { 1024 };
uint32_t authSessionTicketSize{ 0 };
char authSessionTicket[MAX_TICKET_SIZE];

void SwapVirtualFunction(const void* instance, uint32_t vtableOffset, uintptr_t ptrDetour, uintptr_t* ptrOriginal)
{
	const auto ptrVTable = *(uintptr_t**)instance;

	//NOTE: Prevent detouring an already detoured function
	if (ptrVTable[vtableOffset] == ptrDetour) {
		return;
	}

	DWORD originalProtect;
	VirtualProtect(&ptrVTable[vtableOffset], sizeof(uintptr_t), PAGE_READWRITE, &originalProtect);

	*ptrOriginal = ptrVTable[vtableOffset];
	ptrVTable[vtableOffset] = ptrDetour;
}

VIRTUAL(const char*) ISteamFriends_GetFriendPersonaName(PARAMS(uint64_t steamIDFriend))
{
	const auto buffer = new char[21];
	sprintf(buffer, "%" PRIu64, steamIDFriend);

	return buffer;
}

VIRTUAL(uint64_t) ISteamUser_RequestEncryptedAppTicket(PARAMS(void* pDataToInclude, int cbDataToInclude))
{
	const auto result = ORIGINAL(ISteamUser_RequestEncryptedAppTicket, pDataToInclude, cbDataToInclude);

	if (lastAuthSessionTicketHandle)
	{
		((IFakeSteamUser*)THIS)->CancelAuthTicket(lastAuthSessionTicketHandle);
	}

	lastAuthSessionTicketHandle = ((IFakeSteamUser*)THIS)->GetAuthSessionTicket(&authSessionTicket, MAX_TICKET_SIZE, &authSessionTicketSize);

	return result;
}

VIRTUAL(bool) ISteamUser_GetEncryptedAppTicket(PARAMS(void* pTicket, int cbMaxTicket, uint32_t* pcbTicket))
{
	*pcbTicket = authSessionTicketSize;

	memcpy_s(pTicket, cbMaxTicket, authSessionTicket, authSessionTicketSize);

	return true;
}

void* SteamFriends()
{
	const auto instance = ORIGINAL_HOOK(SteamFriends);

	if(DisableNameResolving)
	{
		//7 = GetFriendPersonaName (SteamFriends011)
		SwapVirtualFunction(
			instance,
			7,
			reinterpret_cast<uintptr_t>(ISteamFriends_GetFriendPersonaName),
			&oISteamFriends_GetFriendPersonaName
		);
	}

	return instance;
}

void* SteamUser()
{
	const auto instance = ORIGINAL_HOOK(SteamUser);

	if(EnableAuthentication)
	{
		//20 = RequestEncryptedAppTicket (SteamUser016)
		SwapVirtualFunction(
			instance,
			20,
			reinterpret_cast<uintptr_t>(ISteamUser_RequestEncryptedAppTicket),
			&oISteamUser_RequestEncryptedAppTicket
		);

		//21 = GetEncryptedAppTicket (SteamUser016)
		SwapVirtualFunction(
			instance,
			21,
			reinterpret_cast<uintptr_t>(ISteamUser_GetEncryptedAppTicket),
			&oISteamUser_GetEncryptedAppTicket
		);
	}

	return instance;
}

void SteamHook::InitializeOptions()
{
	EnableAuthentication = IniFile.GetBoolean("steam", "enableauthentication", false);
	DisableNameResolving = IniFile.GetBoolean("steam", "disablenameresolving", false);
}

void SteamHook::PreInitializeHook()
{
	const auto hLibrary = LoadLibrary(L"steam_api.dll");

	const auto ptrSteamFriends = (void*)GetProcAddress(hLibrary, "SteamFriends");
	const auto ptrSteamUser = (void*)GetProcAddress(hLibrary, "SteamUser");

	MH_STATUS steamFriendsHook = MH_CreateHook(
		ptrSteamFriends,
		SteamFriends,
		reinterpret_cast<void**>(&oSteamFriends)
	);

	MH_STATUS steamUserHook = MH_CreateHook(
		ptrSteamUser,
		SteamUser,
		reinterpret_cast<void**>(&oSteamUser)
	);

	LogStatus("steamFriendsHook enable", MH_EnableHook(ptrSteamFriends));
	LogStatus("steamUserHook enable", MH_EnableHook(ptrSteamUser));
}

void SteamHook::PostInitializeHook()
{
	//Do nothing
}