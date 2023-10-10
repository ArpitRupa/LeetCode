// Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it can trap after raining.



public class TrapingRainWater
{

    // My Runtime:
    // O(n)
    // make two lists to keep track of right and left max per an index
    // add to total volume via min(leftMax, rightMax) - height[i]
    public int Trap1(int[] height)
    {

        if (height == null)
        {
            return 0;
        }

        int totalVolume = 0;

        int arrayLength = height.Length;
        // arrays to keep track of left and right max per index
        int[] leftMax = new int[arrayLength];
        int[] rightMax = new int[arrayLength];

        leftMax[0] = height[0];
        rightMax[arrayLength - 1] = height[arrayLength - 1];

        // calculate max left for index
        for (int i = 1; i < arrayLength; i++)
        {
            leftMax[i] = Math.Max(leftMax[i - 1], height[i]);
        }

        // calculate max right for index
        for (int i = arrayLength - 2; i >= 0; i--)
        {
            rightMax[i] = Math.Max(rightMax[i + 1], height[i]);
        }

        // calculate volume per index and add to totalVolume
        for (int i = 0; i < arrayLength; i++)
        {
            totalVolume += Math.Min(leftMax[i], rightMax[i]) - height[i];
        }

        return totalVolume;

    }



    // My Runtime:
    // O(n)
    // intalize 2 pointers 1 at the beginning of the list and one at the end
    // keep track of the min of the left and right size
    // if the max of left is less than the max of right, increment left pointer, get new maxleft, and add to value subtracting he current value
    // same for right but decrement the pointer
    // return the total volume when pointers intersect
    public int Trap2(int[] height)
    {
        int leftPointer = 0;
        int rightPointer = height.Count() - 1;
        int totalVolume = 0;

        int maxLeft = height[leftPointer];
        int maxRight = height[rightPointer];

        while (leftPointer < rightPointer)
        {
            int rightValue;
            int leftValue;

            if (maxLeft < maxRight)
            {
                leftPointer++;
                leftValue = height[leftPointer];
                maxLeft = Math.Max(maxLeft, leftValue);
                totalVolume += maxLeft - leftValue;

            }
            else
            {
                rightPointer--;
                rightValue = height[rightPointer];
                maxRight = Math.Max(maxRight, rightValue);
                totalVolume += maxRight - rightValue;
            }
        }

        return totalVolume;

    }
}