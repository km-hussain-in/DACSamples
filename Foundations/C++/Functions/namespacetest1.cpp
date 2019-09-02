int age = 34;

namespace Child
{
	int age = 7;
}

int main(void)
{
	int age = 29;

	return age + ::age + Child::age;
}

