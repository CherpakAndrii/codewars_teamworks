#include "N_Queen_Problem.h"

int main()
{
  int size, row, column;
  cout<<"size: "; cin>>size;
  cout<<"row: "; cin>>row;
  cout<<"column: "; cin>>column;
  cout<<chess(size, row, column);
}
