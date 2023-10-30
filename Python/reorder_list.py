# You are given the head of a singly linked-list. The list can be represented as:

# L0 → L1 → … → Ln - 1 → Ln

# Reorder the list to be on the following form:

# L0 → Ln → L1 → Ln - 1 → L2 → Ln - 2 → …

# You may not modify the values in the list's nodes. Only nodes themselves may be changed.

from typing import Optional


class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next

# midpoint will be new end
# find midpoint with 2 points
# process nodes after mid point


class Solution:

    # dry implmentation
    # find midpoint and tail of linked list
    # make a stack of nodes from mid - tail
    # process nodes from head - mid popping the last element in stack from mid - tail
    # process if the LL has even or odd number of nodes

    def reorderList(self, head: Optional[ListNode]) -> None:
        """
        Do not return anything, modify head in-place instead.
        """

        mid_pointer = head
        end_pointer = head.next

        # find the midpoint and the tail of the LL
        while end_pointer is not None and end_pointer.next is not None:
            mid_pointer = mid_pointer.next
            end_pointer = end_pointer.next.next

        current_node_after_mid = mid_pointer.next
        nodes_after_mid = []

        # append of list of nodes after mid
        while current_node_after_mid is not None:
            nodes_after_mid.append(current_node_after_mid)
            current_node_after_mid = current_node_after_mid.next

        current_node_pointer = head

        # process nodes from head to midpoint
        while current_node_pointer != mid_pointer:
            # temporary storage for inital next value
            temp_node = current_node_pointer.next
            current_node_pointer.next = nodes_after_mid.pop()
            current_node_pointer.next.next = temp_node

            current_node_pointer = current_node_pointer.next.next

        # if nodes_after_mid count = 1, we know LL has even number of nodes
        # must make the element after "mid element" to n
        if len(nodes_after_mid) == 1:
            nodes_after_mid[0].next = None
        else:
            mid_pointer.next = None

    # researched implementation

    def reorderList(self, head: Optional[ListNode]) -> None:
        """
        Do not return anything, modify head in-place instead.
        """

        mid_pointer = head
        end_pointer = head.next

        # get mid and tail of LL
        while end_pointer is not None and end_pointer.next is not None:
            mid_pointer = mid_pointer.next
            end_pointer = end_pointer.next.next

        # sort from mid to tail of LL
        head_after_mid = mid_pointer.next
        mid_pointer.next = None
        previous_head = None

        while head_after_mid is not None:
            next_node = head_after_mid.next
            head_after_mid.next = previous_head
            previous_head = head_after_mid
            head_after_mid = next_node

        head_after_mid = previous_head

        # reorder list
        while head_after_mid is not None:
            temp = head.next
            head.next = head_after_mid
            head_after_mid = head_after_mid.next
            head.next.next = temp
            head = temp
