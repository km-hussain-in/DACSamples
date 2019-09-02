#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <fcntl.h>
#include <sys/stat.h>
#include <sys/mman.h>

extern int ProcessBuffer(char[], int);

int main(int argc, char* argv[])
{
	int fd, m;
	struct stat fs;
	char* buffer;

	if(argc < 2)
		return printf("USAGE: %s file-to-reverse\n", argv[0]);

	fd = open(argv[1], O_RDWR);
	if(fd == -1)
		return printf("ERROR: Cannot open %s\n", argv[1]);

	fstat(fd, &fs);
	m = fs.st_size;
	buffer = mmap(NULL, m, PROT_READ | PROT_WRITE, MAP_SHARED, fd, 0);
	ProcessBuffer(buffer, m);
	munmap(buffer, m);

	close(fd);
}


