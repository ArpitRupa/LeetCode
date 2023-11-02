# Definition for singly-linked list.
from typing import List, Optional


class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next


class Solution:
    def mergeKLists(self, lists: List[Optional[ListNode]]) -> Optional[ListNode]:

        if len(lists) == 0:
            return None

        if len(lists) == 1:
            return lists[0]

        merged_list = lists[0]

        for current_list in lists[1:]:
            merged_list_head = merged_list
            current_list_head = current_list

            if current_list.val <= merged_list_head.val:
                temp = merged_list_head
                temp_next_current = current_list.next
                current_list.next = merged_list_head
                merged_list_head = current_list
                current_list = temp_next_current

            while current_list_head is not None:

                print(current_list_head)

                if merged_list_head is None:
                    merged_list = current_list_head
                    break

                if merged_list_head.next is None:
                    merged_list_head.next = current_list_head
                    break

                if merged_list_head.next.val < current_list_head.val:
                    merged_list_head = merged_list_head.next

                elif merged_list_head.next.val >= current_list_head.val:
                    temp_node_merged = merged_list_head.next
                    temp_node_current = current_list_head.next

                    merged_list_head.next = current_list_head
                    current_list_head.next = temp_node_merged
                    current_list_head = temp_node_current

        return merged_list
