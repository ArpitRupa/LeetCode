# You are given an integer array height of length n. There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and (i, height[i]).

# Find two lines that together with the x-axis form a container, such that the container contains the most water.
# Return the maximum amount of water a container can store.

# Notice that you may not slant the container.


# My runtime:
# O(n)

# use two pointers to keep track of left and right elements
# use the min of list[pointers] with distance between pointers to get elements
# update max_area accordingly
# update pointers depending on which height of the list[pointers] is larger
from typing import List


class Solution:
    def maxArea(self, height: List[int]) -> int:

        left_pointer = 0
        right_pointer = len(height)-1
        max_area = 0

        while (left_pointer < right_pointer):

            left_height = height[left_pointer]
            right_height = height[right_pointer]

            width = right_pointer - left_pointer

            new_area = width * min(left_height, right_height)

            if (new_area) > max_area:
                max_area = new_area

            if left_height > right_height:
                right_pointer -= 1
            else:
                left_pointer += 1

        return max_area
