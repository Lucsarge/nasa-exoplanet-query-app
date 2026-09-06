// OrbitalGeometryNative.cpp : Defines the exported functions for the DLL.
//

#include "OrbitalGeometryNative.h"

#include <cmath>

extern "C" __declspec(dllexport) void __cdecl CalculatePosition(
    double orbitDistance, double angleRadians,
    double* outX, double* outY, double* outZ)
{
    *outX = orbitDistance * std::cos(angleRadians);
    *outY = 0.0;
    *outZ = orbitDistance * std::sin(angleRadians);
}
