# Design an algorithm to encode a list of strings to a string. The encoded string is then sent over the network and is decoded back to the original list of strings.

# Please implement encode and decode

from typing import List


class EncodeAndDecode:
    """
     @param strs: a list of strings
     @return: encodes a list of strings to a single string.
     """

       def encode(self, string_list: List[str]) -> str:
            encoded_string = ""

            for word in string_list:
                encoded_string += "@" + str(len(word)) + "@" + word

            return encoded_string

        """
    @param str: A string
    @return: decodes a single string to a list of strings
    """

        def decode(self, string: str) -> List[str]:
            decoded_words = []
            index = 0

            while index < len(string):
                if string[index] == "@":
                    next_index = string.find("@", index + 1)
                    if next_index != -1:
                        word_length = int(string[index + 1: next_index])
                        decoded_words.append(string[next_index + 1: next_index + 1 + word_length])
                        index = next_index + 1 + word_length
                    else:
                        # Invalid encoding format; exit the loop
                        break
                else:
                    # If it's not an encoded word, just skip one character
                    index += 1

            return decoded_words
