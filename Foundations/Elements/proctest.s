	.intel_syntax noprefix

	.include "console.i"

	.text

askn:	.asciz	"Enter a positive integer: "
ans:	.asciz	"G.C.D = "

_entry:
	mov	rbp, rsp
	sub	rsp, 12
	
	Prompt	askn
	GetInt	[rbp-4]
	Prompt	askn
	GetInt	[rbp-8]

	mov	eax, [rbp-4]
	mov	edx, [rbp-8]
	call	_GCD
	mov	[rbp-12], eax

	Prompt	ans
	PutInt	[rbp-12]
	PutEoL

	mov	rsp, rbp
	ret

	.global	_entry

	.end


