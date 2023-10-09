# Given two strings s and t of lengths m and n respectively, return the minimum window
# substring
# of s such that every character in t (including duplicates) is included in the window. If there is no such substring, return the empty string "".

# The testcases will be generated such that the answer is unique.



# start with left pointer at 0 and right index len(t) away from 0
# check if window contains all of the chars in t
# if not, increment right point; if it does then increment left pointer until winodow is missing a character
# every time you move the left pointer, update the min_substring as needed


# Runtime:
# O(s + t) where s and t are the lengths of the strings

class Solution:
    def minWindow(self, s: str, t: str) -> str:

        if ( len(s) < len(t)):
            return ""

        if (s == t):
            return s

        t_dict = {}
        min_substring = ""
        min_len = float('inf')
        left_pointer = 0

        # populate dictionary via chars and their count in t
        # O(t)
        for char in t:
            t_dict[char] = t_dict.get(char,0) + 1

        # count of unique chars in t
        char_to_match_count = len(t_dict)

        #O(s)
        for right_pointer in range(len(s)):

            right_char = s[right_pointer]

            if right_char in t_dict:
                # update the value in the dicitonary
                t_dict[right_char] -= 1

                # check if we have all required counts of char from t
                if t_dict[right_char] == 0:
                    char_to_match_count -= 1

            # update left pointer while we have all required chars in the window
            while char_to_match_count == 0:

                left_char = s[left_pointer]

                # update the min_substring
                if (right_pointer - left_pointer + 1) < min_len:
                    min_substring = s[left_pointer:right_pointer+1]
                    min_len = len(min_substring)

                # check if updating left pointer removes a char that is in t
                if left_char in t_dict:

                    # need to check if it's and "extra" char in the current window
                    if t_dict[left_char] == 0:
                        char_to_match_count += 1

                    t_dict[left_char] += 1
                
                left_pointer += 1
            
        return min_substring
