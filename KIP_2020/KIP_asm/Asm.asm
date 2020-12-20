
.586
	.model flat, stdcall
	includelib libucrt.lib
	includelib kernel32.lib
					includelib ../Debug/MathLibrary.lib
	includelib ../Debug/IoLibrary.lib
	ExitProcess PROTO :SDWORD

	abs PROTO:SDWORD
	max PROTO:SDWORD ,:SDWORD
	min PROTO:SDWORD ,:SDWORD
	negative PROTO:SDWORD
	strdisplay PROTO:SDWORD
	bdisplay PROTO:SDWORD
.stack 4096
.const
ower BYTE "OWERFLOW", 0
	startLT1 SDWORD 4
	startLT2 SDWORD 34
	startLT3 SDWORD 5
	startLT4 SDWORD 1380
	startLT5 SDWORD 1
	startLT6 BYTE "TEXT! 111-12/2", 0
.data
	devz SDWORD 0
	startb SDWORD 0
	startx SDWORD 0
	starty SDWORD 0
	startstr SDWORD 0

.code

dev PROC devx : SDWORD, devy : SDWORD
	push devx
	push devy
	pop eax
	pop ebx
	add eax, ebx
	push eax
pop devz
	push devz
	pop eax
	ret
dev ENDP

main PROC
	push startLT1
pop starty
	push startLT2
	push startLT3
	pop eax
	pop ebx
	imul ebx
	jo OWERFLOW
	push eax
invoke min , startx, startLT4
push eax
	pop eax
	pop ebx
	add eax, ebx
	push eax
pop startx
invoke bdisplay, startx
invoke dev , startx, starty
push eax
pop startx

	mov ecx,startb

dec ecx

cmp ecx,0

jg LOOP82

neg ecx
LOOP82:
push ecx
	push startLT5
pop startb
invoke bdisplay, startb
pop ecx

LOOP LOOP82
	push startLT5
pop startb
invoke bdisplay, startb
	push OFFSET startLT6
pop startstr
invoke strdisplay, startstr
pop eax
invoke abs , startb
push eax
pop startb
invoke bdisplay, startb
	jmp theend
	OWERFLOW:
	invoke strdisplay, OFFSET ower
theend:
	push 0
	call ExitProcess
main ENDP
end main