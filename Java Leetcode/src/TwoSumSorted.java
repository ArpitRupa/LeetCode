import java.util.HashMap;
import java.util.Map;

// Given a 1-indexed array of integers numbers that is already sorted in non-decreasing order, find two numbers such that they add up to a specific target number. 
// Let these two numbers be numbers[index1] and numbers[index2] where 1 <= index1 < index2 < numbers.length.
// Return the indices of the two numbers, index1 and index2, added by one as an integer array [index1, index2] of length 2.
// The tests are generated such that there is exactly one solution. You may not use the same element twice.
// Your solution must use only constant extra space.

/// My solution's runtime: 
/// O(n) + O(n) = O(n)

public class TwoSumSorted {

    /**
     * Takes an int (num) and returns the roman numeral equivalent as a string
     *
     * @param numbers array of possible numbers to reach target value
     * @param target  int value to reach with two numbers
     * @return array of 2 indicies of values to reach the target value
     */

    public int[] twoSum(int[] numbers, int target) {

        // key = numbers[i] value = index
        Map<Integer, Integer> numsMap = new HashMap<>();

        for (int i = 0; i < numbers.length; i++) {
            numsMap.put(numbers[i], i);
        }

        // difference between numbers and current element
        int difference = 0;
        // array to store the indicies of two numbers
        int[] indicies = new int[2];

        for (int i = 0; i < numbers.length; i++) {

            difference = target - numbers[i];

            if (numsMap.containsKey(difference)) {
                indicies[0] = i + 1;
                indicies[1] = numsMap.get(difference) + 1;
                break;
            }

        }

        return indicies;
    }
}
