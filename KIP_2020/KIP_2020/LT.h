#pragma once
#include "IT.h"
#define LEXEMA_FIXSIZE 2
#define LT_MAXSIZE 4096
#define LT_TI_NULLIDX 0XFFFFFFFF
#define LEX_BYTE		't'
#define LEX_STRING		't'
#define LEX_ID			'i'
#define LEX_START		's'
#define LEX_LITERAL		'l'
#define LEX_ACTIVITY	'f'
#define LEX_NEW			'd'
#define LEX_GIVE		'r'
#define LEX_SEMICOLON	';'
#define LEX_COMMA		','
#define LEX_LEFTBRACE	'{'
#define LEX_RIGHTBRACE	'}'
#define LEX_LEFTHESIS	'('
#define LEX_RIGHTHESIS	')'
#define LEX_PLUS		'+'
#define LEX_MINUS		'-'
#define LEX_STAR		'*'
#define LEX_DIRSLASH	'/'
#define LEX_PURSAN		'%'
#define LEX_EQUAL		'='
#define LEX_LEFTSIGMA   '<'
#define LEX_RIGHTSIGMA  '>'
#define LEX_LIBRARY		'#'
#define LEX_LOOP		'o'
#define LEX_OUTPUT		'p'
#define LEX_EXTERN_FUNCTION 'e'
#define LEX_EXTERN_IDENTIFICATOR 'u'
#define LEX_EXTERN_SHORT	'2'
#define LEX_EXTERN_CHAR		'1'
#define LEX_EXTERN_STRING	'0'
#define LEX_EXTERN_INT		'4'

namespace LT
{
	struct Entry //строка таблицы лексем
	{
		char lexema[LEXEMA_FIXSIZE] = { "\0" };
		int sn; //номер строки в исходном тексте
		int idxTI = LT_TI_NULLIDX;	//индекс итендификатора в таблице
	};
	struct LexTable //экземпл€р таблицы лексем
	{
		int maxsize; //емкость <LT_MAXSIZE
		int size; //текущий размер таблицы лексем
		Entry* table;	//массив строк
	};
	bool IsExtern(int idXTi);//¬нешний идентификатор или внутренный
	LexTable Create(//создать таблицу лексем
		int size//емкость таблицы лексем < LT_MAXSIZE
	);
	void Add(	//добавить строку в таблицу лексем
		LexTable& lextable,		//экземпл€р таблицы лексем
		Entry entry	//строка таблицы лексем
	);
	Entry GetEntry(	//получить строку таблицы лексем
		LexTable& lextable, //экземпл€р
		int n //номер получаемой строки
	);
	void Delete(LexTable& lextable);	//удалить таблицу лексем
}