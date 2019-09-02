#include <stdio.h>

int main(void)
{
	int limit, value;
	long long result = 0;

	printf("Limit: ");
	scanf("%d", &limit);

	for(value = 1; value <= limit; ++value)
	{
		result += value * value;
	}

	printf("Result = %lld\n", result);
}

