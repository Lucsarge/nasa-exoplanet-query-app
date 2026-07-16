#pragma once

extern "C" __declspec(dllexport) void __cdecl CalculatePosition(
    double orbitDistance, double angleRadians,
    double* outX, double* outY, double* outZ);
