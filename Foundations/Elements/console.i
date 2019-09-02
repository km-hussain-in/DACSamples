####################################################################
# Name          : console.i
# Description   : Defines macros for calling input/output procedures
#                 implemented in system.o
# Author        : K.M.Hussain
# Licence       : Educational
####################################################################


.extern _writestr, _writestz, _writelfc, _writeint, _readstr, _readint

# PutStr - Outputs a string with address in value and size in len.
.macro  PutStr  value, len
    mov     %rdx, \value
    mov     %ecx, \len
    call    _writestr
.endm

# Prompt - Outputs a null terminated string identified by label in value.
.macro  Prompt  value
    mov     %rdx, offset \value
    call    _writestz
.endm

# PutEOL - Outputs an end-of-line character
.macro  PutEOL
    call    _writelfc
.endm

# GetStr - Inputs a string in buffer with address in value and size in len.
.macro  GetStr  value, len
    mov     %rdx, \value
    mov     %ecx, \len
    call    _readstr
.endm

.set .int64, 8

# PutInt - Outputs a 32/64-bit decimal integer value.
.macro  PutInt  value, len=4
    .ifge \len-.int64
    mov     %rax, \value
    .else
    movsxd  %rax, \value
    .endif
    call    _writeint
.endm

# GetInt - Inputs a 32/64-bit decimal integer into value 
# and clears or sets ZF if successful or failed.
.macro  GetInt  value, len=4
    call    _readint
    .ifge \len-.int64
    mov     \value, %rax
    .else
    mov     \value, %eax
    .endif
.endm


