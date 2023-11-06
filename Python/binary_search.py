# Given an array of integers nums which is sorted in ascending order, and an integer target, write a function to search target in nums.
# If target exists, then return its index. Otherwise, return -1.

# You must write an algorithm with O(log n) runtime complexity.

from typing import List


# simple BS algorithm
# continue to search list by cutting in half
# if right pointer < target value: -1
# if left pointer > target valu: -1
class Solution:
    def search(self, nums: List[int], target: int) -> int:

        if len(nums) == 1 and nums[0] == target:
            return 0

        left = 0
        right = len(nums)-1

        while True:

            current_mid = (left + right)//2

            if nums[current_mid] == target:
                return current_mid

            if nums[current_mid] > target:
                right = current_mid - 1
            elif nums[current_mid] < target:
                left = current_mid + 1

            if nums[right] < target:
                return -1
            if nums[left] > target:
                return -1
