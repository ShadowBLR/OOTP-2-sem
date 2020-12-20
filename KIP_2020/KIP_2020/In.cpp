#include "Error.h"
#include "In.h"
#include <fstream>
#include "FST.h"
#include "IT.h"

#define SEP_LENGTH 9
namespace In
{
	IN getin(wchar_t* infile)
	{
		char separators[SEP_LENGTH] = { ' ',';','%','(',')','-','+','=',',' };

		IN out;
		out.lines = 1;
		out.size = 0;
		out.ignor = 0;
		int countBrace=0;
		out.oneQuoteOpened = false;
		out.doubleQuoteOpened = false;

		bool spaceFlag = false;

		out.lexemPos = 0;


		std::ifstream file(infile);
		if (!file)
		{
			throw ERROR_THROW(110)//файл не открыт
		}
		else
		{
			file >> std::noskipws;
			file.seekg(0, std::ios_base::end);
			int size = file.tellg();
			file.seekg(0, std::ios_base::beg);

			out.text = new  char[size];

			char* word = new  char[50];
			int wordPosCount = 0;

			unsigned char tmp;//для считывания символов
			int colCounter = 0; //счетчик символов

			while (!file.eof())
			{

				file >> tmp;
				if (file.eof())
					break;
				if (out.oneQuoteOpened || out.doubleQuoteOpened)
				{
					if (tmp != '\"' && tmp != '\'')
					{
						word[wordPosCount++] = tmp;
						out.text[out.size++] = tmp;
						colCounter++;
						continue;
					}
				}
				if (tmp == '{')
				{
					countBrace++;
				}
				if (tmp == '}')
				{
					countBrace--;
				}
				switch (out.code[(int)tmp])
				{
					
				case IN::T://out.T://IN::T //введен
				{
					if (tmp == '\'')
					{
						if (!out.doubleQuoteOpened) //кавычки в кавычках
							out.oneQuoteOpened = !out.oneQuoteOpened;
					}
					else if (tmp == '"')
					{
						if (!out.oneQuoteOpened )//кавычки в кавычках
							out.doubleQuoteOpened = !out.doubleQuoteOpened;
					}
					else if ((tmp == ' ' || tmp == '\n' || tmp == '\t'))//встретили первый пробел
					{
						if (out.doubleQuoteOpened || out.oneQuoteOpened)
						{
							word[wordPosCount++] = tmp;
						}
						if (!spaceFlag)
						{
							spaceFlag = true;
							out.text[out.size++] = tmp;
							colCounter++;
						}
						if (wordPosCount != 0 && ((!out.oneQuoteOpened) && (!out.doubleQuoteOpened)))
						{

							word[wordPosCount] = '\0';
							out.lexems[out.lexemPos].line = out.lines;
							out.lexems[out.lexemPos].col = colCounter;
							out.lexems[out.lexemPos].lexem = new  char[wordPosCount];
							for (int j = 0; j < wordPosCount; j++)
							{
								out.lexems[out.lexemPos].lexem[j] = word[j];
							}
							out.lexems[out.lexemPos].lexem[wordPosCount] = '\0';
							out.lexems[out.lexemPos].col = colCounter - wordPosCount;

							out.lexemPos++;
							wordPosCount = 0;
							
						}
						if (tmp == IN_CODE_ENDL)
						{
							colCounter = 1;
							out.lines++;
						}

					}

					if (tmp != ' ')
					{
						spaceFlag = false;

						colCounter++;
						if (tmp != '\t' && tmp != '\n')
						{
							out.text[out.size++] = tmp;
							word[wordPosCount++] = tmp; //нашли лексему начинаем писать
						}

					}

					break;
				}
				case IN::I://out.I://IN::T //введен
				{
					out.ignor++;
					break;
				}
				case IN::L:// одиночная лексема
				{
					//нужно сохранить предыдущую и сделать новую
					if (!out.doubleQuoteOpened && !out.oneQuoteOpened)
					{
						if (out.size != 0 && out.text[out.size - 1] == ' ')
						{
							for (int i = 0; i < SEP_LENGTH; i++)
							{
								if (tmp == separators[i])
								{
									
									out.size--;
									colCounter--;
									if (wordPosCount != 0)
									{
										wordPosCount--;
									}
									break;
								}
							}

						}
						if (wordPosCount == 0)
							
							//если нет прошлой лексемы
						{

							out.text[out.size++] = tmp;
							colCounter++;

							out.lexems[out.lexemPos].col = colCounter;
							out.lexems[out.lexemPos].line = out.lines;
							out.lexems[out.lexemPos].lexem = new  char[2];
							out.lexems[out.lexemPos].lexem[0] = tmp;
							out.lexems[out.lexemPos].lexem[1] = '\0';
							out.lexemPos++;
						}

						else
						{
							if (out.text[out.size - 1] == ' ')
							{
								for (int i = 0; i < SEP_LENGTH; i++)
								{
									if (tmp == separators[i])
									{
										out.size--;
										colCounter--;
										break;
									}
								}
							}
							out.text[out.size++] = tmp;
							colCounter++;

							word[wordPosCount] = '\0';
							out.lexems[out.lexemPos].line = out.lines;
							out.lexems[out.lexemPos].col = colCounter;
							out.lexems[out.lexemPos].lexem = new  char[wordPosCount];
							for (int j = 0; j < wordPosCount; j++)
							{
								out.lexems[out.lexemPos].lexem[j] = word[j];
							}
							out.lexems[out.lexemPos].lexem[wordPosCount] = '\0';
							out.lexems[out.lexemPos].col = colCounter - wordPosCount;

							out.lexemPos++;
							wordPosCount = 0;
							out.lexems[out.lexemPos].col = colCounter;
							out.lexems[out.lexemPos].line = out.lines;
							out.lexems[out.lexemPos].lexem = new  char[2];
							out.lexems[out.lexemPos].lexem[0] = tmp;
							out.lexems[out.lexemPos].lexem[1] = '\0';
							out.lexemPos++;
						}
					}
					else
					{
						out.lexems[out.lexemPos].lexem = new char[2];
						out.text[out.size++] = tmp;
						out.lexems[out.lexemPos].lexem[0] = tmp;
						out.lexems[out.lexemPos++].lexem[1] = '\0';
					}
					break;
				}
				case IN::F://out.F://IN::T //введен
				{
					if ((!out.oneQuoteOpened) && (!out.doubleQuoteOpened)) //если все кавычки закрыты
					{
						throw ERROR_THROW_IN(121, out.lines, colCounter)
							break;
					}
					else
					{
						word[wordPosCount++] = tmp;
						out.text[out.size++] = tmp;
						colCounter++;
						break;
					}
				}
				default:
				{
					out.text[out.size++] = (unsigned char)out.code[tmp];
					colCounter++;
					break;
				}
				}
			}
			out.text[out.size--] = '\0';
			file.close();
			if (out.lexems[out.lexemPos-1].lexem[0]!='}')
			{
				throw ERROR_THROW_IN(123,out.lines, colCounter);
			}
		}
		if (countBrace != 0)
		{
			throw ERROR_THROW(127);
		}

		return out;
	}
}