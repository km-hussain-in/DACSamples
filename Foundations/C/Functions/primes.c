static int IsPrime(int number)
{
	int m;

	if(number == 1)
		return 0;

	if(number == 2 || number == 3)
		return 1;

	if(!(number % 2))
		return 0;

	for(m = 3; m * m <= number; m += 2)
	{
		if((number % m) == 0)
			return 0;
	}
	
	return 1;
}


int CountPrimes(int first, int last)
{
	register int n, count = 0;

	for(n = first; n <= last; ++n)
	{
		count += IsPrime(n);
	}

	return count;
}

