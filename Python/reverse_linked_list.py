# Given the head of a singly linked list, reverse the list, and return the reversed list.
from typing import Optional


# Definition for singly-linked list.
class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next


class Solution:

    # iteratively
    def reverseList(self, head: Optional[ListNode]) -> Optional[ListNode]:

        new_head: ListNode = head
        previous_head = None

        # loop until we reach the end of the linked list
        while new_head is not None:

            # store for temporary acces
            next_node = new_head.next
            # update the new node's value to the previous head to reverse it
            new_head.next = previous_head
            # update the previous head as we change the node we are processing
            previous_head = new_head
            # update the next node to proces
            new_head = next_node

        # you must return the previous head here as the new head would be null/none
        return previous_head

    # recursion
    def reverseList(self, head: Optional[ListNode]) -> Optional[ListNode]:

        # base case
        if head is None or head.next is None:
            return head

        # run recusrion on everything after current head
        remaining_reversed = self.reverseList(head.next)

        # because when the recursion returns, everything after the current head is sorted, we need to set the orginal `next` of the next node to the current head
        # [1,2,3, none]
        # remain_rev = [3,2, none] -> [3,2,1]
        head.next.next = head

        # make sure we erase the next of the node
        head.next = None

        # return the new LL head
        return remaining_reversed
