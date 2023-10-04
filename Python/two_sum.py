# Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
# You may assume that each input would have exactly one solution, and you may not use the same element twice.
# You can return the answer in any order.

# My runtime:
# O(n)

from typing import List


class Solution:
    def twoSum(self, nums: List[int], target: int) -> List[int]:

        # dict to store elements of nums
        nums_dict = {}

        # populate dictionary
        for index, num in enumerate(nums):
            nums_dict[num] = index

        for index, num in enumerate(nums):
            difference = target-num

            # return if difference in num and the index of elements are not equivalent
            if difference in nums_dict:
                if (index != nums_dict[difference]):
                    return [index, nums_dict[difference]]
