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
	mov	esi, index	
	cmp	esi, 8
	ja	1f
	mov	eax, [rdi+4*rsi]
	mov	value, eax

	Prompt	ans
	PutInt	value
	PutEoL

1:	ret

	.global	_entry

	.end


