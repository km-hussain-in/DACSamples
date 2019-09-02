#include <stdio.h>

long AddAll(int first, int last)
{
	long sum = 0;
	register int value;

	for(value = first; value <= last; ++value)
	{
		sum += value;
	}

	return sum;

}

/*
long AddOdd(int first, int last)
{
	long sum = 0;
	register int value;

	for(value = first; value <= last; ++value)
	{
		if(value % 2)
			sum += value;
	}

	return sum;

}
*/

long AddIf(int first, int last, int (*check)(int))
{
	long sum = 0;
	register int value;

	for(value = first; value <= last; ++value)
	{
		if(check(value))
			sum += value;
	}

	return sum;

}

int IsOdd(int n)
{
	return n % 2;
}

int main(void)
{
	int limit;
	long a, b;
	
	printf("Upper Limit: ");
	scanf("%d", &limit);

	a = AddAll(1, limit);
	printf("Sum of all integers = %ld\n", a);

	//b = AddOdd(1, limit);
	b = AddIf(1, limit, IsOdd);
	printf("Sum of odd integers = %ld\n", b);
	
}

