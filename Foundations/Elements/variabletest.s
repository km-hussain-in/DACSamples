	.intel_syntax noprefix

	.include "console.i"

	.data

outer:	.long	0
inner:	.long	0
area:	.long	0

	.text

asko:	.asciz	"Outer width: "
aski:	.asciz	"Inner width: "
ans:	.asciz	"Frame area = "
	
_entry:
	Prompt	asko
	GetInt	outer	#x
	Prompt	aski	
	GetInt	inner	#y

	mov	eax, outer	#eax=x
	mov	ecx, inner	#ecx=y
	mov	ebx, eax	#ebx=x
	add	eax, ecx	#eax=x+y
	sub	ebx, ecx	#ebx=x-y
	mul	ebx		#eax=(x+y)*(x-y)
	mov	area, eax

	Prompt	ans
	PutInt	area
	PutEoL

	ret

	.global	_entry

	.end


