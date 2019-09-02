#include "worker.h"
#include <stdio.h>
#include <unistd.h>
#include <sys/wait.h>

int pfd[2];

void Produce(void)
{
	int value;

	printf("Producer<%d> started...\n", getpid());
	value = DoWork(0);
	printf("Produced data = %d\n", value);
	write(pfd[1], &value, sizeof(value));
}

void Consume(void)
{
	int value;

	printf("Consumer<%d> started...\n", getpid());
	read(pfd[0], &value, sizeof(value));
	value *= DoWork(value);
	printf("Processed data = %d\n", value);
}

int main(void)
{
	pid_t child;

	pipe(pfd);

	child = fork();
	if(child == 0)
	{
		Consume();
	}
	else
	{
		Produce();
		waitpid(child, NULL, 0);
	}

	close(pfd[0]);
	close(pfd[1]);
}

