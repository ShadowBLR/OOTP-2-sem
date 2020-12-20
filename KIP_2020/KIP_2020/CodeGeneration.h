#pragma once
#include "LT.h"
#include "IT.h"
#include "Out.h"

namespace CG
{
	void CodeGeneration(LT::LexTable lextable,IT::IdTable idtable, Out::OUT out);
	void generateLoop(LT::LexTable lextable, IT::IdTable idtable, Out::OUT out, int i);
}
