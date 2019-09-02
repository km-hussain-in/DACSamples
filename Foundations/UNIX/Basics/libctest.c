#include <stdio.h>
#include <time.h>

int main(int argc, char* argv[])
{
	register int i;

	for(i = 1; i < argc; ++i)
	{
		clock_t t = clock() + 5 * CLOCKS_PER_SEC;
		printf("Hello %s\n", argv[i]);
		while(clock() < t);
	}

	puts("Goodbye all!");
}

