// Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

// An input string is valid if:

//     Open brackets must be closed by the same type of brackets.
//     Open brackets must be closed in the correct order.
//     Every close bracket has a corresponding open bracket of the same type.


// My Runtime: O(n)

using System.Collections.Generic;

public class ValidParentheses

{
    // loop through string pushing all open brackets to the stack
    // when we are process a char that is not an open bracket, it must be closed
    // check to see if the stack is empty before popping and comparing the bracket to the one that was popped
    // return false if no match
    // return true if the stack is empty when we're done processing the string

    public bool IsValid(string s)
    {
        HashSet<char> openBrackets = new HashSet<char> { '(', '{', '[' };

        Stack<char> charStack = new();

        char currentChar;
        foreach (char c in s)
        {
            if (openBrackets.Contains(c))
            {
                charStack.Push(c);
            }
            else
            {

                if (charStack.Count() < 1)
                {
                    return false;
                }
                currentChar = charStack.Pop();

                switch (c)
                {
                    case '}':
                        if (currentChar != '{')
                        {
                            return false;
                        }
                        break;
                    case ']':
                        if (currentChar != '[')
                        {
                            return false;
                        }
                        break;
                    case ')':
                        if (currentChar != '(')
                        {
                            return false;
                        }
                        break;
                }

            }

        }

        return charStack.Count == 0;

    }
}