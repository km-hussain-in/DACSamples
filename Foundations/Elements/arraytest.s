	.intel_syntax noprefix

	.include "console.i"

	.data

array:	.long	1, 4, 9, 16, 25, 36, 49, 64, 81
index:	.long	0
value:	.long	0

	.text

aski:	.asciz	"Index [0-8]: "
ans:	.asciz	"Value = "
	

_entry:
	Prompt	aski
	GetInt	index

	lea	rdi, array
	mov	esi, index		#direct addressing
	mov	eax, [rdi+4*rsi]	#indirect addressing
	mov	value, eax

	Prompt	ans
	PutInt	value
	PutEoL

	ret

	.global	_entry

	.end


