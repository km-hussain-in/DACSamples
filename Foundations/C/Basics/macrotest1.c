#include "mymacros.h"
#include <stdio.h>

int main(void)
{
	float m, s, c;

	printf("Input a real number: ");
	scanf("%f", &m);

	s = SQUARE(m);
	c = CUBE(m);

	printf("Square = %f and Cube = %f\n", s, c);
}

