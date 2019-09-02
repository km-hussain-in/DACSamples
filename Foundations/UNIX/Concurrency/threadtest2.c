#include "worker.h"
#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <pthread.h>

volatile int data = 0;

void Produce(void)
{
	int value;

	printf("Producer thread<%x> ready...\n", pthread_self());
	value = DoWork(0);
	printf("Produced data = %d\n", value);
	data = value;
}

void Consume(void)
{
	printf("Consumer thread<%x> ready...\n", pthread_self());
	while(data == 0)
		pthread_yield();
	printf("Processing %d\n", data);
	data *= DoWork(data);
	printf("Processed data = %d\n", data);
}



void* ChildStart(void* arg)
{
	Consume();
	return NULL;
}

int main(int argc, char* argv[])
{
	pthread_t child;

	pthread_create(&child, NULL, ChildStart, NULL);

	Produce();

	pthread_join(child, NULL);
}


