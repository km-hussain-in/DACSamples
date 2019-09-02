#include "worker.h"
#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <pthread.h>

void HandleJob(int id)
{
	printf("Thread<%x/%d> has accepted job:%d\n", pthread_self(), getpid(), id);
	DoWork(id);
	printf("Thread<%x/%d> has finished job:%d\n", pthread_self(), getpid(), id);
}

void* ChildStart(void* arg)
{
	HandleJob(7);
	return NULL;
}

int main(int argc, char* argv[])
{
	pthread_t child;

	pthread_create(&child, NULL, ChildStart, NULL);

	HandleJob(6);

	#ifdef _FOREGROUND
	pthread_join(child, NULL);
	#endif
}


