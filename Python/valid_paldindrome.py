# A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.

# Given a string s, return true if it is a palindrome, or false otherwise.


class ValidPalindrome:
    def isPalindrome(self, s: str) -> bool:

        cleaned_string = ""

        if len(s) == 1:
            return True

        # loop through char add lower case alpha-num char to cleaned string
        for char in s:
            if char.isalnum():
                cleaned_string += char.lower()

        for ith, char in enumerate(cleaned_string):

            ith_to_last = (len(cleaned_string)-1-ith)

            # check if ith element in string is equal to ith-to-last element
            if char != cleaned_string[ith_to_last]:
                return False

            # if the pointers pass each other, return true
            if ith >= ith_to_last:
                return True

        return True
