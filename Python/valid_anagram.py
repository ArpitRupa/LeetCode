# Given two strings s and t, return true if t is an anagram of s, and false otherwise.
# An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.

# My runtime:
# O(n)

class ValidAnagram:
    def isAnagram(self, s: str, t: str) -> bool:

        # can't be anagram if they aren't the same size
        if (len(s) != len(t)):
            return False

        char_dict = {}

        # populate dictionary with chars and occurances
        for char in s:
            if char in char_dict:
                char_dict[char] += 1
            else:
                char_dict[char] = 1

        # iterate through t and check if chars are in dict
        for char in t:
            if char in char_dict:

                # update entry when char found
                char_dict[char] -= 1

                # remove from dict if count < 1
                if char_dict[char] < 1:
                    char_dict.pop(char)
            else:
                return False

        # if dict not empty, can't be anagram
        if len(char_dict) > 0:
            return False

        return True
