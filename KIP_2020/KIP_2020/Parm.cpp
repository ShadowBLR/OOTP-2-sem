#include "tchar.h"
#include "Error.h"
#include "Parm.h"
#include <iostream>
#include <string.h>

namespace Parm
{
	PARM Parm::getparm(int argc, wchar_t* argv[])
	{
		bool b[2] = { 0,0 };
		PARM tempParm;

		for (int i = 1; i < argc; i++)
			if (wcsstr(argv[i], PARM_IN))
			{
				wcscpy_s(tempParm.in, wcsstr(argv[i], L":") + 1);
				break;
			}
			else if (i == argc - 1)
				throw ERROR_THROW(100);

		for (int i = 1; i < argc; i++)
			if (wcslen(argv[i]) > 300)
			{
				throw ERROR_THROW(104);
			}
			else if (!b[0] && wcsstr(argv[i], PARM_OUT))
			{
				b[0] = true;
				wcscpy_s(tempParm.out, wcsstr(argv[i], L":") + 1);
			}
			else if (!b[1] && wcsstr(argv[i], PARM_LOG))
			{
				b[1] = true;
				wcscpy_s(tempParm.log, wcsstr(argv[i], L":") + 1);
			}
		if (!b[0])
		{
			wcscpy_s(tempParm.out, tempParm.in);
			wcscat_s(tempParm.out, PARM_OUT_DEFAULT_EXT);
		}
		if (!b[1])
		{
			wcscpy_s(tempParm.log, tempParm.in);
			wcscat_s(tempParm.log, PARM_LOG_DEFAULT_EXT);
		}
		return tempParm;
	}
}