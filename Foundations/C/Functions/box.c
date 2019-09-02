#include "box.h"

void BoxSetDimensions(Box box, float length, float breadth, float height)
{
	box[0] = length;
	box[1] = breadth;
	box[2] = height;
	box[3] = 0;
}

void BoxSetThickness(Box box, float thickness)
{
	box[3] = thickness;
}

double BoxGetVolume(Box box)
{
	float t = box[3];
	float l = box[0] - 2 * t;
	float b = box[1] - 2 * t;
	float h = box[2] - 2 * t;

	return 0.95 * l * b * h;
}


