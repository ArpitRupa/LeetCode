// Given the head of a singly linked list, sort the list using insertion sort, and return the sorted list's head.
//
// The steps of the insertion sort algorithm:
//
//     Insertion sort iterates, consuming one input element each repetition and growing a sorted output list.
//     At each iteration, insertion sort removes one element from the input data, finds the location it belongs within the sorted list and inserts it there.
//     It repeats until no input elements remain.


using System.Diagnostics.Metrics;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using LeetcodeSolutions;


public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}


public class InsertionSort : SolutionClass<ListNode, ListNode>
{
    public ListNode? head;

    public InsertionSort(List<int> intList)
    {
        if (intList.Count > 0)
        {
            this.head = new(val: intList[0]);
            for (int i = 1; i < intList.Count; i++)
            {
                ListNode sortedNode = new(val: intList[i]);

                //temp used to progress linked list
                ListNode temp = head;

                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = sortedNode;
            }
        }
    }

    protected override ListNode Solution(ListNode input)
    {
        if (input == null || input.next == null)
        {
            return input;
        }

        //sorted linked list
        ListNode sorted = null;
        //node to search sorted list for correct postion of insertion
        ListNode currentSortedNode = null;

        //current head of unsorted linked list
        ListNode unsortedHead = input;
        //next node of unsorted linked list
        ListNode next = null;

        //while the unsorted list is not empty
        while (unsortedHead != null)
        {
            next = unsortedHead.next;

            // if sorted is empty or the current node of unsorted LL is less than the sorted head
            if (sorted == null || unsortedHead.val <= sorted.val)
            {
                //insert current node at beginning of sorted list
                unsortedHead.next = sorted;
                sorted = unsortedHead;
            }
            else
            {
                //set currentSortedNode to head of sorted list
                currentSortedNode = sorted;

                // while we are not at the end of the sorted list and the current unsorted node is greater than the current sorted node's next value
                while (currentSortedNode.next != null && unsortedHead.val > currentSortedNode.next.val)
                {
                    //move down the sorted LL
                    currentSortedNode = currentSortedNode.next;
                }

                //once we reach the end of the sorted list OR the value of the current unsorted node is less than the current sorted node's next value

                // add the value to the sorted LL and change to next pointer
                unsortedHead.next = currentSortedNode.next;

                //point to the newly added node
                currentSortedNode.next = unsortedHead;
            }

            //move the head of the unsorted list
            unsortedHead = next;
        }

        //return head of sorted list
        return sorted;
    }

    public void Sort()
    {
        this.head = this.Solution(this.head);
    }

    public bool CheckSorted()
    {

        ListNode sortedNode = this.head;
        ListNode nextNode = this.head.next;
        while (nextNode != null)
        {

            if (sortedNode.val <= nextNode.val)
            {
                sortedNode = nextNode;
                nextNode = sortedNode.next;
            }
            else
            {
                return false;
            }

        }

        return true;
    }

    public void PrintLinkedList(string expected = "")
    {

        ListNode temp = this.head;

        string currentList = "";

        while (temp != null)
        {
            currentList += temp.val + " ";
            temp = temp.next;
        }

        Console.WriteLine(currentList + expected);
    }
}