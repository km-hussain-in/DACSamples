#include <stdio.h>

int main(int argc, char* argv[])
{
	register int i;

	for(i = 1; i < argc; ++i)
	{
		int t[] = {5, 0};
		printf("Hello %s\n", argv[i]);
		__asm__("syscall" :: "a"(35), "D"(t)); //mov rax, 35; mov rdi, t; syscall
	}

	puts("Goodbye all!");
}

