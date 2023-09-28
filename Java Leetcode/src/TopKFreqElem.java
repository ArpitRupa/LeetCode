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
        // tracks current min of top K frequency
        Tuple currentMin = new Tuple(nums[0], 0);
        int currentMinIndex = 0;

        int[] tempList = new int[3];

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

            boolean found = false;
            // iterate through the arraylist of top frequency tuple
            for (int topKIndex = 0; topKIndex < topKTuples.size(); topKIndex++) {
                // current tuple's element
                int currentTopKElement = topKTuples.get(topKIndex).getElement();

                // if the element is already in the list just update it
                if (currentTopKElement == nums[index]) {
                    // set tuple's frequency to hashmap's
                    topKTuples.get(topKIndex).setFrequency(hashFrequency);
                    tempList = findMinFrequencyIndex(topKTuples);

                    currentMin.setElement(tempList[1]);
                    currentMin.setFrequency(tempList[2]);
                    currentMinIndex = tempList[0];
                    found = true;
                    break;
                }
            }
            if (!found && topKTuples.size() < k) {
                // if not in list, just add it
                topKTuples.add(new Tuple(nums[index], hashFrequency));

                currentMin.setElement(nums[index]);
                currentMin.setFrequency(hashFrequency);
                currentMinIndex = topKTuples.size() - 1;
            }

            // if new value count is greater than current least count
            if (topKTuples.get(currentMinIndex).getFrequency() < hashFrequency && !found) {
                currentMin.setElement(nums[index]);
                currentMin.setFrequency(hashFrequency);
                // update count
                topKTuples.set(currentMinIndex, new Tuple(nums[index], hashFrequency));
                tempList = findMinFrequencyIndex(topKTuples);

                currentMin.setElement(tempList[1]);
                currentMin.setFrequency(tempList[2]);
                currentMinIndex = tempList[0];

                System.out.println("LOOP Index: " + currentMinIndex);
            }

            printTupleList(topKTuples);
            System.out.println("Ele: " + currentMin.getElement());
            System.out.println("Freq: " + currentMin.getFrequency());
            System.out.println("Index: " + currentMinIndex);
        }

        printHashMap(elementFrequency);

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

    public static int[] findMinFrequencyIndex(List<Tuple> tupleList) {
        if (tupleList.isEmpty()) {
            return null; // Return -1 if the list is empty
        }

        int[] results = new int[3];
        int minIndex = 0; // Assume the first tuple has the minimum frequency
        int minFrequency = tupleList.get(0).getFrequency();
        int minElement = tupleList.get(0).getElement();

        for (int i = 1; i < tupleList.size(); i++) {
            int currentFrequency = tupleList.get(i).getFrequency();

            if (currentFrequency < minFrequency) {
                // Update minIndex and minFrequency if a smaller frequency is found
                minIndex = i;
                minFrequency = currentFrequency;
                minElement = tupleList.get(i).getElement();
            }
        }

        results[0] = minIndex;
        results[1] = minElement;
        results[2] = minFrequency;
        return results;
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