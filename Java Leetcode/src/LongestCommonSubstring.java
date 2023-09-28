
// Given two strings ‘X’ and ‘Y’, find the length of the longest common substring. 

//my solution time complexity: 

public class LongestCommonSubstring {

    /**
     * Takes two strings and returns the length of the longest common substring
     *
     * @param a First String.
     * @param b Second String.
     * @return The length of the longest common substring as an int
     */
    public int longestCommonSubStr(String a, String b) {

        int aLen = a.length();
        int bLen = b.length();
        int maxLength = 0;
        int[][] matrix = new int[aLen + 1][bLen + 1];

        // iterate through strings (skip first row and col)
        for (int i = 1; i < aLen + 1; i++) {
            for (int j = 1; j < bLen + 1; j++) {
                // if match found; add to previous diagonal poistion
                if (a.charAt(i - 1) == b.charAt(j - 1)) {
                    matrix[i][j] = matrix[i - 1][j - 1] + 1;

                    // update max substring length if current cell is greater after update
                    if (matrix[i][j] > maxLength) {
                        maxLength = matrix[i][j];
                    }
                }
            }
        }

        return maxLength;
    }

}
