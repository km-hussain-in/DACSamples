#pragma once

typedef struct{
	int id;
	double amount;
	int period;
}FixedDeposit;

typedef float (*Scheme)(int);

int InitFixedDeposit(double amount, int period, FixedDeposit* fd);

double GetMaturityValue(const FixedDeposit* fd, Scheme policy);












