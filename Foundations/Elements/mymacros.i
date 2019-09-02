.macro	Mul10	reg
	add	\reg, \reg	#reg=2x
	mov	rdx, \reg	#rdx=2x
	add	\reg, \reg	#reg=4x
	add	\reg, \reg	#reg=8x
	add	\reg, rdx	#reg=10x
.endm

.macro	Abs	reg
	mov	rdx, \reg
	neg	\reg
	cmovl	\reg, rdx
.endm

