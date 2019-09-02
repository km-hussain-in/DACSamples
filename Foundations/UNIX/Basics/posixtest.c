#include <stdio.h>
#include <unistd.h>

int main(int argc, char* argv[])
{
	register int i;

	for(i = 1; i < argc; ++i)
	{
		printf("Hello %s\n", argv[i]);
		usleep(5 *1000 * 1000);
	}

	puts("Goodbye all!");
}

