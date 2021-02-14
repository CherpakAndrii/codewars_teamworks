from N_queen_def import *

def chess(size, r, c):
    q = 0
    desk = [[0] * size for i in range(size)]
    pos = [(a, b) for a in range(size) for b in range(size)]

    q = fill(r, c, q, pos, desk, size)
    s = search(pos, desk, q, size)
    return ("" if s == None else s)