import java.util.Arrays;
import java.util.Collections;
import java.util.Comparator;
import java.util.HashMap;
import java.util.Map;
import java.util.ArrayList;
import java.util.List;

// Given an integer array nums and an integer k, return the k most frequent
// elements. You may return the answer in any order.

// Constraints:
// 1 <= nums.length <= 105
// -104 <= nums[i] <= 104
// k is in the range [1, the number of unique elements in the array].
// It is guaranteed that the answer is unique.

// Follow up: Your algorithm's time complexity must be better than O(n log n),
// where n is the array's size.

class TopKFreqElem {

    public int[] topKFrequent(int[] nums, int k) {

        // HashMap to store frequency of elements
        Map<Integer, Integer> elementFrequency = new HashMap<>();

        // List of tuple to store top elements and their frequency
        List<Tuple> topKTuples = new ArrayList<>();

        // iterate through the provided array
        for (int index = 0; index < nums.length; index++) {

            // if the current element has occured before in the array
            if (elementFrequency.containsKey(nums[index])) {
                // get the value
                int currentEntryValue = elementFrequency.get(nums[index]);
                // update it by one
                elementFrequency.put(nums[index], currentEntryValue + 1);
            } else {
                // just set it to one
                elementFrequency.put(nums[index], 1);
            }

            // current element's frequency via the hash map
            int hashFrequency = elementFrequency.get(nums[index]);

            if (index == 0) {
                topKTuples.add(new Tuple(nums[index], hashFrequency));
            }

            boolean found = false;
            // iterate through the arraylist of top frequency tuple
            for (int topKIndex = 0; topKIndex < topKTuples.size(); topKIndex++) {
                // current tuple's element
                int currentTopKElement = topKTuples.get(topKIndex).getElement();

                // if the element is already in the list just update it
                if (currentTopKElement == nums[index]) {
                    // set tuple's frequency to hashmap's
                    topKTuples.get(topKIndex).setFrequency(hashFrequency);
                    found = true;
                    break;
                }
            }
            if (!found && topKTuples.size() < k) {
                // if not in list, just add it
                topKTuples.add(new Tuple(nums[index], hashFrequency));
            }

            // if new value count is greater than current least count
            if (topKTuples.get(0).getFrequency() < elementFrequency.get(nums[index]) && !found) {
                // update count
                topKTuples.set(0, new Tuple(nums[index], elementFrequency.get(nums[index])));
            }
            Collections.sort(topKTuples, Comparator.comparingInt(Tuple::getFrequency));
        }

        int[] topKElements = new int[k];

        // generate list of top elements
        for (int i = 0; i < topKElements.length; i++) {
            topKElements[i] = topKTuples.get(i).getElement();
        }

        return topKElements;

    }

    private static void printHashMap(Map<Integer, Integer> dict) {
        System.out.println("HashMap: ");
        for (Map.Entry<Integer, Integer> entry : dict.entrySet()) {
            int key = entry.getKey();
            int value = entry.getValue();
            System.out.println("Element: " + key + ", Frequency: " + value);
        }
    }

    private static void printTupleList(List<Tuple> tupleList) {
        System.out.println("Top Elements: ");
        for (Tuple tuple : tupleList) {
            System.out.println("Element: " + tuple.getElement() + " Frequency: " + tuple.getFrequency());
        }
    }

    private void testSort() {
        List<Tuple> tupleList = new ArrayList<>();
        tupleList.add(new Tuple(1, 10));
        tupleList.add(new Tuple(2, 20));
        tupleList.add(new Tuple(3, 5));

        // Sort the ArrayList based on frequency in ascending order
        Collections.sort(tupleList, Comparator.comparingInt(Tuple::getFrequency));

        // Print the sorted ArrayList
        for (Tuple tuple : tupleList) {
            System.out.println("Element: " + tuple.getElement() + " Frequency: " + tuple.getFrequency());
        }
    }

}

class Tuple {
    private int element;
    private int frequency;

    public Tuple(int element, int frequency) {
        this.element = element;
        this.frequency = frequency;
    }

    public int getElement() {
        return this.element;
    }

    public int getFrequency() {
        return this.frequency;
    }

    public void setElement(int element) {
        this.element = element;
    }

    public void setFrequency(int frequency) {
        this.frequency = frequency;
    }
}