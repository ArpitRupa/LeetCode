# You are given an array prices where prices[i] is the price of a given stock on the ith day.

# You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.

# Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.


# Constraints:

#     1 <= prices.length <= 105
#     0 <= prices[i] <=

# My soltuion runtime:
# O(n) where n = len of the list

# loop through the list keeping track of the current lowest value found in the list
# if the lowest value is not updated, find the max between the profit of selling now vs prevous max profit
# return max_profit

from typing import List


class Solution:
    def maxProfit(self, prices: List[int]) -> int:

        if (len(prices) < 2) or not prices:
            return 0

        min_price = prices[0]
        max_profit = 0

        for num in prices:

            if num < min_price:
                min_price = num
            else:

                profit = num - min_price

                max_profit = max(profit, max_profit)

        return max_profit
