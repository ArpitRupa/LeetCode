// Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
// Symbol       Value
// I             1
// V             5
// X             10
// L             50
// C             100
// D             500
// M             1000

// For example, 2 is written as II in Roman numeral, just two one's added together. 12 is written as XII, which is simply X + II. The number 27 is written as XXVII, which is XX + V + II.

// Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. Instead, the number four is written as IV. Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:

//     I can be placed before V (5) and X (10) to make 4 and 9. 
//     X can be placed before L (50) and C (100) to make 40 and 90. 
//     C can be placed before D (500) and M (1000) to make 400 and 900.

// Given an integer, convert it to a roman numeral.
// Constraints:

//     1 <= num <= 3999

public class IntegerToRoman {

    /**
     * Takes an int (num) and returns the roman numeral equivalent as a string
     *
     * @param int num to convert to roman numeral
     * @return Roman numeral String equivalent of int parameter provided
     */

    public String intToRoman(int num) {

        String[] romanNums = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
        int[] naturalNums = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };

        String roman = "";
        int currentNum = num;

        int floorFactor = 0;

        for (int i = 0; i < romanNums.length; i++) {

            while (naturalNums[i] <= currentNum) {

                // get factor from floor division
                floorFactor = currentNum / naturalNums[i];

                // add roman character depending on the floor division
                roman += romanNums[i].repeat(floorFactor);

                // update current num value by subtracting factor * natNums[i]
                currentNum = currentNum - (floorFactor * naturalNums[i]);
            }
        }

        return roman;
    }

}
