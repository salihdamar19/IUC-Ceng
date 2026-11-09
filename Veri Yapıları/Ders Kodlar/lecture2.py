
a = [10, 20, 30]
b = a
c = a.copy()
d = a[:]

print(a is b)
print(a is c)
print(a is d)

print("--------------")

print(a == b)
print(a == c)
print(a == d)
