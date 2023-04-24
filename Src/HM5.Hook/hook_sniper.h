#pragma once

#include "hook.h"

#include <string>

class SniperHook : IHook
{
public:
	virtual void InitializeOptions();
	virtual void PreInitializeHook();
	virtual void PostInitializeHook();

private:
	std::string WebServiceUrl;
};
