#include <stdio.h>

double list[] = {1.2, 2.3, 3.4, 4.5, 5.6, 6.7, 7.8, 8.9, 9.1};

int main(void)
{
	double* e = &list[3];
	double* f = e + 3;
	double* g = e - 2;

	printf("Pointer %p is addressing value %lf\n", e, *e);
	printf("Pointer %p is addressing value %lf\n", f, *f);
	printf("Pointer %p is addressing value %lf\n", g, *g);
	printf("Value at index 3 of pointer %p is %lf\n", e, e[3]); 

}


