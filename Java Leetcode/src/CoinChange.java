// You are given an integer array coins representing coins of different denominations and an integer amount representing a total amount of money.
// Return the fewest number of coins that you need to make up that amount. If that amount of money cannot be made up by any combination of the coins, return -1.
// You may assume that you have an infinite number of each kind of coin.

// Constraints:
//     1 <= coins.length <= 12
//     1 <= coins[i] <= 231 - 1
//     0 <= amount <= 104

// my solution time complexity: O(amount*n)
public class CoinChange {

    /**
     * Takes a list of coins and an amount (int) to state how many coins (min) it
     * takes to create amount
     *
     * @param coins  The list of coin values.
     * @param amount The amount to reach with coins.
     * @return The minimum amount of coins to get that value (amount).
     */
    public int coinChange(int[] coins, int amount) {

        if (amount == 0) {
            return 0;
        }

        // array to hold least number of coins to get index value
        // +1 to account for 0
        int[] leastCoins = new int[amount + 1];

        for (int i = 1; i < leastCoins.length; i++) {
            // set inital value to amount + 1 so we can run min later
            leastCoins[i] = amount + 1;
            for (int j = 0; j < coins.length; j++) {

                // used to find already calculated min value of previous index to help with
                // current amount
                int valueMinusCoin = i - coins[j];

                // must be greater than -1 (denotes cannot be done) to be updated
                if (valueMinusCoin > -1) {
                    leastCoins[i] = Math.min(leastCoins[i], leastCoins[valueMinusCoin] + 1);
                }

            }
        }

        // return the int value at position [amount] if it got changed
        return leastCoins[amount] < amount + 1 ? leastCoins[amount] : -1;

    }
}
