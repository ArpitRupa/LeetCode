
# You are given the heads of two sorted linked lists list1 and list2.

# Merge the two lists into one sorted list. The list should be made by splicing together the nodes of the first two lists.

# Return the head of the merged linked list.
from typing import Optional


# Definition for singly-linked list.
class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next


class Solution:
    def mergeTwoLists(self, list1: Optional[ListNode], list2: Optional[ListNode]) -> Optional[ListNode]:

        l1_head = list1
        l2_head = list2

        temp_node = ListNode(0)

        merged_head = temp_node

        # while both heads are not empty
        while (l1_head and l2_head):

            # the next vlaue of the merged LL is the min between the 2
            # update the list's head to the next value of the list
            if l1_head.val <= l2_head.val:
                merged_head.next = l1_head
                l1_head = l1_head.next
            else:
                merged_head.next = l2_head
                l2_head = l2_head.next

            # make sure to update the head of the merged LL to the next value
            merged_head = merged_head.next

        # find the non-empty linked list and set the next node to the head of it
        if l2_head is None:
            merged_head.next = l1_head
        if l1_head is None:
            merged_head.next = l2_head

        return temp_node.next
