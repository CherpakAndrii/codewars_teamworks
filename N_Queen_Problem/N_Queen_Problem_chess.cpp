#include "N_Queen_Problem.h"

string chess(int size, int row, int column) {
    vector<vector<int>> pos;
    int num_of_queens = 0;
    char** desk = new char* [size];
    for (int i = 0; i < size; i++){
        desk[i] = new char[size];
        for (int j = 0; j < size; j++) {
            pos.push_back({ i, j });
        }
    }
    num_of_queens = fill(row, column, num_of_queens, pos, desk, size);
    string res = search(pos, desk, num_of_queens, size);
    if (res) return res;
    else return "";
}
