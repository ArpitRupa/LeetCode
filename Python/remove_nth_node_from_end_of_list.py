# Given the head of a linked list, remove the nth node from the end of the list and return its head.

# Definition for singly-linked list.
from typing import Optional


class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next


class Solution:

    # dry implementation
    # find number of nodes in LL
    # find the node right before the n-to last element
    # have the node right before the n-to last point to the next of n-to-last node
    def removeNthFromEnd(self, head: Optional[ListNode], n: int) -> Optional[ListNode]:

        linked_list_size = 0
        dumby = ListNode(0, head)
        current_head = dumby

        while current_head is not None:
            linked_list_size += 1
            current_head = current_head.next

        current_node_index = 0
        current_head = dumby

        # get node right before the nth to last element
        while current_node_index != linked_list_size - n - 1 and current_head is not None:
            current_node_index += 1
            current_head = current_head.next

        if current_head.next is not None:
            current_head.next = current_head.next.next

        if current_node_index == 0:
            head = head.next

        return head

    # researched solution
    # two pointers
    # make their distance n + 1
    # when the right most pointer reaches null, lp.next = lp.next.next
    def removeNthFromEnd(self, head: Optional[ListNode], n: int) -> Optional[ListNode]:

        # dumby for lp and in the event we return empty list
        dumby = ListNode(0, head)
        rp = head
        lp = dumby

        # set the distance of the pointers to size n
        while n > 0:
            rp = rp.next
            n -= 1

        # make lp point the node before n-to-last node
        while rp is not None:
            rp = rp.next
            lp = lp.next

        # delete the n-to-last node
        lp.next = lp.next.next

        return dumby.next
