# Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the elements of nums except nums[i].

# The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.

# You must write an algorithm that runs in O(n) time and without using the division operation.


from typing import List


class ProductOfArray:

    # have two lists
    # one for product of elements left of index
    # one for product of elements right of index
    # multiply their index to get the final product (neither can be 0)

    def productExceptSelf(self, nums: List[int]) -> List[int]:

        left_products = [1] * len(nums)
        right_products = [1] * len(nums)

        for index in range(1, len(nums)):
            left_products[index] = left_products[index-1]*nums[index-1]

        for index in range((len(nums)-2), -1, -1):
            right_products[index] = right_products[index+1]*nums[index+1]

        products = []

        for index in range(len(nums)):
            products.append(left_products[index]*right_products[index])

        return products

    def productExceptSelfBruteForce(self, nums: List[int]) -> List[int]:

        left_products = [1, nums[0]]
        right_products = [nums[-1], 1]

        for index in range(2, len(nums)):
            left_products.append(left_products[index-1]*nums[index-1])
            right_products.insert(
                0, right_products[0]*nums[len(nums)-index])

        products = []

        for index in range(len(nums)):
            products.append(left_products[index]*right_products[index])

        return products
