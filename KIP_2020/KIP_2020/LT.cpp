#include "LT.h"
#include "Error.h"
#include <fstream>
#include <iostream>
#include <stdlib.h>
#include <cstdarg>

namespace LT
{
	LexTable Create(int size)
	{
		if (size > LT_MAXSIZE)
		{
			throw ERROR_THROW(131);
		}
		LexTable out;
		out.maxsize = size;
		out.size = 0;
		out.table = new Entry[size];
		return out;
	}
	bool IsExtern(int idXTi)
	{
		return idXTi >= TI_MAXSIZE;
	}
	void Add(	//�������� ������ � ������� ������
		LexTable& lextable,		//��������� ������� ������
		Entry entry	//������ ������� ������
	)
	{
		if (lextable.size == lextable.maxsize)
			throw ERROR_THROW(132);
		lextable.table[lextable.size++] = entry;

		//errorcheck
	}

	Entry GetEntry(	//�������� ������ ������� ������
		LexTable& lextable, //���������
		int n //����� ���������� ������
	)
	{
		if (lextable.size == lextable.maxsize)
			throw ERROR_THROW(135);
		return lextable.table[n];
	};

	void Delete(LexTable& lextable) {
		delete& lextable;
	};
}