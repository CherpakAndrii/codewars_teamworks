from random import randint
import time

def chess(s, r, c):
    q = 0
    desk = [[0] * s for i in range(s)]
    pos = [(a, b) for a in range(s) for b in range(s)]

    def fill(r, c, q):
        q += 1
        desk[r][c] = "Q"
        pos.remove((r, c))
        for j in range(s):
            if desk[r][j] == 0:
                desk[r][j] = '.'
                pos.remove((r, j))
        for i in range(s):
            if desk[i][c] == 0:
                desk[i][c] = '.'
                pos.remove((i, c))
        if r>=c:
            n = r-c
            m = 0
        else:
            n = 0
            m = c-r
        while n < s and m < s:
            if desk[n][m] == 0:
                desk[n][m] = '.'
                pos.remove((n, m))
            n += 1
            m += 1
        if r+c<=s-1:
            n = 0
            m = r+c
        else:
            n = r+c-s+1
            m = s-1
        while n < s and m >= 0:
            if desk[n][m] == 0:
                desk[n][m] = '.'
                pos.remove((n, m))
            n += 1
            m -= 1
        return q

    q = fill(r, c, q)
    while True:
        q = 1
        while len(pos)>0:
            p = pos[randint(0, len(pos)-1)]
            q = fill(p[0], p[1], q)
        if q >= s:
            string = ''
            for l in desk:
                for e in l: string += e
                string += '\n'
            return string[:-1]
        else:
            desk = [[0] * s for i in range(s)]
            pos = [(a, b) for a in range(s) for b in range(s)]
            q = 0
            q = fill(r, c, q)

f = open("new_f.txt", "a")
f.write(chess(8, 0, 2))
f.write("\n\n")
f.close()
