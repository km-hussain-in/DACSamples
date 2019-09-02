	.intel_syntax noprefix

	.include "console.i"
	.include "mymacros.i"
	.data

number:	.quad	0
digits:	.long	0

	.text

askn:	.asciz	"Enter an integer: "
ans:	.asciz	"Number of digits = "

_entry:
	Prompt	askn
	GetInt	number .int64

	mov	rax, 1
	mov	rbx, number
	mov	ecx, 0
	Abs	rbx
1:	Mul10	rax
	inc	ecx

	cmp	rax, rbx
	jbe	1b

	mov	digits, ecx

	Prompt	ans
	PutInt	digits
	PutEoL

	ret

	.global	_entry

	.end


