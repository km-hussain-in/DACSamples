#include <stdio.h>

int main(void)
{
	long number;
	register long a, b;
	register int c;

	printf("Enter an integer: ");
	scanf("%ld", &number);

	a = 1;
	b = number >= 0 ? number : -number;
	c = 0;

	do
	{
		a *= 10; //a = a * 10
		c += 1; //c = c + 1
	}
	while(a <= b);

	printf("Number of digits = %d\n", c);
}


