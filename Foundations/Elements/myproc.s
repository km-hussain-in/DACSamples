	.intel_syntax	noprefix
	
	.text

_GCD:
1:	cmp	eax, edx
	je	3f
	ja	2f
	sub	edx, eax
	jmp	1b
2:	sub	eax, edx
	jmp	1b
3:	ret

	.global	_GCD
	
	.end

