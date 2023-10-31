

# Definition for singly-linked list.
from typing import Optional


class ListNode:
    def __init__(self, x):
        self.val = x
        self.next = None


class Solution:

    # dry solution
    # two pointers one fast and one slow
    # if they ever meet return true
    # if fast pointer is ever null return false
    def hasCycle(self, head: Optional[ListNode]) -> bool:

        slow_pointer = head
        fast_pointer = head

        while fast_pointer is not None:

            if fast_pointer.next is None or fast_pointer.next.next is None:
                return False

            fast_pointer = fast_pointer.next.next
            slow_pointer = slow_pointer.next

            if fast_pointer == slow_pointer:
                return True

        return False

    # researched
    def hasCycle(self, head: Optional[ListNode]) -> bool:

        slow_pointer = head
        fast_pointer = head

        while fast_pointer and fast_pointer.next:
            slow_pointer = slow_pointer.next
            fast_pointer = fast_pointer.next.next

            if slow_pointer == fast_pointer:
                return True
        return False
