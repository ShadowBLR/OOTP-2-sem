#include "CodeGeneration.h"
#include <stack>
#include "LT.h"
#include "Out.h"
using namespace std;
namespace CG
{
	void CodeGeneration(LT::LexTable lextable,IT::IdTable idtable, Out::OUT out)
	{
		bool isLoop = false;
		int countParam = 0;
		*(out.stream) << "\n.586\n\t.model flat, stdcall\n\tincludelib libucrt.lib\n\tincludelib kernel32.lib\n\t	\
			includelib ../Debug/MathLibrary.lib\n\tincludelib ../Debug/IoLibrary.lib\n\tExitProcess PROTO :SDWORD\n";
		for (int i = 0; i < idtable.externTable->size; i++)
		{
			if (idtable.externTable->table[i].idtype == IT::IDTYPE::EF)
			{
				*(out.stream) <<"\n\t"<<idtable.externTable->table[i].id << " PROTO:";
				countParam = 0;
			}
			else
			{
				if (countParam != 0)
				{
					*(out.stream) << " ,:";
				}
				countParam++;
				switch (idtable.externTable->table[i].iddatatype)
				{
				case IT::IDDATATYPE::ECHAR:
					*(out.stream)<< "SDWORD";
					break;
				case IT::IDDATATYPE::EINT:
					*(out.stream) << "SDWORD";
					break;
				case IT::IDDATATYPE::ESHORT:
					*(out.stream) << "WORD";
					break;
				case IT::IDDATATYPE::ESTRING:
					*(out.stream) << "SDWORD";
					break;
				}
			}
		}
		*(out.stream) << "\n.stack 4096\n";
		//////////////////////////////////////////CONST SEGMENT////////////////////////////////////////////////
		*(out.stream) << ".const\n";
		*(out.stream) << "ower BYTE \"OWERFLOW\", 0\n";
		for (int i = 0; i < idtable.size; i++)
		{
			if (idtable.table[i].idtype == IT::L)
			{
				*(out.stream) << "\t" <<idtable.table[i].areaOfvisibility <<idtable.table[i].id;
				if (idtable.table[i].iddatatype == IT::IDDATATYPE::STR)
				{
					*(out.stream) << " BYTE " << idtable.table[i].value.vstr.str << ", 0\n";
				}
				if (idtable.table[i].iddatatype == IT::IDDATATYPE::INT)
				{
					*(out.stream) << " SDWORD " << idtable.table[i].value.vint << endl;
				}
			}
		}
		///////////////////////////////////////////DATA SEGMENT////////////////////////////////////////
		*(out.stream) << ".data\n";
		for (int i = 0; i < idtable.size; i++)
		{
				if(idtable.table[i].idtype == IT::IDTYPE::V)//|| idtable.table[i].idtype == IT::IDTYPE::P
				{
					*(out.stream) << "\t" << idtable.table[i].areaOfvisibility<<idtable.table[i].id;
					if (idtable.table[i].iddatatype == IT::IDDATATYPE::STR)
					{
						*(out.stream) << " SDWORD 0\n";
					}
					if (idtable.table[i].iddatatype == IT::IDDATATYPE::INT)
					{
						*(out.stream) << " SDWORD 0\n";
					}
				}
			
		}
		/////////////////////////////////////CODE SEGMENT///////////////////////////////////////////
		stack<string> stk;
		int num_of_ret = 0,
			num_of_ends = 0;
		string func_name = "";						// имя локальной функции
		bool flag_func = false,					// внутри локальной функции?
			flag_ret = false,					// есть give?
			flag_body = false;					// внутри функции start?
		int countLoop = 0;
		*(out.stream) << "\n.code\n\n";
		int countp=0;
		for (int i = 0; i < lextable.size; i++)
		{
			switch (lextable.table[i].lexema[0])
			{
			case LEX_ACTIVITY:
			{
				*(out.stream) << (func_name = idtable.table[lextable.table[++i].idxTI].id) << " PROC ";
				while (lextable.table[i].lexema[0] != LEX_RIGHTHESIS)
				{
					if (lextable.table[i].idxTI!=-1&&idtable.table[lextable.table[i].idxTI].idtype == IT::IDTYPE::P)
					{
						if (countp != 0)
						{
							*(out.stream) << ", ";
						}
						*(out.stream) << idtable.table[lextable.table[i].idxTI].areaOfvisibility<< idtable.table[lextable.table[i].idxTI].id << " : ";
						if (idtable.table[lextable.table[i].idxTI].idtype == IT::IDDATATYPE::INT)
						{
							*(out.stream) << "SDWORD";
						}
						else
						{
							*(out.stream) << "SDWORD";
						}
						countp++;
					}
					i++;
				}
				flag_func = true;
				*(out.stream) << endl;
				break;
			}
			case LEX_START:
			{
				flag_body = true;
				*(out.stream) << "main PROC\n";
				break;
			}
			case LEX_OUTPUT:
			{
				if (lextable.table[i+1].idxTI != TI_NULLIDX && idtable.table[lextable.table[i+1].idxTI].iddatatype == IT::IDDATATYPE::INT)
				{
					*(out.stream) << "invoke bdisplay, ";
					*(out.stream)  << idtable.table[lextable.table[i+1].idxTI].areaOfvisibility << idtable.table[lextable.table[i+1].idxTI].id << "\n";
					
				}
				else if (lextable.table[i+1].idxTI != TI_NULLIDX && idtable.table[lextable.table[i+1].idxTI].iddatatype == IT::IDDATATYPE::STR)
				{
					
					*(out.stream) << "invoke strdisplay, ";
					if (idtable.table[lextable.table[i + 1].idxTI].idtype == IT::IDTYPE::L)
					{
						*(out.stream) << " OFFSET " << idtable.table[lextable.table[i + 1].idxTI].areaOfvisibility << idtable.table[lextable.table[i + 1].idxTI].id << "\n";
					}
					else
					{
						*(out.stream) << idtable.table[lextable.table[i + 1].idxTI].areaOfvisibility << idtable.table[lextable.table[i + 1].idxTI].id << "\n";
					}
					*(out.stream) << "pop eax\n";
				}
				++i;
				break;
			}
			case LEX_EXTERN_FUNCTION:
			{
				int g = i;

				*(out.stream) << "invoke " << idtable.table[lextable.table[i].idxTI].id << " ";
				while (lextable.table[++g].lexema[0] != '@')
				{
					*(out.stream) << "\, " << idtable.table[lextable.table[g].idxTI].areaOfvisibility << idtable.table[lextable.table[g].idxTI].id;
				}
				*(out.stream) << "\n";
				i = g;

				*(out.stream) << "push eax\n";
				break;
			}
			case LEX_EQUAL:
			{
				int result_position = i - 1;
				while (lextable.table[i].lexema[0] != LEX_SEMICOLON)
				{
					switch (lextable.table[i].lexema[0])
					{
						case LEX_EXTERN_FUNCTION:
						{
							int g =i;
						
							*(out.stream) << "invoke " << idtable.table[lextable.table[i].idxTI].id << " ";
							while (lextable.table[++g].lexema[0] != '@')
							{
								*(out.stream) <<", "<< idtable.table[lextable.table[g].idxTI].areaOfvisibility << idtable.table[lextable.table[g].idxTI].id;
							}
							*(out.stream) << "\n";
							i = g;
							
							*(out.stream) << "push eax\n";
							break;
						}
						case LEX_ID:
						{
							if (idtable.table[lextable.table[i].idxTI].idtype == IT::IDTYPE::F)
							{
								int g = i;

								*(out.stream) << "invoke " << idtable.table[lextable.table[i].idxTI].id << " ";
								while (lextable.table[++g].lexema[0] != '@')
								{
									*(out.stream) << ", " << idtable.table[lextable.table[g].idxTI].areaOfvisibility << idtable.table[lextable.table[g].idxTI].id;
								}
								*(out.stream) << "\n";
								i = g;

								*(out.stream) << "push eax\n";
							}
							else if (lextable.table[i - 1].lexema[0] != LEX_BYTE)
							{
								if (idtable.table[lextable.table[i].idxTI].iddatatype == IT::IDDATATYPE::STR||
									idtable.table[lextable.table[i].idxTI].iddatatype == IT::IDDATATYPE::ESTRING)
								{
									*(out.stream) << "\tpush " << idtable.table[lextable.table[i].idxTI].areaOfvisibility << idtable.table[lextable.table[i].idxTI].id << endl;
								}
								else
								{
									*(out.stream) << "\tpush " << idtable.table[lextable.table[i].idxTI].areaOfvisibility << idtable.table[lextable.table[i].idxTI].id << endl;
								}
							}
							break;
						}
						case LEX_LITERAL:
						{
							if (idtable.table[lextable.table[i].idxTI].iddatatype == IT::IDDATATYPE::ESTRING ||
								idtable.table[lextable.table[i].idxTI].iddatatype == IT::IDDATATYPE::STR)
							{
								*(out.stream) << "\tpush OFFSET " << idtable.table[lextable.table[i].idxTI].areaOfvisibility << idtable.table[lextable.table[i].idxTI].id << "\n";
							}
							else
							{
								*(out.stream) << "\tpush " << idtable.table[lextable.table[i].idxTI].areaOfvisibility << idtable.table[lextable.table[i].idxTI].id << "\n";
							}
							break;
						}
						case LEX_STAR:
						{
							*(out.stream) << "\tpop eax\n\tpop ebx\n";
							*(out.stream) << "\timul ebx\n";
							*(out.stream) << "\tjo OWERFLOW\n\tpush eax\n";			
							break;
						}
						case LEX_PLUS:
						{
							*(out.stream) << "\tpop eax\n\tpop ebx\n";
							*(out.stream) << "\tadd eax, ebx\n\tpush eax\n";
							break;
						}
						case LEX_MINUS:
						{
							*(out.stream) << "\tpop ebx\n\tpop eax\n";
							*(out.stream) << "\tsub eax, ebx\n\tpush eax\n";
							break;
						}
						case LEX_DIRSLASH:
						{
							*(out.stream) << "\tpop ebx\n\tpop eax\n";
							*(out.stream) << "\ttest ebx,ebx\n";
							*(out.stream) << "\tjz theend\n";
							*(out.stream) << "\tidiv ebx\n\tpush eax\n";
							
							break;
						}
						case LEX_PURSAN:
						{
							*(out.stream) << "\tpop ebx\n\tpop eax\n";
							*(out.stream) << "\tmov edx,0\n";
							*(out.stream) << "\ttest ebx,ebx\n";
							*(out.stream) << "\tjz theend\n";
							*(out.stream) << "\tidiv ebx\n\tpush edx\n";	
							break;
						}
					}
					i++;
				}
				*(out.stream) << "\pop " << idtable.table[lextable.table[result_position].idxTI].areaOfvisibility<<idtable.table[lextable.table[result_position].idxTI].id << "\n";
				break;
			}
			case LEX_GIVE:
			{
				*(out.stream) << "\tpush ";
				i++;
				if (idtable.table[lextable.table[i].idxTI].idtype == IT::IDTYPE::L)
				{
					if (idtable.table[lextable.table[i].idxTI].iddatatype == IT::IDDATATYPE::INT)
					{
						*(out.stream) << idtable.table[lextable.table[i].idxTI].value.vint << endl;
					}
					else
					{
						*(out.stream) <<" OFFSET "<<idtable.table[lextable.table[i].idxTI].value.vstr.str << endl;
					}
				}
				else
				{
					if (idtable.table[lextable.table[i].idxTI].idtype == IT::IDDATATYPE::STR ||
						idtable.table[lextable.table[i].idxTI].idtype == IT::IDDATATYPE::ESTRING)
					{
						*(out.stream) <<" OFFSET "<< idtable.table[lextable.table[i].idxTI].areaOfvisibility << idtable.table[lextable.table[i].idxTI].id << endl;
					}
					else
					{
						*(out.stream)<< idtable.table[lextable.table[i].idxTI].areaOfvisibility << idtable.table[lextable.table[i].idxTI].id << endl;
					}
				}
				break;
			}
			case LEX_LOOP:
			{
				isLoop = true;
				generateLoop(lextable, idtable, out, i);
			}
			case LEX_RIGHTBRACE:
			{
				if (flag_body  && !flag_func&&i==lextable.size-1)
				{
					*(out.stream) << "\tjmp theend\n";
					*(out.stream) << "\tOWERFLOW:\n";
					*(out.stream) << "\tinvoke strdisplay, OFFSET ower\n";
					*(out.stream) << "theend:\n";
					flag_ret = false;
					*(out.stream) << "\tpush 0\n";
					*(out.stream) << "\tcall ExitProcess\nmain ENDP\nend main";
				}
				else if (flag_func)
				{
					if (flag_ret)
					{
						*(out.stream) << "local" << num_of_ret++ << ":\n";
						*(out.stream) << "\tpop eax\n\tret\n";
						flag_ret = false;
					}
					*(out.stream) << "\tpop eax\n\tret\n";
					*(out.stream) << func_name << " ENDP\n\n";
					flag_func = false;
				}
				if (isLoop)isLoop = false;

				break;
			}
			}
		}
	}

	void generateLoop(LT::LexTable lextable, IT::IdTable idtable, Out::OUT out, int i)
	{
		for (; i < lextable.size; i++)
		{
			switch (lextable.table[i].lexema[0])
			{
			case LEX_OUTPUT:
			{
				if (lextable.table[i + 1].idxTI != TI_NULLIDX && idtable.table[lextable.table[i + 1].idxTI].iddatatype == IT::IDDATATYPE::INT)
				{
					*(out.stream) << "invoke bdisplay, ";
					*(out.stream) << idtable.table[lextable.table[i + 1].idxTI].areaOfvisibility << idtable.table[lextable.table[i + 1].idxTI].id << "\n";

				}
				else if (lextable.table[i + 1].idxTI != TI_NULLIDX && idtable.table[lextable.table[i + 1].idxTI].iddatatype == IT::IDDATATYPE::STR)
				{
					*(out.stream) << "invoke strdisplay, ";
					if (idtable.table[lextable.table[i + 1].idxTI].idtype == IT::IDTYPE::L)
					{
						*(out.stream) << " OFFSET " << idtable.table[lextable.table[i + 1].idxTI].areaOfvisibility << idtable.table[lextable.table[i + 1].idxTI].id << "\n";
					}
					else
					{
						*(out.stream)  << idtable.table[lextable.table[i + 1].idxTI].areaOfvisibility << idtable.table[lextable.table[i + 1].idxTI].id << "\n";
					}

				}
				++i;
				break;
			}
			/*case LEX_ID:
			{
				if (lextable.table[i - 1].lexema[0] != LEX_BYTE)
				{
					if (idtable.table[lextable.table[i].idxTI].iddatatype == IT::IDDATATYPE::STR ||
						idtable.table[lextable.table[i].idxTI].iddatatype == IT::IDDATATYPE::ESTRING)
					{
						*(out.stream) << "\tpush " << idtable.table[lextable.table[i].idxTI].areaOfvisibility << idtable.table[lextable.table[i].idxTI].id << endl;
					}
					else
					{
						*(out.stream) << "\tpush " << idtable.table[lextable.table[i].idxTI].areaOfvisibility << idtable.table[lextable.table[i].idxTI].id << endl;
					}
				}
				break;
			}*/
			case LEX_RIGHTBRACE:
			{
				*(out.stream) << "pop ecx\n";
				return;
			}
			case LEX_EQUAL:
			{
				int result_position = i - 1;
				while (lextable.table[i].lexema[0] != LEX_SEMICOLON)
				{
					switch (lextable.table[i].lexema[0])
					{
					case LEX_EXTERN_FUNCTION:
					{
						int g = i;

						*(out.stream) << "invoke " << idtable.table[lextable.table[i].idxTI].id << " ";
						while (lextable.table[++g].lexema[0] != '@')
						{
							*(out.stream) << "\, " << idtable.table[lextable.table[g].idxTI].areaOfvisibility << idtable.table[lextable.table[g].idxTI].id;
						}
						*(out.stream) << "\n";
						i = g;

						*(out.stream) << "push eax\n";
						break;
					}
					case LEX_ID:
					{
						//todo
						if (lextable.table[i - 1].lexema[0] != LEX_BYTE && result_position != i - 1)
						{
							if (idtable.table[lextable.table[i].idxTI].iddatatype == IT::IDDATATYPE::STR ||
								idtable.table[lextable.table[i].idxTI].iddatatype == IT::IDDATATYPE::ESTRING)
							{
								*(out.stream) << "\tpush OFFSET " << idtable.table[lextable.table[i].idxTI].areaOfvisibility << idtable.table[lextable.table[i].idxTI].id << endl;
							}
							else
							{
								*(out.stream) << "\tpush " << idtable.table[lextable.table[i].idxTI].areaOfvisibility << idtable.table[lextable.table[i].idxTI].id << endl;
							}
						}
						break;
					}
					case LEX_LITERAL:
					{
						if (idtable.table[lextable.table[i].idxTI].iddatatype == IT::IDDATATYPE::ESTRING ||
							idtable.table[lextable.table[i].idxTI].iddatatype == IT::IDDATATYPE::STR)
						{
							*(out.stream) << "\tpush OFFSET " << idtable.table[lextable.table[i].idxTI].areaOfvisibility << idtable.table[lextable.table[i].idxTI].id << "\n";
						}
						else
						{
							*(out.stream) << "\tpush " << idtable.table[lextable.table[i].idxTI].areaOfvisibility << idtable.table[lextable.table[i].idxTI].id << "\n";
						}
						break;
					}
					case LEX_STAR:
					{
						*(out.stream) << "\tpop eax\n\tpop ebx\n";
						*(out.stream) << "\timul ebx\n";
						*(out.stream) << "\tjo OWERFLOW\n\tpush eax\n";
						break;
					}
					case LEX_PLUS:
					{
						*(out.stream) << "\tpop eax\n\tpop ebx\n";
						*(out.stream) << "\tadd eax, ebx\n\tpush eax\n";
						*(out.stream) << "\tjo OWERFLOW\n\tpush eax\n";
						break;
					}
					case LEX_MINUS:
					{
						*(out.stream) << "\tpop ebx\n\tpop eax\n";
						*(out.stream) << "\tsub eax, ebx\n\tpush eax\n";
						*(out.stream) << "\tjo OWERFLOW\n\tpush eax\n";
						break;
					}
					case LEX_DIRSLASH:
					{
						*(out.stream) << "\tpop ebx\n\tpop eax\n";
						*(out.stream) << "\ttest ebx,ebx\n";
						*(out.stream) << "\tjz theend\n";
						*(out.stream) << "\tidiv ebx\n\tpush eax\n";

						break;
					}
					case LEX_PURSAN:
					{
						*(out.stream) << "\tpop ebx\n\tpop eax\n";
						*(out.stream) << "\tmov edx,0\n";
						*(out.stream) << "\ttest ebx,ebx\n";
						*(out.stream) << "\tjz theend\n";
						*(out.stream) << "\tidiv ebx\n\tpush edx\n";
						break;
					}
					}
					i++;
				}
				*(out.stream) << "\pop " << idtable.table[lextable.table[result_position].idxTI].areaOfvisibility << idtable.table[lextable.table[result_position].idxTI].id << "\n";
				break;
			}
			case LEX_LOOP:
			{
				int pref = 0;
				i++;
					++i;
					if (lextable.table[i].idxTI != LT_TI_NULLIDX)
					{
						if (idtable.table[lextable.table[i].idxTI].iddatatype != IT::IDDATATYPE::STR &&
							idtable.table[lextable.table[i].idxTI].iddatatype != IT::IDDATATYPE::ECHAR)
						{
							if (idtable.table[lextable.table[i].idxTI].idtype == IT::IDTYPE::L)
							{
								*(out.stream) << "\n\tmov ecx," << idtable.table[lextable.table[i].idxTI].value.vint << "\n";
							}
							else
							{
								*(out.stream) << "\n\tmov ecx," << idtable.table[lextable.table[i].idxTI].areaOfvisibility << idtable.table[lextable.table[i].idxTI].id << "\n";
							}
							*(out.stream) << "\ndec ecx\n";
							*(out.stream) << "\ncmp ecx,0\n";
							*(out.stream) << "\njg LOOP"<<i<<"\n";
							*(out.stream) << "\nneg ecx\n";

							*(out.stream) << "LOOP"<<i << ":\n";
							*(out.stream) << "push ecx\n";
							pref = i;
							i += 2;
							if (lextable.table[i].lexema[0] == LEX_LEFTBRACE)
							{
								
									generateLoop(lextable, idtable, out, i);
								
							}

							*(out.stream) << "\nLOOP LOOP" << pref<<"\n";
							return;
						}
					}

			}
			}
		}
	}
}