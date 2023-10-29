# Suppose an array of length n sorted in ascending order is rotated between 1 and n times. For example, the array nums = [0,1,2,4,5,6,7] might become:

#     [4,5,6,7,0,1,2] if it was rotated 4 times.
#     [0,1,2,4,5,6,7] if it was rotated 7 times.

# Notice that rotating an array [a[0], a[1], a[2], ..., a[n-1]] 1 time results in the array [a[n-1], a[0], a[1], a[2], ..., a[n-2]].

# Given the sorted rotated array nums of unique elements, return the minimum element of this array.

# You must write an algorithm that runs in O(log n) time.
from typing import List


class Solution:
    def findMin(self, nums: List[int]) -> int:

        current_min = nums[0]
        left_pointer = 0
        right_pointer = len(nums) - 1


        while (left_pointer <= right_pointer):

            if nums[left_pointer] < nums[right_pointer]:
                return min(current_min, nums[left_pointer])
            
            mid_pointer = (left_pointer + right_pointer) // 2

            if nums[mid_pointer] > nums[right_pointer]:
                left_pointer = mid_pointer + 1
            else:
                right_pointer = mid_pointer-1
            
            current_min = min(current_min, nums[mid_pointer])
        
        return current_min  