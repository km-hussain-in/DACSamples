#ifndef BIZCALC_H
#define BIZCALC_H

float Depreciation(short life, short after, const char* method);

typedef struct{
	int id;
	double amount;
	short period;
}FixedDeposit;


int InitFixedDeposit(double amount, short period, FixedDeposit* fd);

double GetMaturityValue(const FixedDeposit* fd, float(*policy)(short));

#endif











