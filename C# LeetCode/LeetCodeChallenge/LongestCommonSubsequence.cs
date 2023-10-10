// Given two strings text1 and text2, return the length of their longest common subsequence. If there is no common subsequence, return 0.
// A subsequence of a string is a new string generated from the original string with some characters (can be none) deleted without changing the relative order of the remaining characters.
//     For example, "ace" is a subsequence of "abcde".
// A common subsequence of two strings is a subsequence that is common to both strings.
//
// Constraints:
//     1 <= text1.length, text2.length <= 1000
//     text1 and text2 consist of only lowercase English characters.

// My Runtime:
// O(n*m) n = len of str1 and m = len of str2

// create a len(str1) + 1 X len(str2) + 1 matrix
// iterate through matrix cells
// set cell value to revious cell plus 1 if match in char
// or set it to max of previous cell/top cell if no match
// the last cell will have the max subseq
using Microsoft.VisualBasic;

namespace LeetcodeSolutions
{
    public class LongestCommonSubseq : SolutionClass<(string, string), int>
    {
        int[,] matrix = null;
        protected override int Solution((string, string) strings)
        {
            string text1 = strings.Item1;
            string text2 = strings.Item2;

            int matrixRows = text1.Length + 1;
            int matrixCols = text2.Length + 1;

            //create matrix with extra rows and columns for DP
            int[,] matrix = new int[matrixRows, matrixCols];

            //traverse matrix
            for (int i = 1; i < matrixRows; i++)
            {
                for (int j = 1; j < matrixCols; j++)
                {
                    //need to do -1 to account for extra rows/columns
                    if (text1[i - 1] == text2[j - 1])
                    {
                        //add one to previous row cell
                        matrix[i, j] = matrix[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        //max of previous adjacent cells
                        matrix[i, j] = Math.Max(matrix[i, j - 1], matrix[i - 1, j]);
                    }
                }
            }

            this.matrix = matrix;
            return matrix[text1.Length, text2.Length];
        }

        public void PrintMatrix()
        {
            int rows = this.matrix.GetLength(0);
            int cols = this.matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + "\t"); //"\t" to separate elements with tabs
                }
                Console.WriteLine(); // move to the next row
            }
        }

    }
}
