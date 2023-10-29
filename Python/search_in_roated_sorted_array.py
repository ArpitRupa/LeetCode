# There is an integer array nums sorted in ascending order (with distinct values).

# Prior to being passed to your function, nums is possibly rotated at an unknown pivot index k (1 <= k < nums.length) such that the resulting array is [nums[k], nums[k+1], ..., nums[n-1], nums[0], nums[1], ..., nums[k-1]] (0-indexed). 
# For example, [0,1,2,4,5,6,7] might be rotated at pivot index 3 and become [4,5,6,7,0,1,2].

# Given the array nums after the possible rotation and an integer target, return the index of target if it is in nums, or -1 if it is not in nums.

# You must write an algorithm with O(log n) runtime complexity.
from typing import List


class Solution:
    def search(self, nums: List[int], target: int) -> int:

        lp, rp = 0 , len(nums) -1

        if(nums[0] == target):
            return 0

        while lp < rp:

            mp = (lp + rp) // 2

            if nums[lp] == target:
                return lp
            
            if nums[rp] == target:
                return rp
            
            if nums[mp] == target:
                return mp


            # if the target is greater than the mid value...
            if target > nums[mp]:

                #if we are in the left sorted or the left most value is grater then the target, then it must be on right
                if nums[lp] < nums [mp] or nums[lp] > target:
                    lp = mp + 1
                else: 
                    rp = mp
            else: 
                # if mp is in the left sorted and the left is less than target it must be in the left sorted list
                if nums[lp] < nums [mp] and nums[lp] < target:
                    rp = mp
                # if the left value is greater than mid value, target must be between them
                elif nums[lp] > nums[mp]:
                    rp = mp
                else:
                    lp = mp + 1

        return -1