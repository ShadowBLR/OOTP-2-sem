#pragma once
#include "Greibach.h"
#include "LT.h"
#define GRB_ERROR_SERIES 600
#define NS(n)	GRB::Rule::Chain::N(n)
#define TS(n)	GRB::Rule::Chain::T(n)
#define ISNS(n)	GRB::Rule::Chain::isN(n)
/*


*/
namespace GRB
{
	Greibach greibach
	(
		NS('S'), TS('$'),                     // стартовый символ, дно стека
		7,									  // количество правил
		Rule(
			NS('S'), GRB_ERROR_SERIES + 0,    // неверная структура программы
			6,                                // 
			Rule::Chain(4, TS('s'), TS('{'), NS('N'), TS('}')),
			Rule::Chain(8, TS('#'), TS('<'), TS('i'), TS('>'), TS('s'), TS('{'), NS('N'), TS('}')),
			Rule::Chain(9, TS('#'), TS('<'), TS('i'), TS('>'), NS('L'), TS('s'), TS('{'), NS('N'), TS('}')),
			Rule::Chain(13, TS('t'), TS('f'), TS('i'), TS('('), NS('F'), TS(')'), TS('{'), NS('N'),TS('r'),NS('E'),TS(';'), TS('}'), NS('S')),
			Rule::Chain(17, TS('#'), TS('<'), TS('i'), TS('>'), TS('t'), TS('f'), TS('i'), TS('('), NS('F'), TS(')'), TS('{'), NS('N'),TS('r'),NS('E'),TS(';'), TS('}'), NS('S')),
			Rule::Chain(18, TS('#'), TS('<'), TS('i'), TS('>'),NS('L'), TS('t'), TS('f'), TS('i'), TS('('), NS('F'), TS(')'), TS('{'), NS('N'),TS('r'), NS('E'), TS(';'),TS('}'), NS('S'))
			
				),
				Rule(
					NS('N'), GRB_ERROR_SERIES + 1,    // конструкции в функциях
					16,                               
					Rule::Chain(5, TS('d'), TS('t'), TS('i'), TS(';'), NS('N')),
					Rule::Chain(4, TS('i'), TS('='), NS('E'), TS(';')),
					Rule::Chain(5, TS('i'), TS('='), NS('E'), TS(';'), NS('N')),
					Rule::Chain(9, TS('d'), TS('t'), TS('f'), TS('i'), TS('('), NS('F'), TS(')'), TS(';'), NS('N')),
					Rule::Chain(4, TS('p'), TS('i'), TS(';'), NS('N')),
					Rule::Chain(4, TS('p'), TS('l'), TS(';'), NS('N')),
					Rule::Chain(4, TS('d'), TS('t'), TS('i'), TS(';')),
					Rule::Chain(5, TS('i'), TS('('), NS('W'), TS(')'), TS(';')),
					Rule::Chain(3, TS('p'), TS('i'), TS(';')),
					Rule::Chain(3, TS('p'), TS('l'), TS(';')),
					Rule::Chain(7, TS('i'), TS('('), TS('i'), TS(')'), TS('{'), NS('N'), TS('}')),
					Rule::Chain(8, TS('i'), TS('('), TS('i'), TS(')'), TS('{'), NS('N'), TS('}'),NS('N')),
					Rule::Chain(8, TS('o'), TS('('), TS('i'), TS(')'), TS('{'), NS('N'), TS('}'),NS('N')),
					Rule::Chain(7, TS('o'), TS('('), TS('i'), TS(')'), TS('{'), NS('N'), TS('}')),
					Rule::Chain(8, TS('o'), TS('('), TS('l'), TS(')'), TS('{'), NS('N'), TS('}'), NS('N')),
					Rule::Chain(7, TS('o'), TS('('), TS('l'), TS(')'), TS('{'), NS('N'), TS('}'))
				),
				Rule(
					NS('E'), GRB_ERROR_SERIES + 2,    // ошибка в выражении
					10,                                // 
					Rule::Chain(1, TS('l')),
					Rule::Chain(1, TS('i')),
					Rule::Chain(1, TS('e')),
					Rule::Chain(3, TS('('), NS('E'), TS(')')),
					Rule::Chain(4, TS('i'), TS('('), NS('W'), TS(')')),
					Rule::Chain(4, TS('e'), TS('('), NS('W'), TS(')')),
					Rule::Chain(2, TS('i'), NS('M')),
					Rule::Chain(2, TS('l'), NS('M')),
					Rule::Chain(4, TS('('), NS('E'), TS(')'), NS('M')),
					Rule::Chain(5, TS('i'), TS('('), NS('W'), TS(')'), NS('M'))
				),
				Rule(
					NS('F'), GRB_ERROR_SERIES + 3,    // ошибка в параметрах функции
					2,                                // 
					Rule::Chain(2, TS('t'), TS('i')),
					Rule::Chain(4, TS('t'), TS('i'), TS(','), NS('F'))
				),
				Rule(
					NS('W'), GRB_ERROR_SERIES + 4,    // ошибка в параметрах вызываемой функции 
					4,                                // 
					Rule::Chain(1, TS('i')),
					Rule::Chain(1, TS('l')),
					Rule::Chain(3, TS('i'), TS(','), NS('W')),
					Rule::Chain(3, TS('l'), TS(','), NS('W'))
					
				),
				Rule(
					NS('M'), GRB_ERROR_SERIES + 5,    // оператор
					5,								  //
					Rule::Chain(2,TS(LEX_PLUS),NS('E')),
					Rule::Chain(2,TS(LEX_MINUS),NS('E')),
					Rule::Chain(2,TS(LEX_DIRSLASH),NS('E')),
					Rule::Chain(2,TS(LEX_STAR),NS('E')),
					Rule::Chain(2,TS(LEX_PURSAN),NS('E'))

				),
				Rule(
					NS('L'), GRB_ERROR_SERIES + 6,//библиотеки
					2,
					Rule::Chain(4, TS('#'), TS('<'), TS('i'), TS('>')),
					Rule::Chain(5, TS('#'), TS('<'), TS('i'), TS('>'), NS('L'))
				)
	);
}
