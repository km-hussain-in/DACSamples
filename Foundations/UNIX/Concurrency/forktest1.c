#include "worker.h"
#include <stdio.h>
#include <unistd.h>
#include <sys/wait.h>

void HandleJob(int id)
{
	printf("Process<%d/%d> has accepted job:%d\n", getpid(), getppid(), id);
	DoWork(id);
	printf("Process<%d/%d> has finished job:%d\n", getpid(), getppid(), id);
}

int main(void)
{
	pid_t child;

	child = fork();
	if(child == 0)
	{
		HandleJob(7);
	}
	else
	{
		HandleJob(6);
		waitpid(child, NULL, 0);
	}
}

