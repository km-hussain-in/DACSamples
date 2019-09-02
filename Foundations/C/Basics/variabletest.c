#include <stdio.h>

int outer = 0; //global variable - visible in all modules of this program
static short int inner = 0; //global variable - visible only in current module

int main(void)
{
	int frame = 0; //local variable - visible only in this function

	printf("Enter outer and inner width: ");
	scanf("%d%hd", &outer, &inner);

	frame = outer * outer - inner * inner;

	printf("Frame area = %d\n", frame);
}


