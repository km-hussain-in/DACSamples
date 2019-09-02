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

GCD:	pop	r10 		#return address
	push	r9
	push	r8
	push	rcx
	push	rdx
	push	rsi
	push	rdi
	mov	eax, [rsp]
	sub	rsi, rsi 	#mov rsi, 0
1:	inc	rsi		#add rsi, 1
	mov	edx, [rsp+8*rsi]
	test	edx, edx	#cmp edx, 0
	jz	2f
	call	_GCD
	jmp	1b
2:	sub	rsp, 48
	push	r10
	ret

	.global	GCD
	.type	GCD, @function
	
	.end

