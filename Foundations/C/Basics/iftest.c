#include <stdio.h>

int squares[] = {1, 4, 9, 16, 25, 36, 49, 64, 81};

int main(void)
{
	int index, value;

	printf("Index [0-8]: ");
	scanf("%d", &index);
	
	/*
	if(index < 9)
	{
		if(index >= 0)
		{
			value = squares[index];
			printf("Value = %d\n", value);
		}
	}
	*/

	if(index < 9 && index >= 0)
	{
		value = squares[index];
		printf("Value = %d\n", value);
	}

}


