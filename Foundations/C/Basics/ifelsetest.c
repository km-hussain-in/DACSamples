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

	if(room == 1)
		rate = 825;
	else if(room == 2)
		rate = 950;
	else if(room == 3)
		rate = 1200;
	else
		rate = 1500;

	payment = 1.18 * stay * rate;

	printf("Total payment = %lf\n", payment);
}

