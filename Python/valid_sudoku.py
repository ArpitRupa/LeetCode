from typing import List

# Determine if a 9 x 9 Sudoku board is valid. Only the filled cells need to be validated according to the following rules:

#     Each row must contain the digits 1-9 without repetition.
#     Each column must contain the digits 1-9 without repetition.
#     Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition.

# Note:

#     A Sudoku board (partially filled) could be valid but is not necessarily solvable.
#     Only the filled cells need to be validated according to the mentioned rules.

# MY SOLUTION RUNTIME:
# O(1)


class ValidSudoku:

    def __init__(self):
        # Initialize any instance-specific attributes here, if needed
        pass

    def isValidSudoku(self, board: List[List[str]]) -> bool:

        # create 9 sets to hold value of cells via rows
        row_sets = [set() for _ in range(9)]
        # create 9 sets to hold value of cells via cols
        col_sets = [set() for _ in range(9)]
        # create list of 3 lists of 3 sets for the 3x3 grids
        grid_sets = [[set() for _ in range(3)] for _ in range(3)]

        for i in range(9):
            for j in range(9):
                current_cell = board[i][j]

                # skip empty cells
                if current_cell == ".":
                    continue

                # check if cells are in any of the sets
                if (
                        current_cell in row_sets[i]
                        or current_cell in col_sets[j]
                        or current_cell in grid_sets[i // 3][j // 3]
                ):
                    return False

                # add cell to corresponding sets
                row_sets[i].add(current_cell)
                col_sets[j].add(current_cell)
                grid_sets[i // 3][j // 3].add(current_cell)

        return True
