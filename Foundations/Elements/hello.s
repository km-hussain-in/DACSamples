	.intel_syntax

	.include "console.i"

	.text
	
greet:	.ascii	"Hello World!"

_entry:
	lea	%rsi, greet
	PutStr	%rsi, 12	#length of greet message = 12
	PutEoL
	mov	%rax, 312
	ret

	.global	_entry

	.end


