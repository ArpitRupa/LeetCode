# Given an array of strings strs, group the anagrams together. You can return the answer in any order.

# An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.

# My solution runtime:
# O(n*k*log(k))
# k*log(k) for sorting, n for len of list


from typing import List


class GroupAnagrams:
    def groupAnagrams(self, strs: List[str]) -> List[List[str]]:

        anagram_groups = []

        anagram_dict = {}

        for current_str in strs:
            # convert string to list to sort it
            sorted_str = list(current_str)
            sorted_str.sort()

            # covert back to list to treat as dictionary key
            sorted_str = "".join(sorted_str)

            # append to dict value if sorted string exists
            if sorted_str in anagram_dict:
                anagram_dict[sorted_str].append(current_str)
            # create new entry if sorted string does not exist
            else:
                anagram_dict[sorted_str] = [current_str]

        # append the values to group list
        for key, value in anagram_dict.items():
            anagram_groups.append(value)

        return anagram_groups
