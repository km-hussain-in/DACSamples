#include <stdio.h>

/*
void SwapInt(int* first, int* second)
{
	int third = *first;
	*first = *second;
	*second = third;
}

void SwapDouble(double* first, double* second)
{
	double third = *first;
	*first = *second;
	*second = third;
}
*/

void Swap(void* first, void* second, long sz)
{
	char* pf = first;
	char* ps = second;
	register long i;

	for(i = 0; i < sz; ++i)
	{
		char t = pf[i];
		pf[i] = ps[i];
		ps[i] = t;
	}
}

#define SwapAny(X, Y) Swap(&X, &Y, sizeof(X))

int main(void)
{
	int ix = 34, iy = 43;
	double dx = 6.5, dy = 5.6;

	printf("Original int values: %d, %d\n", ix, iy);
	//SwapInt(&ix, &iy);
	//Swap(&ix, &iy, 4);
	SwapAny(ix, iy);
	printf("Swapped int values: %d, %d\n", ix, iy);
	printf("Original double values: %lf, %lf\n", dx, dy);
	//SwapInt((int*)&dx, (int*)&dy);
	//SwapDouble(&dx, &dy);
	//Swap(&dx, &dy, 8);
	SwapAny(dx, dy);
	printf("Swapped double values: %lf, %lf\n", dx, dy);
}


