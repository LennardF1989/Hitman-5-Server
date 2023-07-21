#pragma once

// ReSharper disable once CppInconsistentNaming
#define _CRT_SECURE_NO_WARNINGS // NOLINT(bugprone-reserved-identifier)

#include <Windows.h>
#include <fstream>
#include <ctime>
#include <map>
#include <vector>

#include "MinHook.h"
#include "INIReader.h"

interface IHook {
	virtual ~IHook() = default;
	virtual void InitializeOptions() = 0;
	virtual void PreInitializeHook() = 0;
	virtual void PostInitializeHook() = 0;
};

extern std::vector<IHook*> Hooks;

extern bool OptionsEnabled;
extern bool OptionsLog;

extern std::ofstream LogFile;
extern INIReader IniFile;

inline void LogTime() {
	const std::time_t result = std::time(nullptr);

	char* time = std::asctime(std::localtime(&result));
	time[strlen(time) - 1] = 0;

	LogFile << "[" << time << "]" << std::endl;
}

#define LOG_MESSAGE(...) if(OptionsLog) { LogTime();LogFile << __VA_ARGS__ << std::endl;}

inline void LogStatus(LPCSTR name, MH_STATUS status)
{
	LogFile << name << ": " << MH_StatusToString(status) << std::endl;
}