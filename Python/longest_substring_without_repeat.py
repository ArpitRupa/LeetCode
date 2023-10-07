# Given a string s, find the length of the longest substring
# without repeating characters.


# loop through the string
# append to temp string while the next element is not in the temp string
# compare the temp string to the longest string; update if longer
# next char in the string will be start with substring of len(longest_string) [make sure no repeats]

class Solution:

    # runtime:
    # O(n^2)

    def lengthOfLongestSubstringNonOptimized(self, s: str) -> int:

        if (len(s) == 1):
            return 1

        longest_substring = ""

        # O(n)
        for index, char in enumerate(s):

            if (len(s) - index - 1) < len(longest_substring):
                break

            # O(k)
            temp_substring = s[index:index+len(longest_substring)]

            if (len(temp_substring) != len(set(temp_substring))):
                continue

            pointer_index = index + len(longest_substring)

            # O(n)
            while s[pointer_index] not in temp_substring:
                temp_substring += s[pointer_index]
                pointer_index += 1
                if pointer_index < len(s):
                    break

            if len(temp_substring) > len(longest_substring):
                longest_substring = temp_substring

        return len(longest_substring)
