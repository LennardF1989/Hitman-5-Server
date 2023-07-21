#pragma once

#include "hook.h"

class SteamHook final : IHook
{
public:
	void InitializeOptions() override;
	void PreInitializeHook() override;
	void PostInitializeHook() override;
};
