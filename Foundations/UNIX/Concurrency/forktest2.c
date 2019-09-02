#include "worker.h"
#include <stdio.h>
#include <unistd.h>
#include <sys/wait.h>

int main(int argc, char* argv[])
{
	if(argc < 2)
		return printf("USAGE: %s program-to-run\n", argv[0]);
	
	printf("Welcome from process<%d/%d>\n", getpid(), getppid());

	if(fork() == 0)
	{
		if(execl(argv[1], NULL) == -1)
			printf("Cannot execute %s\n", argv[1]);
	}

	wait(NULL);
	printf("Goodbye from process<%d/%d>\n", getpid(), getppid());
}

