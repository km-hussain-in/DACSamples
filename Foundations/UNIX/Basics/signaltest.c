#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <signal.h>

void End(void)
{
	puts("Goodbye User");
}

void MainHandler(int signo)
{
	switch(signo)
	{
	case SIGFPE:
		puts("ERROR: Illegal arithmetic operation");
		break;
	case SIGSEGV:
		puts("ERROR: Illegal memory access");
		break;
	case SIGINT:
		puts("\nWARNING: Terminated by user");
		break;
	}

	exit(signo);
}

void Run(void)
{
	register int i;
	int squares[] = {1, 4, 9, 16, 25, 36, 49, 64, 81, 100};

	for(i = 1; i <= 3; ++i)
	{
		int value;
		printf("Value %d: ", i);
		scanf("%d", &value);
		printf("Result = %d\n", 2520 / value);
		printf("Square = %d\n", squares[value]);
	}

}

int main(void)
{
	struct sigaction act = {MainHandler};

	sigaction(SIGFPE, &act, NULL);
	sigaction(SIGSEGV, &act, NULL);
	sigaction(SIGINT, &act, NULL);
	atexit(End);

	puts("Welcome User");
	Run();
}


