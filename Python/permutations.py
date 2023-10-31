
# Given an array nums of distinct integers, return all the possible permutations. You can return the answer in any order.


from typing import List
import copy


class Solution:

    # dry implementation
    # break it into recursion feed it back into the function for every element afte first
    # base case is when list size is one
    # insert the first element into every index of the returned list and append to total permutations
    # append first element to end of the list for last permutation
    def permute(self, nums: List[int]) -> List[List[int]]:

        # base case
        if len(nums) == 1:
            return [nums]

        # get permutations of elements after first index
        sub_permutations = self.permute(nums[1:])

        total_permutations = []

        for current_permutation in sub_permutations:

            # iterate over all indexes of current permuation
            for index in range(len(current_permutation)):

                # create deep copy of list
                new_permutation = copy.deepcopy(current_permutation)

                # insert into current index
                new_permutation.insert(index, nums[0])

                total_permutations.append(new_permutation)

            # create final permutation where element is at the end of the list
            final_permuation = copy.deepcopy(current_permutation)
            final_permuation.append(nums[0])

            total_permutations.append(final_permuation)

        return total_permutations

    # researched implementation
    # break down problem into a tree
    # at each non-leaf node, create permutation of previous nodes

    def permute(self, nums: List[int]) -> List[List[int]]:

        result = []

        # base case
        if len(nums) == 1:
            return [nums[:]]  # shallow copy

        # iterate over elements
        for i in range(len(nums)):
            current_number = nums.pop(0)

            # get permuations of everything after first element
            perms = self.permute(nums)

            # append current num to end of lists
            for perm in perms:
                perm.append(current_number)

            result.extend(perms)
            nums.append(current_number)

        return result
