#include "box.h"
#include <stdio.h>

int main(void)
{
	float l, b, h;
	double vol;
	Box mybox;

	printf("Enter dimensions: ");
	scanf("%f%f%f", &l, &b, &h);

	BoxSetDimensions(mybox, l, b, h);
	BoxSetThickness(mybox, 0.5);
	vol = BoxGetVolume(mybox);

	printf("Box volume = %.2lf\n", vol);


}

