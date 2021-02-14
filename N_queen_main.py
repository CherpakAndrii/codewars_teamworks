from N_queen_def import *


def chess(size, row, column):
    num_of_queens = 0
    desk = [[0] * size for i in range(size)]
    positions = [(a, b) for a in range(size) for b in range(size)]

    num_of_queens = fill(row, column, num_of_queens, positions, desk, size)
    res = search(positions, desk, num_of_queens, size)
    return res if res else ""

print(chess(5, 0, 2))