#include "box.h"

void BoxSetDimensions(Box box, float length, float breadth, float height)
{
	box[0] = length;
	box[1] = breadth;
	box[2] = height;
}

double BoxGetVolume(Box box)
{
	float l = box[0];
	float b = box[1];
	float h = box[2];

	return 0.95 * l * b * h;
}


