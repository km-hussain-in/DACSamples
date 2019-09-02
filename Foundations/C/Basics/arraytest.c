#include <stdio.h>

int squares[] = {1, 4, 9, 16, 25, 36, 49, 64, 81};

int main(void)
{
	int index, value;

	printf("Index [0-8]: ");
	scanf("%d", &index);
	
	value = squares[index];

	printf("Value = %d\n", value);

}


