def search(p, d, q, size):
    for i in range(len(p)):
        n_pos = p.copy()
        c_q = q
        c_desk = [d[i].copy() for i in range(size)]
        c_q = fill(p[i][0], p[i][1], c_q, n_pos, c_desk, size)
        if c_q == size:
            string = ''
            for l in c_desk:
                for e in l: string += e
                string += '\n'
            return string[:-1]
        elif len(n_pos)>0:
            s = search(n_pos, c_desk, c_q, size)
            if s!=None: return s

def fill(r, c, q, pos, desk, size):
    q += 1
    desk[r][c] = "Q"
    pos.remove((r, c))
    for j in range(size):
        if desk[r][j] == 0:
            desk[r][j] = '.'
            pos.remove((r, j))
    for i in range(size):
        if desk[i][c] == 0:
            desk[i][c] = '.'
            pos.remove((i, c))
    if r>=c:
        n = r-c
        m = 0
    else:
        n = 0
        m = c-r
    while n < size and m < size:
        if desk[n][m] == 0:
            desk[n][m] = '.'
            pos.remove((n, m))
        n += 1
        m += 1
    if r+c<=size-1:
        n = 0
        m = r+c
    else:
        n = r+c-size+1
        m = size-1
    while n < size and m >= 0:
        if desk[n][m] == 0:
            desk[n][m] = '.'
            pos.remove((n, m))
        n += 1
        m -= 1
    return q
