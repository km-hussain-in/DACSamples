#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <fcntl.h>

extern int ProcessBuffer(char[], int count);

int main(int argc, char* argv[])
{
	int fdi, fdo, m, n;
	char* buffer;

	if(argc < 3)
		return printf("USAGE: %s source-file target-file [buffer-size]\n", argv[0]);
	
	fdi = open(argv[1], O_RDONLY, 0);
	if(fdi == -1)
		return printf("ERROR: Cannot open %s\n", argv[1]);

	fdo = open(argv[2], O_WRONLY | O_CREAT | O_EXCL, 0644);
	if(fdo == -1)
		return printf("ERROR: Cannot create %s\n", argv[2]);

	m = argc < 4 ? 80 : atoi(argv[3]);
	buffer = malloc(m); //dynamic allocation on heap
	do
	{
		n = read(fdi, buffer, m);
		ProcessBuffer(buffer, n);
		write(fdo, buffer, n);
	}
	while(n == m);
	free(buffer);

	close(fdo);
	close(fdi);
}

