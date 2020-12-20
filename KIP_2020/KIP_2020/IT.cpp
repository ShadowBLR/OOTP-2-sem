#include "IT.h"
#include <fstream>
#include <iostream>
#include <stdlib.h>
#include <cstdarg>
#include "Error.h"

namespace IT
{
	IdTable Create(	//создать таблицу ID
		int size	//Ємкость
	) {
		if (size > TI_MAXSIZE)
		{
			throw ERROR_THROW(130);
		}
		IdTable out;
		out.maxsize = size;
		out.size = 0;
		out.table = new Entry[size];
		return out;
	};
	void Add(
		IdTable& idtable,	//экземпл€р таблицы итендификаторов
		Entry entry			//строка таблицы итендификаторов
	) {
		if (idtable.size == idtable.maxsize)
			throw ERROR_THROW(133);
		idtable.table[idtable.size++] = entry;

		//add error maxsize
	};
	Entry GetEntry(	//получить строку таблицы итендификаторов
		IdTable& idtable,	//экземпл€р таблицы итендификаторов
		int n				//строка таблицы итендификаторов
	)
	{
		if (idtable.size == idtable.maxsize)
			throw ERROR_THROW(134);
		//add error with n
		return idtable.table[n];
	};
	int IsId(
		IdTable& idtable,	//возврат: номер строки(если есть) TI_NULLIDX(если нет)
		char id[ID_MAXSIZE],//итендификатор
		char* area)
	{
		for (int i = 0; i < idtable.size; i++)
		{
			if (idtable.table[i].idtype == IDTYPE::F)
			{
				if (!strcmp(idtable.table[i].id, id))
				{
					return i;
				}
			}
			else if (!strcmp(idtable.table[i].id, id) && !strcmp(idtable.table[i].areaOfvisibility, area))
			{
				return i;
			}
		}
		return TI_NULLIDX;
	};
	int IsId(
		IdTable& idtable,	//возврат: номер строки(если есть) TI_NULLIDX(если нет)
		char id[ID_MAXSIZE]//итендификатор
	)
	{
		for (int i = 0; i < idtable.size; i++)
		{

			if (!strcmp(idtable.table[i].id, id))
			{
				return i;
			}
		}
		return TI_NULLIDX;
	};

	void Delete(IdTable& idtable) {
		for (int i = 0; i < idtable.size; i++)
			delete[]idtable.table[i].areaOfvisibility;
		delete& idtable;
	};

}