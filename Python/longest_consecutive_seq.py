# Given an unsorted array of integers nums, return the length of the longest consecutive elements sequence.

# You must write an algorithm that runs in O(n) time.


from typing import List


class LongestConsecutiveSeq:
    def longestConsecutive(self, nums: List[int]) -> int:

        if not nums:
            return 0

        # hash set to remove duplicate entries and constant look-up time
        nums_set = set(nums)
        max_length = 0

        for number in nums_set:

            # remove redundancy
            if (number-1) not in nums_set:
                current_length = 1
                current_num = number

                # check for consecutive numbers on the right
                while current_num + 1 in nums_set:
                    current_num += 1
                    current_length += 1

                # update max length
                max_length = max(max_length, current_length)

        return max_length
