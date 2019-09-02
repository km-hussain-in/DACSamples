#include <stdio.h>

int main(void)
{
	int room;
	short stay;
	float rate;
	double payment;

	puts("1.Economy\n2.Business\n3.Executive\n4.Deluxe");
	printf("Room type [1-4]: ");
	scanf("%d", &room);
	printf("Number of days: ");
	scanf("%hd", &stay);

	switch(room)
	{
	case 1:
		rate = 825;
		break;
	case 2:
		rate = 950;
		break;
	case 3:
		rate = 1200;
		break;
	default:
		rate = 1500;
	}

	payment = 1.18 * stay * rate;

	printf("Total payment = %.2lf\n", payment);
}

