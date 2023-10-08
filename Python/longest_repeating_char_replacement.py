# You are given a string s and an integer k. You can choose any character of the string and change it to any other uppercase English character. You can perform this operation at most k times.

# Return the length of the longest substring containing the same letter you can get after performing the above operations.


# Runtime:
# O(n)

# make 2 pointers starting at index 0 of s
# create frequency map to keep track of char counts in window
# update the right pointer
# update frequency of chars
# if total replacements needed to upgrade max exceeds k; window via left pointer
class Solution:
    def characterReplacement(self, s: str, k: int) -> int:

        max_length = 0
        max_count = 0
        left = 0
        freq_map = {}

        for right in range(len(s)):
            # uipdate the frequency count for the current character
            freq_map[s[right]] = freq_map.get(s[right], 0) + 1
            # update the maximum frequency within the current window
            max_count = max(max_count, freq_map[s[right]])

            # if the total replacements needed exceeds k, shrink the window
            if (right - left + 1 - max_count) > k:
                freq_map[s[left]] -= 1
                left += 1

            # update the maximum length of the substring
            max_length = max(max_length, right - left + 1)

        return max_length
