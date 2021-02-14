def search(positions, desk, num_of_queens, size):
    for i in range(len(positions)):
        n_pos = positions.copy()
        c_q = num_of_queens
        copy_desk = [desk[i].copy() for i in range(size)]
        c_q = fill(n_pos[i][0], n_pos[i][1], c_q, n_pos, copy_desk, size)
        if c_q == size:
            string = ''
            for line in copy_desk:
                for symbol in line: string += symbol
                string += '\n'
            return string[:-1]
        elif len(n_pos) > 0:
            s = search(n_pos, copy_desk, c_q, size)
            if s: return s

def fill(row, column, num_of_queens, positions, desk, size):
    num_of_queens += 1
    desk[row][column] = "Q"
    positions.remove((row, column))
    for j in range(size):
        if desk[row][j] == 0:
            desk[row][j] = '.'
            positions.remove((row, j))
    for i in range(size):
        if desk[i][column] == 0:
            desk[i][column] = '.'
            positions.remove((i, column))
    if row>=column:
        n = row-column
        m = 0
    else:
        n = 0
        m = column-row
    while n < size and m < size:
        if desk[n][m] == 0:
            desk[n][m] = '.'
            positions.remove((n, m))
        n += 1
        m += 1
    if row+column<=size-1:
        n = 0
        m = row+column
    else:
        n = row+column-size+1
        m = size-1
    while n < size and m >= 0:
        if desk[n][m] == 0:
            desk[n][m] = '.'
            positions.remove((n, m))
        n += 1
        m -= 1
    return num_of_queens