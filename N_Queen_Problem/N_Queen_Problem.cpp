#include <vector>
#include <string>
#include <iostream>
using namespace std;

int main()
{

}

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

int fill(int row, int column, int num_of_queens, vector<vector<int>>& pos, char**& desk, int size) {
    num_of_queens += 1;
    desk[row][column] = 'Q';
    int i = 0;
    for (vector<int> l:pos) {
        if (pos[i][0] == row || pos[i][1] == column) {
            pos.erase(pos.begin() + i, pos.begin() + i+1);
        }
        else i++;
    }
    for (int j = 0; j < size; j++){
        if (!desk[row][j]) desk[row][j] = '.';
        if (!desk[j][column]) desk[j][column] = '.';
    }
    if (row>=column){
        int n = row-column;
        int m = 0;
      }
    else{
        int n = 0;
        int m = column-row;
      }
    while (n < size && m < size){
        if (!desk[n][m]){
            desk[n][m] = '.';
            vector<int> K = { n, m };
            auto it = pos.find(pos.begin(), pos.end(), K);
            pos.erase(it, it+1);
          }
        n += 1;
        m += 1;
      }
    if (row+column<=size-1){
        int n = 0;
        int m = row+column;
      }
    else{
        int n = row+column-size+1;
        int m = size-1;
      }
    while (n < size and m >= 0){
        if (!desk[n][m]){
            desk[n][m] = '.';
            vector<int> K = { n, m };
            auto it = pos.find(pos.begin(), pos.end(), K);
            pos.erase(it, it+1);
          }
        n += 1;
        m -= 1;
      }
    return num_of_queens;
}
