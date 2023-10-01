# Given an array of integers nums containing n + 1 integers where each integer is in the range[1, n] inclusive.

# There is only one repeated number in nums, return this repeated number.

# You must solve the problem without modifying the array nums and uses only constant extra space.


from typing import List


class FindDuplicate:

    def findDuplicateFloyds(nums):
        # Initialize pointers
        tortoise = nums[0]
        hare = nums[0]

        # move pointers until they meet inside the cycle.
        while True:
            tortoise = nums[tortoise]
            hare = nums[nums[hare]]
            if tortoise == hare:
                break

        # entrace of cycle
        tortoise = nums[0]
        while tortoise != hare:
            tortoise = nums[tortoise]
            hare = nums[hare]

        # return intersection
        return tortoise

    def findDuplicateBruteForce(self, nums: List[int]) -> int:

        for element, index in enumerate(range(len(nums)-1)):

            end = len(nums) - 1

            while (end > index):
                if nums[end] == element:
                    return nums[index]
                end -= 1

        return 0
