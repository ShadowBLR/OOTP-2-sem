#pragma once

#include "FST.h"
#include "IT.h"
#include "LT.h"
#include <stack>
#include <map>
#include <string>

#define SPACE ' '
#define NONE_OPERATOR 0xfff;
#define SEQ '@'


namespace PN {
	bool NotaciaPolska(int lextable_pos, LT::LexTable& lextable, IT::IdTable& idtable);
	//short UzyskacPierwszenstwo(char t);
	void Wykonac(LT::LexTable& lextable, IT::IdTable& idtable);
}