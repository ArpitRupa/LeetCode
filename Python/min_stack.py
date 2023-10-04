# Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.

# Implement the MinStack class:

#     MinStack() initializes the stack object.
#     void push(int val) pushes the element val onto the stack.
#     void pop() removes the element on the top of the stack.
#     int top() gets the top element of the stack.
#     int getMin() retrieves the minimum element in the stack.

# You must implement a solution with O(1) time complexity for each function.

from typing import List


class MinStack:

    def __init__(self) -> None:

        # lists to store stack its min elements
        self.stack = []
        self.min_elements = []

    def push(self, val: int) -> None:

        # push to min elements if first element or element is greater/equal to current min
        if len(self.min_elements) == 0 or self.min_elements[-1] >= val:
            self.min_elements.append(val)

        # push element to stack
        self.stack.append(val)

    def pop(self) -> None:
        element = self.stack.pop()

        # if popped element is min element, pop from min list too
        if element == self.min_elements[-1]:
            self.min_elements.pop()

    def top(self) -> int:
        return self.stack[-1]

    def getMin(self) -> int:
        return self.min_elements[-1]
