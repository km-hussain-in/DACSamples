#include <stdio.h>

extern int CountPrimes(int, int);

int main(void)
{
	int l, u, n;

	printf("Enter lower and upper limits: ");
	scanf("%d%d", &l, &u);

	n = CountPrimes(l, u);

	printf("Number of primes = %d\n", n);
}


