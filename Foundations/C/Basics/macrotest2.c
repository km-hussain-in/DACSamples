#include "mymacros.h"
#include <stdio.h>

int main(void)
{
	int limit, n, i;

	printf("Limit: ");
	scanf("%d", &limit);

	for(i = 1; i <= limit; ++i)
	{
		#ifdef _BIG
		n = CUBE(i);
		#else
		n = SQUARE(i);
		#endif
		printf("%d\t%d\n", i, n);
	}
}

