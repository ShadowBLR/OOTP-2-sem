#include "LexAnaliz.h"
#include <vector>
#include "FST.h"
#include "Graphs.h"
void check_chain(In::IN in, Out::OUT out, Log::LOG log,LT::LexTable &lextable,IT::IdTable &idtable)
{
	int countLt = 0;
	char* areaArr[TI_AREA_SIZE];//область видимости
	areaArr[0] = new char[] { "global" };
	int level = 0;//глубина области видимости

	char* str = new char[30];

	bool isLoop = false;
	bool isactivity = false;
	bool isIdentificator = false;
	bool isLiteral = false;
	bool isnew = false;
	bool isByte = false;
	bool isLibrary = false;
	bool isString = false;
	bool isParam = false;
	bool isSigma=false;
	bool isIOLibrary = false;
	bool isRecognized = true;//если  не распознана хотя бы 1 автоматом

	int counter = 0;
	int lastLine = 0;
	int countLoop=0;

	 lextable = LT::Create(in.lexemPos);
	 idtable = IT::Create(in.lexemPos);
	 idtable.externTable = new IT::IdTable[1];
	 *idtable.externTable= IT::Create(TI_MAXSIZE);
	for (int i = 0; i < in.lexemPos; i++)
	{
		int k = 0;
		for (; k < strlen(in.lexems[i].lexem); k++)
		{
			str[k] = in.lexems[i].lexem[k];
		}
		str[k] = '\0';
		LT::Entry lexEntry;
		IT::Entry IdEntry;
		lexEntry.sn = in.lexems[i].line;
		if (lastLine != lexEntry.sn)
		{
			counter = 0;
			lastLine = lexEntry.sn;
		}
		counter += strlen(str);



		FST::FST l_library(str, L_LIBRARY);
		if (execute(l_library))
		{
			lexEntry.lexema[0] = LEX_LIBRARY;
			LT::Add(lextable, lexEntry);
			isLibrary = true;
			continue;
		}

		FST::FST l_leftSigma(str, L_LEFTSIGMA);
		if(execute(l_leftSigma))
		{
			if (!isSigma&&isLibrary)
			{
				isSigma = true;
			}
			else
			{
				throw  ERROR_THROW_IN(139,lexEntry.sn,0);
			}
			lexEntry.lexema[0] = LEX_LEFTSIGMA;
			LT::Add(lextable, lexEntry);
			continue;
		}
		FST::FST l_rightSigma(str, L_RIGHTSIGMA);
		if (execute(l_rightSigma))
		{
			if (!isSigma)
			{
				throw ERROR_THROW(112);
			}
			lexEntry.lexema[0] = LEX_RIGHTSIGMA;
			LT::Add(lextable, lexEntry);
			isSigma = !isSigma;
			continue;
		}
		FST::FST l_new(str, L_NEW);
		if (execute(l_new))
		{
			isnew = true;
			lexEntry.lexema[0] = LEX_NEW;
			LT::Add(lextable, lexEntry);
			continue;
		}

		FST::FST l_byte(str, L_BYTE);
		if (execute(l_byte))
		{
			lexEntry.lexema[0] = LEX_BYTE;
			LT::Add(lextable, lexEntry);
			isByte = true;
			continue;
		}
		FST::FST l_integer(str, L_INTEGER);
		if (execute(l_integer))
		{
			lexEntry.lexema[0] = LEX_BYTE;
			LT::Add(lextable, lexEntry);
			isByte = true;
			continue;
		}

		FST::FST l_string(str, L_STRING);
		if (execute(l_string))
		{
			lexEntry.lexema[0] = LEX_STRING;
			LT::Add(lextable, lexEntry);
			isString = true;
			continue;
		}

		FST::FST l_activity(str, L_ACTIVITY);
		if (execute(l_activity))
		{
			isactivity = true;
			lexEntry.lexema[0] = LEX_ACTIVITY;
			LT::Add(lextable, lexEntry);
			continue;
		}

		FST::FST l_start(str, L_START);
		if (execute(l_start))
		{
			lexEntry.lexema[0] = LEX_START;

			IdEntry.areaOfvisibility = new char[strlen(areaArr[level]) + 1];
			strcpy(IdEntry.areaOfvisibility, areaArr[level]);
			++level;

			areaArr[level] = new char[strlen(str) + 1];
			strcpy(areaArr[level], str);
			strcpy(IdEntry.id, str);

			IdEntry.idtype = IT::IDTYPE::F;
			IdEntry.iddatatype = IT::IDDATATYPE::INT;
			IdEntry.idxfirstLE = lextable.size;
			lexEntry.idxTI = idtable.size;
			LT::Add(lextable, lexEntry);
			IT::Add(idtable, IdEntry);
			continue;
		}

		FST::FST l_loop(str, L_LOOP);
		if (execute(l_loop))
		{
			lexEntry.lexema[0] = LEX_LOOP;
			strcpy(IdEntry.id, "LOOP");
			int len = strlen(IdEntry.id);
			IdEntry.id[len++] == countLoop;
			IdEntry.id[len] == '\0';
			IdEntry.idxfirstLE = idtable.size;
			lexEntry.idxTI = lextable.size;
			LT::Add(lextable, lexEntry);
			IT::Add(idtable, IdEntry);
			isLoop = true;
			continue;
		}
		

		FST::FST l_give(str, L_GIVE);
		if (execute(l_give))
		{
			lexEntry.lexema[0] = LEX_GIVE;
			LT::Add(lextable, lexEntry);
			continue;
		}

		FST::FST l_output(str, L_OUTPUT);
		if (execute(l_output))
		{
			if (!isIOLibrary)
			{
				throw ERROR_THROW(129);
			}
			lexEntry.lexema[0] = LEX_OUTPUT;
			LT::Add(lextable, lexEntry);
			continue;

		}
		FST::FST l_identificator(str, L_IDENTIFICATOR);
		if (execute(l_identificator))//если идентификатор
		{
			lexEntry.lexema[0] = LEX_ID;
			if (isactivity)//если это имя функции
			{
				if ((lexEntry.idxTI = IT::IsId(idtable, str)) != TI_NULLIDX)//если уже есть в таблиеце
				{
					throw ERROR_THROW_IN(136, lexEntry.sn, counter);
				}
				else
				{
					IdEntry.areaOfvisibility = new char[strlen(areaArr[level]) + 1];
					strcpy(IdEntry.areaOfvisibility, areaArr[level]);
					if (!isnew)
					{
						level++;
						areaArr[level] = new char[strlen(str) + 1];
						strcpy(areaArr[level], str);
					}
					int j;
					for (j = 0; j < strlen(str); j++)
						IdEntry.id[j] = str[j];
					IdEntry.id[j] = '\0';
					if (isByte)
					{
						IdEntry.iddatatype = IT::IDDATATYPE::INT;
						IdEntry.value.vint = 0;
					}
					else if (isString)
					{
						IdEntry.iddatatype = IT::IDDATATYPE::STR;
						IdEntry.value.vstr.len = 0;
						IdEntry.value.vstr.str[0] = '\0';
					}
					isByte = false;
					isString = false;
					IdEntry.idtype = IT::IDTYPE::F;
					IdEntry.idxfirstLE = lextable.size;
					lexEntry.idxTI = idtable.size;
					IT::Add(idtable, IdEntry);
					isactivity = false;
					isnew = false;

					LT::Add(lextable, lexEntry);
				}
			}
			else
			{
				if ((lexEntry.idxTI = IT::IsId(*idtable.externTable, str))!=TI_NULLIDX)
				{
					if (idtable.externTable->table[lexEntry.idxTI].idtype == IT::IDTYPE::EF)
					{
						lexEntry.lexema[0] = LEX_EXTERN_FUNCTION;
						int h;
						for (h = 0; h < strlen(str); h++)
							IdEntry.id[h] = str[h];
						IdEntry.id[h] = '\0';
						IdEntry.areaOfvisibility = new char[1];
						IdEntry.areaOfvisibility[0] = '\0';
						IdEntry.idtype = IT::IDTYPE::EF;
						IdEntry.iddatatype = idtable.externTable->table[lexEntry.idxTI].iddatatype;
						IdEntry.idxfirstLE = lextable.size;
						lexEntry.idxTI = idtable.size;
						IT::Add(idtable, IdEntry);
						LT::Add(lextable, lexEntry);
						continue;
					}
			
					
				}
				lexEntry.idxTI = IT::IsId(idtable, str, areaArr[level]);
				if (lexEntry.idxTI == TI_NULLIDX)
				{

					if (!isSigma)
					{
						if (!isString && !isByte && !isactivity && !isnew && !isParam&&!isIdentificator)
						{
							throw Error::geterrorin(115,lextable.table[i].sn,-1);
						}
		
						IdEntry.areaOfvisibility = new char[strlen(areaArr[level]) + 1];
						strcpy(IdEntry.areaOfvisibility, areaArr[level]);
						int i;
						for (i = 0; i < strlen(str); i++)
							IdEntry.id[i] = str[i];
						IdEntry.id[i] = '\0';
						if (isByte)
						{
							IdEntry.iddatatype = IT::IDDATATYPE::INT;
							isByte = false;
						}
						else if (isString)
						{
							IdEntry.iddatatype = IT::IDDATATYPE::STR;
							isByte = false;
						}
						if (isParam)
						{
							IdEntry.idtype = IT::IDTYPE::P;
						}
						else
						{
							IdEntry.idtype = IT::IDTYPE::V;
						}
						IdEntry.idxfirstLE = lextable.size;
						lexEntry.idxTI = idtable.size;
						IT::Add(idtable, IdEntry);
						LT::Add(lextable, lexEntry);
						isnew = false;
					}
					else
					{
						if (strcmp(str, "IoLibrary")==0)
						{
							isIOLibrary = true;
						}
						
						lexEntry.lexema[0] = LEX_ID;
						int z;
						for (z = 0; z < strlen(str); z++)
						{
							IdEntry.id[z] = str[z];
						}
						IdEntry.id[z] = '\0';
						IdEntry.idxfirstLE = lextable.size;
						lexEntry.idxTI = idtable.size;
						IdEntry.idtype = IT::IDTYPE::LIB;
						IdEntry.iddatatype = IT::IDDATATYPE::DEF;
						int p= strlen(areaArr[level]);
						IdEntry.areaOfvisibility = new char[p];
						for (p = 0; p < strlen(areaArr[level]); p++)
						{
							IdEntry.areaOfvisibility[p] = areaArr[level][p];
						}
						IdEntry.areaOfvisibility[p] = '\0';
						LT::Add(lextable,lexEntry);
						IT::Add(idtable, IdEntry);
						std::ifstream file(strcat(str,".h"));
						if (!file.is_open())
						{
							throw ERROR_THROW(113);
						}
						char temp;
						file >> temp;
						bool isPreParam = false;
						bool isExtParam = false;
						bool isType = false;
						bool isChar = false;
						bool isCharPtr = false;
						bool isInt = false;
						bool isShort = false;
						while (temp != LEX_LEFTBRACE)
							file >> temp;
						while (!file.eof())
						{
							char *word=new char[30];
							int index = 0;
							file.get(word[index]);
							while (word[index] != LEX_RIGHTBRACE && !file.eof()&&word[index]!=' '&&word[index]!=LEX_COMMA
								&&word[index]!='\t'&&word[index]!='\n')
							{
								if (word[index] == LEX_LEFTHESIS)
								{
									isPreParam = true;
									break;

								}

								else if (word[index] == LEX_RIGHTHESIS)
								{
									break;
								}
								if (word[index] == LEX_SEMICOLON)
								{
									isPreParam = false;
									isExtParam = false;
									isChar = false;
									isCharPtr = false;
									isInt = false;
									isShort = false;
									break;
								}
								
								file.get(word[++index]);
							}
							word[index] = '\0';
							if (index != 0)
							{
								FST::FST l_c_char(word, L_C_CHAR);
								FST::FST l_c_int(word, L_C_INT);
								FST::FST l_c_short(word, L_C_SHORT);
								FST::FST l_c_string(word, L_C_STRING);
								FST::FST l_c_identificator(word, L_IDENTIFICATOR);
								if (execute(l_c_char))
								{
									isChar = true;
								}
								else if (execute(l_c_int))
								{
									isInt = true;
								}
								else if (execute(l_c_short))
								{
									isShort = true;
									
								}
								else if (execute(l_c_string))
								{
									isCharPtr = true;
								}
								else if (execute(l_c_identificator))
								{
									int k;
									for (k = 0; k < strlen(word); k++)
									{
										IdEntry.id[k] = word[k];
									}
									IdEntry.id[k] = '\0';
									if (isShort)
									{
										IdEntry.iddatatype = IT::IDDATATYPE::ESHORT;
									}
									else if (isCharPtr)
									{
										IdEntry.iddatatype = IT::IDDATATYPE::ESTRING;
									}
									else if (isInt)
									{
										IdEntry.iddatatype = IT::IDDATATYPE::EINT;
									}
									else if (isChar)
									{
										IdEntry.iddatatype = IT::IDDATATYPE::ECHAR;
									}
									if (!isExtParam)
									{
										IdEntry.idtype = IT::IDTYPE::EF;
									}
									else
									{
										IdEntry.idtype = IT::IDTYPE::EP;
									}

									IdEntry.idxfirstLE =lextable.size;
									IT::Add(*idtable.externTable, IdEntry);
									isChar = false;
									isCharPtr = false;
									isInt = false;
									isShort = false;

								}
								isPreParam ? isExtParam = true : isExtParam=false;
							}
							delete[]word;
						}
						file.close();
						continue;
					}
				}
				else
				{
					if(isSigma)
					{
						throw ERROR_THROW_IN(128, lexEntry.sn, -1);
					}
					if (isnew)
					{
						throw ERROR_THROW_IN(137, lexEntry.sn, counter);
					}
					
					else
					{
						lexEntry.lexema[0] = LEX_ID;
						LT::Add(lextable, lexEntry);
					}
				}
			}
			continue;
		}
		
		
		FST::FST l_numberLiteralbin(str, L_NUMBERLITERALBIN);
		FST::FST l_numberLiteraldec(str, L_NUMBERLITERALDEC);
		bool isDec = false,
			 isBin = false;
		if ((isDec=execute(l_numberLiteraldec))||(isBin=execute(l_numberLiteralbin)))
		{
			countLt++;
			lexEntry.lexema[0] = LEX_LITERAL;
			char* buffer = new char[strlen(str)+1];
			try {
				if (isDec)
				{
					buffer[0] = '0';
					buffer[1] = 'd';
					buffer[2] = '\0';
					strncat(buffer, str + 2, strlen(str));
					IdEntry.value.vint = strtol(str + 2, &buffer + 2, 8);
				}
				else
				{
					buffer[0] = '0';
					buffer[1] = 'b';
					buffer[2] = '\0';
					strncat(buffer, str + 2, strlen(str));
					IdEntry.value.vint = strtol(str + 2, &buffer + 2, 2);
				}
			}
			catch(char* ex)
			{
				throw ERROR_THROW(308);
			}
			IdEntry.areaOfvisibility = new char[strlen(areaArr[level]) + 1];
			strcpy(IdEntry.areaOfvisibility, areaArr[level]);
			IdEntry.iddatatype = IT::IDDATATYPE::INT;
			IdEntry.idtype = IT::IDTYPE::L;
			IdEntry.idxfirstLE = lextable.size;
			lexEntry.idxTI = idtable.size;
			char tmpBuf[10];
			char* buf=new char[10];
			strcpy(tmpBuf, "LT");
			strcat(tmpBuf, _itoa(countLt, buf, 10));
			strcpy(IdEntry.id, tmpBuf);
			LT::Add(lextable, lexEntry);
			IT::Add(idtable, IdEntry);
			delete[]buffer;
			delete[]buf;


			continue;
		}
		FST::FST l_stringLiteral(str, L_STRINGLITERAL);
		if (execute(l_stringLiteral))
		{
			++countLt;
			lexEntry.lexema[0] = LEX_LITERAL;
			IdEntry.value.vstr.len = strlen(str);
			int i;
			for (i = 0; i < IdEntry.value.vstr.len; i++)
			{
				IdEntry.value.vstr.str[i] = str[i];
			}
			IdEntry.value.vstr.str[i] = '\0';
			IdEntry.areaOfvisibility = new char[strlen(areaArr[level]) + 1];
			strcpy(IdEntry.areaOfvisibility, areaArr[level]);
			IdEntry.iddatatype = IT::IDDATATYPE::STR;
			IdEntry.idtype = IT::IDTYPE::L;
			IdEntry.idxfirstLE = lextable.size;
			lexEntry.idxTI = idtable.size;
			char tmpBuf[10];
			char buf[6];
			strcpy(tmpBuf, "LT");
			strcat(tmpBuf, _itoa(countLt, buf, 10));
			strcpy(IdEntry.id, tmpBuf);
			LT::Add(lextable, lexEntry);
			IT::Add(idtable, IdEntry);
			continue;
		}
		FST::FST l_verb(str, L_VERB);
		if (execute(l_verb))
		{
			
			lexEntry.lexema[0] = str[0];
			LT::Add(lextable, lexEntry);
			continue;
		}
		FST::FST l_braceleft(str, L_BRACELEFT);
		if (execute(l_braceleft))
		{
			lexEntry.lexema[0] = LEX_LEFTBRACE;
			LT::Add(lextable, lexEntry);
			continue;
		}
		FST::FST l_braceright(str, L_BRACERIGHT);
		if (execute(l_braceright))
		{

			lexEntry.lexema[0] = LEX_RIGHTBRACE;
			if (!isLoop)
			{
				delete[]areaArr[level];
				level--;
			}
			isLoop = false;
			LT::Add(lextable, lexEntry);
			continue;
		}
		FST::FST l_lefthesis(str, L_LEFTHESIS);
		if (execute(l_lefthesis))
		{
			if (isactivity && (isByte || isString))
				throw ERROR_THROW_IN(138, lexEntry.sn, counter);
			if (idtable.table[idtable.size - 1].idtype == IT::IDTYPE::F)
			{
				isParam = true;
			}
			lexEntry.lexema[0] = LEX_LEFTHESIS;
			LT::Add(lextable, lexEntry);
			continue;
		}
		FST::FST l_righthesis(str, L_RIGHTHESIS);
		if (execute(l_righthesis))
		{
			isParam = false;
			lexEntry.lexema[0] = LEX_RIGHTHESIS;
			LT::Add(lextable, lexEntry);
			continue;
		}
		FST::FST l_comma(str, L_COMMA);
		if (execute(l_comma))
		{
			lexEntry.lexema[0] = LEX_COMMA;
			LT::Add(lextable, lexEntry);
			continue;
		}
		FST::FST l_semicolon(str, L_SEMICOLON);
		if (execute(l_semicolon))
		{
			lexEntry.lexema[0] = LEX_SEMICOLON;
			LT::Add(lextable, lexEntry);
			continue;
		}
		if (isRecognized)
		{
			throw  ERROR_THROW_IN(120, lexEntry.sn, counter);
		}

	}

}