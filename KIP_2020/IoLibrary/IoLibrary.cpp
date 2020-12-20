#include "IoLibrary.h"
#include <iostream>
extern "C"
{
	int __stdcall strdisplay(char* str)
	{
		setlocale(0, "");
		std::cout << str<<"\n";
		return 0;
	}
	int __stdcall bdisplay(int a)
	{
		setlocale(0, "");
		std::cout << a<<"\n";
		return 0;
	}
}