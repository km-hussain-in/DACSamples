#include "worker.h"
#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <pthread.h>

int result = 0;

pthread_mutex_t gate = PTHREAD_MUTEX_INITIALIZER;

void HandleJob(int id)
{
	int value;
	printf("Thread<%x/%d> has accepted job:%d\n", pthread_self(), getpid(), id);
	pthread_mutex_lock(&gate);
	value = result;
	result = value + DoWork(id);
	pthread_mutex_unlock(&gate);
	printf("Thread<%x/%d> has finished job:%d\n", pthread_self(), getpid(), id);
}

typedef struct{
	int id;
}ThreadData;

void* ChildStart(void* arg)
{
	ThreadData* data = arg;
	HandleJob(data->id);
	return NULL;
}

int main(int argc, char* argv[])
{
	register int i;
	pthread_t child[5];
	ThreadData data[5];

	for(i = 0; i < 5; ++i)
	{
		data[i].id = i + 1;
		pthread_create(&child[i], NULL, ChildStart, &data[i]);
	}

	for(i = 0; i < 5; i++)
		pthread_join(child[i], NULL);

	printf("Result = %d\n", result);
}


