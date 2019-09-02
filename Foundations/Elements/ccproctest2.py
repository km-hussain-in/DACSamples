from ctypes import *

lib = CDLL("./ccproc.so")
a = input("First number : ")
b = input("Second number: ")
c = input("Third number : ")
g = lib.GCD(a, b, c, 0)
print "G.C.D =", g

