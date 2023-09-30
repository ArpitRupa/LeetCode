# Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

# Notice that the solution set must not contain duplicate triplets.


from typing import List


class ThreeSum:
    def threeSum(self, nums: List[int]) -> List[List[int]]:

        # sort given list
        nums.sort()

        # set to store triplets
        all_triplets = set()

        # iterate through the list
        for i in range(len(nums)-2):
            j = i + 1
            k = len(nums)-1
            current_triplet = [nums[i], nums[j], nums[k]]

            while (j < k):

                # list of current triplets
                current_triplet = [nums[i], nums[j], nums[k]]

                # sum of triplets
                triplet_sum = sum(current_triplet)

                if triplet_sum == 0:
                    all_triplets.add(tuple(sorted(current_triplet)))
                    j += 1
                    k -= 1
                elif triplet_sum > 0:
                    k -= 1
                elif triplet_sum < 0:
                    j += 1

        return all_triplets


# My soltuion time compexity:
# O(n^3)

# from typing import List


# class ThreeSum:
#     def threeSum(self, nums: List[int]) -> List[List[int]]:
#         # set to store triplets
#         all_triplets = set()

#         # iterate through the list
#         for i in range(len(nums)):
#             for j in range(i):
#                 for k in range(j):

#                     # if indicies are same skip the iteration
#                     if (i == j or i == k or j == k):
#                         continue

#                     # list of current triplets
#                     current_triplet = [nums[i], nums[j], nums[k]]

#                     # if sum of the triplet == 0, add to the set
#                     if sum(current_triplet) == 0:
#                         all_triplets.add(tuple(sorted(current_triplet)))
#         return all_triplets
