#include <iostream>
#include "IT.h"
#include <stack>
#include "LT.h"
#include "SemanticAnalyz.h"

namespace SA
{
	/*bool ParamCheck(Log::LOG& log, LT::LexTable lextable, IT::IdTable idtable)
	{
		std::stack<LT::Entry> call;
		std::stack<LT::Entry> called;
		bool error = false; bool er301 = false;
		for (int i = 0; i < lextable.size; i++)
		{
			if (lextable.table[i].idxTI != TI_NULLIDX && idtable.table[lextable.table[i].idxTI].idtype == IT::F)
			{
				int j = idtable.table[lextable.table[i].idxTI].idxfirstLE + 1;
				if (lextable.table[i + 1].lexema[0] == LEX_LEFTHESIS)
				{
					i++;
					while (lextable.table[i].lexema[0] != LEX_RIGHTHESIS)
					{
						if (lextable.table[i].lexema[0] == LEX_ID || lextable.table[i].lexema[0] == LEX_LITERAL)
							call.push(lextable.table[i]);
						i++;

					}
					while (lextable.table[j].lexema != LEX_RIGHTHESIS)
					{
						if (lextable.table[j].lexema == LEX_ID || lextable.table[j].lexema == LEX_NUMBER || lextable.table[j].lexema == LEX_LITERAL)
							called.push(lextable.table[j]);
						j++;
						if (lextable.table[j].lexema == LEX_STRING || lextable.table[j].lexema == LEX_INTEGER)
							j++;
					}

					while (!called.empty() && !call.empty())
					{
						if (idtable.table[call.top().idxTI].iddatatype != idtable.table[called.top().idxTI].iddatatype)
						{
							Log::WriteError(log, Error::geterrorin(300, lextable.table[i].sn, -1));
							error = true;
						}
						call.pop();
						called.pop();
					}
					if (call.size() != called.size() && !er301)
					{
						Log::WriteError(log, Error::geterrorin(301, lextable.table[i].sn, -1));
						er301 = true;
						error = true;
					}
				}
			}
		}
		return error;
	}*/
	bool Typecheck(Log::LOG& log, LT::LexTable lextable, IT::IdTable idtable)
	{
		bool isInt = false,
			isString = false;

		int col = 0;
		int line = 0;
		for (int i = 0; i < lextable.size; i++)
		{
			if (i != 0 && lextable.table[i - 1].sn != lextable.table[i].sn)
			{
				line = lextable.table[i].sn;
				col = 0;
			}
			col++;
			if (lextable.table[i].lexema[0] == LEX_EQUAL)
			{
				switch (idtable.table[lextable.table[i - 1].idxTI].iddatatype)
				{
				case IT::IDDATATYPE::INT:
				case IT::IDDATATYPE::ECHAR:
				case IT::IDDATATYPE::EINT:
				case IT::IDDATATYPE::ESHORT:
					isInt = true;
					break;
				case IT::IDDATATYPE::STR:
				case IT::IDDATATYPE::ESTRING:
					isString = true;
					break;

				}
				if (idtable.table[lextable.table[i - 1].idxTI].idtype == IT::IDTYPE::L)
				{
					throw ERROR_THROW(313);
				}

				while (lextable.table[i].lexema[0] != LEX_SEMICOLON)
				{
					if (lextable.table[i].idxTI != TI_NULLIDX && idtable.table[lextable.table[i].idxTI].idtype != IT::IDTYPE::P)
					{
						if ((idtable.table[lextable.table[i].idxTI].iddatatype == IT::IDDATATYPE::INT
							|| idtable.table[lextable.table[i].idxTI].iddatatype == IT::IDDATATYPE::EINT
							|| idtable.table[lextable.table[i].idxTI].iddatatype == IT::IDDATATYPE::ESHORT
							|| idtable.table[lextable.table[i].idxTI].iddatatype == IT::IDDATATYPE::ECHAR) && isString
							|| (idtable.table[lextable.table[i].idxTI].iddatatype == IT::IDDATATYPE::STR
								|| idtable.table[lextable.table[i].idxTI].iddatatype == IT::IDDATATYPE::ESTRING) && isInt)
						{
							throw ERROR_THROW(304);
						}
					}
					i++;
					col++;
				}
			}
			else if (lextable.table[i].lexema[0] == LEX_PLUS ||
				lextable.table[i].lexema[0] == LEX_MINUS ||
				lextable.table[i].lexema[0] == LEX_PURSAN ||
				lextable.table[i].lexema[0] == LEX_DIRSLASH ||
				lextable.table[i].lexema[0] == LEX_STAR)
			{

				if (lextable.table[i - 1].lexema[0] == LEX_ID || lextable.table[i - 1].lexema[0] == LEX_LITERAL)
				{
					if (idtable.table[lextable.table[i - 1].idxTI].iddatatype == IT::IDDATATYPE::STR &&
						idtable.table[lextable.table[i - 1].idxTI].iddatatype != IT::IDDATATYPE::STR ||
						idtable.table[lextable.table[i - 1].idxTI].iddatatype != IT::IDDATATYPE::STR &&
						idtable.table[lextable.table[i - 1].idxTI].iddatatype == IT::IDDATATYPE::STR)
					{
						
						throw ERROR_THROW(304);
						
					}
				}
				
			}
			isInt = false;
			isString = false;
		}
		return false;
	}
	bool FuncRet(Log::LOG& log, LT::LexTable lextable, IT::IdTable idtable)
	{
		///////////////++++
		int check;
		for (int i = 0; i < lextable.size; i++)
		{
			if (lextable.table[i].lexema[0] == 'f')
			{
				check = i + 1;
				while (lextable.table[i].lexema[0] != 'r' && lextable.table[i].lexema[0] != '}')
				{
					i++;
				}
				if (idtable.table[lextable.table[check].idxTI].iddatatype != idtable.table[lextable.table[i + 1].idxTI].iddatatype)
				{
					throw  ERROR_THROW_IN(307, lextable.table[i].sn,-1);
				}
			}
		}
		
		return false;
	}
	bool ChechParam(Log::LOG& log, LT::LexTable lextable, IT::IdTable idtable)
	{
		
		for (int i = 0; i < lextable.size; i++)
		{
			switch (lextable.table[i].lexema[0])
			{
			case LEX_EXTERN_FUNCTION:
			{
				int temp = i;//по внешим идентификаторам
				i+=2;//по лексемам
				for(int j = IT::IsId(*idtable.externTable,idtable.table[lextable.table[temp].idxTI].id)+1;j<idtable.externTable[0].size&& idtable.externTable[0].table[j].idtype!=IT::IDTYPE::EF;j++,i+=2)
				{
					if (lextable.table[i].lexema[0] != LEX_ID&& lextable.table[i].lexema[0] != LEX_LITERAL)
						throw ERROR_THROW_IN(314, lextable.table[temp].sn, -1);
					if (idtable.table[lextable.table[i].idxTI].iddatatype == IT::IDDATATYPE::STR &&
						idtable.externTable[0].table[j].iddatatype != IT::IDDATATYPE::ESTRING||
						idtable.table[lextable.table[i].idxTI].iddatatype != IT::IDDATATYPE::STR &&
						idtable.externTable[0].table[j].iddatatype == IT::IDDATATYPE::ESTRING)
					{
						throw ERROR_THROW_IN(315, lextable.table[temp].sn, -1);
					}
						
				}
				if (lextable.table[i].lexema[0] == LEX_ID)
				{
					throw ERROR_THROW_IN(316, lextable.table[temp].sn, -1);
				}
				break;
			}
			/*case LEX_ID:
			{
				int pos= i;
				int count = 0;
				int countFact = 0;
				if (idtable.table[lextable.table[i].idxTI].idtype == IT::IDTYPE::F && lextable.table[i - 1].lexema[0] != LEX_ACTIVITY)
				{
					while (lextable.table[i].lexema[0] != LEX_RIGHTHESIS)
					{
						if (lextable.table[i].idxTI != LT_TI_NULLIDX )
						{
							count++;
						}
						i++;
					}
					while (lextable.table[pos].idxTI!=TI_NULLIDX &&lextable.table[idtable.table[lextable.table[pos].idxTI].idxfirstLE].lexema[0] != LEX_RIGHTHESIS)
					{
						if (lextable.table[pos].idxTI != LT_TI_NULLIDX)
						{
							countFact++;
						}
						pos++;
					}
					if (count != countFact)
					{
						throw ERROR_THROW(317);
					}
				}
				break;
			}*/
			//TODO:
			//case LEX_ID:
			//{
			//	if (idtable.table[lextable.table[i].idxTI].idtype == IT::IDTYPE::F&&lextable.table[i-1].lexema[0]!=LEX_ACTIVITY)
			//	{
			//		int j = i;//по  прототипу
			//		i += 2;//не прототипу
			//		for (int l = 0;lextable.table[l].lexema[0]!=LEX_RIGHTHESIS&&
			//			lextable.table[idtable.table[lextable.table[i].idxTI].idxfirstLE].lexema[0]!=LEX_RIGHTHESIS;l++)
			//		{
			//			if (lextable.table[i].lexema[0] != LEX_ID && lextable.table[i].lexema[0] != LEX_LITERAL||
			//				idtable.table[lextable.table[i].idxTI].idtype!=IT::IDTYPE::P&& idtable.table[lextable.table[i].idxTI].idtype != IT::IDTYPE::L)
			//			{
			//				if (lextable.table[i].lexema[0] != lextable.table[idtable.table[lextable.table[i].idxTI].idxfirstLE].lexema[0])
			//				{

			//				}
			//			}
			//			if(idtable.table[lextable.table[i].idxTI].iddatatype!=)
			//		}
			//	}
			//}
			/*
			case LEX_EXTERN_FUNCTION:
			{
				int temp = i;//по внешим идентификаторам
				i+=2;//по лексемам
				int countParm = 0;
				for(int j = lextable.table[temp].idxTI + 1; idtable.externTable[0].table[j].idtype!=IT::IDTYPE::EF;j++,i+=2)
				{
					if (lextable.table[i].lexema[0] != LEX_ID)
						throw ERROR_THROW_IN(606, lextable.table[temp].sn, -1);
					if (idtable.table[lextable.table[i].idxTI].iddatatype == IT::IDDATATYPE::STR &&
						idtable.externTable[0].table[j].iddatatype != IT::IDDATATYPE::ESTRING||
						idtable.table[lextable.table[i].idxTI].iddatatype != IT::IDDATATYPE::STR &&
						idtable.externTable[0].table[j].iddatatype == IT::IDDATATYPE::ESTRING)
					{
						throw ERROR_THROW_IN(607, lextable.table[temp].sn, -1);
					}
						
				}
				if (lextable.table[i].lexema[0] == LEX_ID)
				{
					throw ERROR_THROW_IN(608, lextable.table[temp].sn, -1);
				}
				break;
			}*/
			}
		}
		return true;
	}
	bool DoNotChangeParam(Log::LOG& log, LT::LexTable lextable, IT::IdTable idtable)
	{
		bool error = false;
		for (int i = 1; i < lextable.size; i++)
		{
			if (lextable.table[i].lexema[0] == '=' && idtable.table[lextable.table[i - 1].idxTI].idtype == IT::P && idtable.table[lextable.table[i - 1].idxTI].iddatatype == IT::STR)
			{
				Log::WriteError(log, Error::geterrorin(308, lextable.table[i].sn, -1));
				error = true;
			}
		}
		return false;
	}
	bool CheckOwerflow(Log::LOG& log, LT::LexTable lextable, IT::IdTable idtable)
	{
		for (int i = 0; i < idtable.size; i++)
		{
			if (idtable.table[i].idtype == IT::IDTYPE::L)
			{
				if (idtable.table[i].iddatatype == IT::IDDATATYPE::INT)
				{
					if (lextable.table[idtable.table[i].idxfirstLE - 1].lexema[0] == LEX_DIRSLASH &&
						idtable.table[i].value.vint == 0)
					{
						throw ERROR_THROW(310);
					}
				}

				else
				{
					if (idtable.table[i].value.vstr.len > 255)
					{
						throw ERROR_THROW(309);
					}
				}

			}
		}
		return false;
	}
	void SemanticAnalyse(Log::LOG& log, LT::LexTable lextable, IT::IdTable idtable)
	{
	
		 FuncRet(log, lextable, idtable);
		 Typecheck(log, lextable, idtable);
		 ChechParam(log, lextable, idtable);
		 DoNotChangeParam(log, lextable, idtable);
		 CheckOwerflow(log, lextable, idtable);

		
	}
}