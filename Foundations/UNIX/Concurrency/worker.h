#include <time.h>

int DoWork(int amount)
{
	clock_t future;

	if(amount <= 0)
		amount = time(0) % 10 + 1;
	future = clock() + amount * CLOCKS_PER_SEC;
	while(clock() < future);

	return amount;
	
}

