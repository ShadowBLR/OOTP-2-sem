#include "MathLibrary.h"
extern "C" 
{
	int __stdcall abs(int x)
	{
		return x > 0 ? x : -x;
	}
	int __stdcall max(int x, int y)
	{
		return x > y ? x : y;
	}
	int __stdcall min(int x, int y)
	{
		return x < y ? x : y;
	}
	int _stdcall negative(int x)
	{
		return -x;
	}

}