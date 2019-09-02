#include <stdio.h>

int main(void)
{
	long long num;
	register int sum = 0;

	printf("Enter a positive integer: ");
	scanf("%lld", &num);

	while(num)
	{
		sum += (num % 10);
		num /= 10;
	}

	printf("Sum of digits = %d\n", sum);
}

