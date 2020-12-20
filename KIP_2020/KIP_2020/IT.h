#pragma once
#define TI_AREA_SIZE	10
#define ID_MAXSIZE		10 //макс кол-во символов в идентиф
#define	TI_MAXSIZE		4096 //макс кол-во строк в табл итендификаторов
#define TI_INT_DEFAULT	0x00000000	//значение int по дефолту
#define	TI_STR_DEFAULT	0x00		//значение string по дефолту
#define	TI_NULLIDX		0xffffffff	//нет элемента таблицы итендификаторов
#define	TI_STR_MAXSIZE	255

namespace IT	//таблица итендификаторов
{
	enum IDDATATYPE { DEF = 0, INT = 1, STR = 2 ,EINT,ESHORT,ECHAR,ESTRING};//таблица данных итендификаторов
	enum IDTYPE { V = 1, F = 2, P = 3, L = 4, N=5,LIB=6 ,EF,EP};//типы идентификаторов - переменная функция параметр литерал,no def,library

	struct Entry //строка таблицы итендификаторов
	{
		int idxfirstLE; //индекс первой строки в таблице лексем
		char* areaOfvisibility = nullptr;
		char id[ID_MAXSIZE]; //итендификатор
		IDDATATYPE iddatatype = IDDATATYPE::DEF; //тип данных
		IDTYPE idtype = IDTYPE::N; //тип итендификатора

		union {
			int vint; //значение integer
			struct
			{
				char len;//кол-во символов в string
				char str[TI_STR_MAXSIZE - 1];//символы стринг
			} vstr;//значение sting
		} value; //значение итендификатора
	};

	struct IdTable		//экземпляр таблицы ид
	{
		int maxsize;	//ёмкость таблицы
		int size;		//текущий размер
		Entry* table;	//массив строк таблицы итендификаторов
		IdTable* externTable;
	};
	IdTable Create(	//создать таблицу ID
		int size	//ёмкость
	);
	void Add(
		IdTable& idtable,	//экземпляр таблицы итендификаторов
		Entry entry		//строка таблицы итендификаторов
	);
	Entry GetEntry(	//получить строку таблицы итендификаторов
		IdTable& idtable,	//экземпляр таблицы итендификаторов
		int n				//строка таблицы итендификаторов
	);
	int IsId(
		IdTable& idtable,	//возврат: номер строки(если есть) TI_NULLID(если нет)
		char id[ID_MAXSIZE], //итендификатор
		char* area
	);
	int IsId(
		IdTable& idtable,	//возврат: номер строки(если есть) TI_NULLID(если нет)
		char id[ID_MAXSIZE] //итендификатор
	);

	void Delete(IdTable& idtable);	//удалить таблицу итендификаторов
}