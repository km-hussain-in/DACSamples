#include <stdio.h>

enum Course {Elementary, Intermediate, Advanced};

struct Student
{
	int id;
	enum Course level;
	union
	{
		char grade;
		float score;
	};
};

float StudentGetCredit(struct Student candidate)
{
	float credit;
	
	switch(candidate.level)
	{
	case Elementary:
		credit = 100 + 10 * ('F' - candidate.grade);
		break;
	case Intermediate:
		credit = 125 + 20 * candidate.score;
		break;
	default:
		credit = 175 + 24 * candidate.score;
	}

	return credit;

}

int main(void)
{
	struct Student jack = {23, Elementary, 'C'};
	struct Student jill;
	jill.id = 32;
	jill.level = Advanced;
	jill.score = 63.5;

	printf("Jack's ID is %d and credit of %.1f\n", jack.id, StudentGetCredit(jack));
	printf("Jill's ID is %d and credit of %.1f\n", jill.id, StudentGetCredit(jill));
}


