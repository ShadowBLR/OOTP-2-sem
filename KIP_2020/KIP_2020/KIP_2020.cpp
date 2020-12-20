#include "tchar.h"
#include <iostream>
#include <locale>
#include <cwchar>
#include "Error.h"
#include "Parm.h"
#include "Log.h"
#include "In.h"
#include "FST.h"
#include "LexAnaliz.h"
#include "MFST.h"
#include "SemanticAnalyz.h"
#include "PolishNotation.h"
#include "CodeGeneration.h"

int _tmain(int argc, _TCHAR* argv[])
{
	setlocale(LC_ALL, "rus");
	system("chcp 1251");
	std::cout << "------ Разбор цепочек---" << std::endl << std::endl;
	Log::LOG log = Log::INITLOG;
	Out::OUT out = Out::INITOUT;
	In::IN in;
	LT::LexTable lextable;
	IT::IdTable idtable;
	try
	{
		Parm::PARM parm = Parm::getparm(argc, argv);
		log = Log::getlog(parm.log);
		out = Out::getout(parm.out);
		in = In::getin(parm.in);
		Log::WriteLine(log, "---- Разбор Цепочек ----", "");
		check_chain(in, out, log,lextable,idtable);

		Log::WriteLine(log, "---- Разбор Цепочек завершен ----", "");
		MFST_TRACE_START
			MFST::Mfst mfst(lextable, GRB::getGreibach());
		mfst.start();
		mfst.savededucation();
		mfst.printrules();
		SA::SemanticAnalyse(log,lextable,idtable);
		
		std::cout << "\n";
		PN::Wykonac(lextable, idtable);
		
		CG::CodeGeneration(lextable, idtable, out);
		Log::Close(log);
		Out::Close(out);


	}
	catch (Error::ERROR e)
	{
		Log::WriteError(log, e);
		Log::WriteLine(log, "\n---- Разбор Цепочек завершен с ошибкой ----", "");
	}

	system("pause");
}

