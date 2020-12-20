
Identificators:
         global::MathLibrary	              2
         global::dev	            INT	              0	              F	              6
            dev::x	            INT	              0	              P	              9
            dev::y	            INT	              0	              P	             12
            dev::z	            INT	              0	              V	             17
         global::start	            INT	              0	              F	             23
          start::b	            INT	              0	              V	             27
          start::result	            INT	              0	              V	             31
          start::x	            INT	              0	              V	             35
          start::y	            INT	              0	              V	             39
          start::str	            STR	               	              V	             43
          start::length	            INT	              0	              V	             47
          start::LT1	            INT	             22	              L	             51
          start::LT2	            INT	             26	              L	             53
          start::LT3	            STR	"TEXT! 111-12/2"	              L	             57
               ::absa	             61
               ::min	             68
          start::LT4	            INT	              3	              L	             77
          start::LT5	            INT	             28	              L	             79
          start::LT6	            INT	             34	              L	             83

.586
	.model flat, stdcall
	includelib libucrt.lib
	includelib kernel32.lib
		includelib ../Debug/MathLibrary.lib
	ExitProcess PROTO :DWORD

	absa PROTO:DWORD
	max PROTO:DWORD ,:DWORD
	min PROTO:DWORD ,:DWORD
	strdisplay PROTO:DWORD
	bdisplay PROTO:DWORD
.stack 4096
.const
	startLT1 DWORD 22
	startLT2 DWORD 26
	startLT3 BYTE "TEXT! 111-12/2", 0
	startLT4 DWORD 3
	startLT5 DWORD 28
	startLT6 DWORD 34
.data
	devx DWORD 0
	devy DWORD 0
	devz DWORD 0
	startb DWORD 0
	startresult DWORD 0
	startx DWORD 0
	starty DWORD 0
	startstr DWORD 0
	startlength DWORD 0

.code

dev PROC x : DWORD, y : DWORD
	push devz
		jmp local0
local0:
	pop eax
	ret
dev ENDP

main PROC
	push startLT1
	push startLT2
	pop eax
	pop ebx
	add eax, ebx
	push eax
pop startb
	push startLT3
pop startstr
	push startb
call absa
pop startb
	push starty
	push startx
call min
pop starty
	push startLT4
	push startLT5
	pop eax
	pop ebx
	add eax, ebx
	push eax
pop startx
	push startLT6
	push startx
	pop al
	pop bl
	mul al
	push eax
pop starty
	call ExitProcess
main ENDP
end main