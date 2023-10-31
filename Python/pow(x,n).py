# Implement pow(x, n), which calculates x raised to the power n (i.e., xn).

class Solution:
    def myPow(self, x: float, n: int) -> float:

        if n == 0:
            return 1

        if x == 0:
            return 0

        if n > 1:

            return x**n

        else:

            return x**n
