using System;
using System.Collections.Generic;

namespace HELP_I_NEED_SOMEBODY
{
    public class Tree
    {
        public class Node
        {
            public readonly int Data;
            public Node Left, Right, Parent;

            public Node(int value)
            {
                Data = value;
                Right = Left = Parent = null;
            }
            public int childsCounter()
            {
                int childs = 0;
                if (Left != null) childs++;
                if (Right != null) childs++;
                return childs;
            }
        }
        
        public Node Root;
        private int _depth=0;
        public int Depth() { return _depth; }
        public void Add(int val)
        {
            Node node = new(val);
            if (_depth==0)
            {
                Root = node;
                _depth = 1;
                return;
            }
            Node current = Root;
            int currentDepth = 1;
            while (true)
            {
                if (current.Data>node.Data)
                {
                    if (current.Left == null)
                    {
                        current.Left = node;
                        node.Parent = current;
                        currentDepth++;
                        if (currentDepth > _depth) _depth = currentDepth;
                        break;
                    }
                    current = current.Left;
                    currentDepth++;
                }
                else if (current.Data < node.Data)
                {
                    if (current.Right == null)
                    {
                        current.Right = node;
                        node.Parent = current;
                        currentDepth++;
                        if (currentDepth > _depth) _depth = currentDepth;
                        break;
                    }

                    current = current.Right;
                    currentDepth++;
                }
                else break;
            }
        }

        private static Node getLeftsRightest(Node node)
        {
            if (node.Right == null) return node;
            return getLeftsRightest(node.Right);
        }
        private static Node getRightsLeftest(Node node)
        {
            if (node.Left == null) return node;
            return getRightsLeftest(node.Right);
        }

        private Node DeleteNode(Node root)
        {
            switch (root.childsCounter())
            {
                case 0:
                    if (root.Parent == null)
                    {
                        Root = null;
                        _depth = 0;
                        return root;
                    }

                    if (root.Parent.Left == root)
                    {
                        root.Parent.Left = null;
                        return root;
                    }

                    root.Parent.Right = null;
                    return root;
                case 1:
                    Node newRoot = root.Left ?? root.Right;
                    if (root.Parent == null)
                    {
                        newRoot.Parent = null;
                        Root = newRoot;
                        return root;
                    }

                    newRoot.Parent = root.Parent;
                    if (root.Parent.Left == root) root.Parent.Left = newRoot;
                    else root.Parent.Right = newRoot;
                    return root;
                case 2:
                    Node rightsLeftest = getRightsLeftest(root.Right);
                    Node leftsRightest = getLeftsRightest(root.Left);
                    Node NewRoot = DeleteNode(leftsRightest.childsCounter() < rightsLeftest.childsCounter()?leftsRightest:rightsLeftest);
                    NewRoot.Parent = root.Parent;
                    NewRoot.Left = root.Left;
                    NewRoot.Right = root.Right;
                    root.Left.Parent = root.Left.Parent = NewRoot;
                    if (root.Parent.Left == root) root.Parent.Left = NewRoot;
                    else root.Parent.Right = NewRoot;
                    return root;
            }
            return null;
        }
        public bool Remove(double val, Node root)
        {
            if (root.Data == val)
            {
                DeleteNode(root);
                return true;
            }
            if (val < root.Data && root.Left != null) return Remove(val, root.Left);
            if (val > root.Data && root.Right != null) return Remove(val, root.Right);
            return false;
        }
        
        public void Print()
        {
            List<int> paddings = new List<int>{0};
            Traverse(Root);
            void Traverse(Node node)
            {
                if (node == null) return;
                string prettyPadding = paddings[paddings.Count-1]==1 ? "├──" : "└──";
                Console.Write($"{GetPadding(paddings)}{prettyPadding} ");
                Console.ForegroundColor = (ConsoleColor) (paddings.Count % 10 );
                Console.WriteLine(node.Data);
                Console.ForegroundColor = ConsoleColor.Gray;
                paddings.Add(node.Right==null?0:1);
                Traverse(node.Left);
                paddings[paddings.Count - 1] = 0;
                Traverse(node.Right);
                paddings.RemoveAt(paddings.Count - 1);
            }
        }

        private static string GetPadding(List<int> paddings)
        {
            string newStr = "";
            for (int i = 0; i<paddings.Count-1; i++) newStr += (paddings[i] == 1 ? "| " : "  ");
            return newStr;
        }
        
        /*private void _fill(ref string[,] matr, int y, int x, string direction, int maxWidth, Node node)
        {
            if (direction == "left")
            {
                int e = (maxWidth - x) / 2; x++; y--;
                for (int ctr = 0; ctr < e; ctr++)
                {
                    matr[y, x] = "/";
                    x++;
                    y--;
                }
            }
            else if (direction == "right")
            {
                int e = (maxWidth - x) / 2; x++; y++;
                for (int ctr = 0; ctr < e; ctr++)
                {
                    matr[y, x] = @"\";
                    x++; y++;
                }
            }
            else return;
            if (node.Data < 10 || x+1 == maxWidth) matr[y, x] = Convert.ToString(node.Data);
            else
            {
                matr[y, x] = Convert.ToString(node.Data/10);
                Console.WriteLine();
                matr[y, x+1] = Convert.ToString(node.Data%10);
            }
            if (node.Left != null) _fill(ref matr, y, x, "left", maxWidth, node.Left);
            if (node.Right != null) _fill(ref matr, y, x, "right", maxWidth, node.Right);
        }

        private static bool _isEmpty(string[,] matr, int i, int width)
        {
            for (int j = 0; j<width; j++) if (matr[i, j] != " ") return false;
            return true;
        }
        public void OutpTree()
        {
            int matrWidth = 0;
            for (int ctr = 0; ctr < _depth; ctr++)
            {
                matrWidth = matrWidth * 2 + 1;
            }
            int matrHight = matrWidth * 2 - 1;
            string[,] matr = new string[matrHight, matrWidth];
            for (int i = 0; i < matrHight; i++) for (int j = 0; j < matrWidth; j++) matr[i, j] = " ";
            if (Root.Data < 10 || matrWidth == 1) matr[matrHight / 2, 0] = Convert.ToString(Root.Data);
            else
            {
                matr[matrHight / 2, 0] = Convert.ToString(Root.Data/10);
                matr[matrHight / 2, 1] = Convert.ToString(Root.Data%10);
            }
            if (Root.Left!=null) _fill(ref matr, matrHight / 2, 0,"left", matrWidth, Root.Left);
            if (Root.Right!=null) _fill(ref matr, matrHight / 2, 0,"right", matrWidth, Root.Right);
            for (int i = 0; i < matrHight; i++)
            {
                if (_isEmpty(matr, i, matrWidth)) continue;
                for (int j = 0; j < matrWidth; j++) Console.Write(matr[i, j]); Console.WriteLine();
            }
        }*/
        private void do_something(Node n){}

        public void NLR(Node node)  //прямий
        {
            do_something(node);
            if (node.Left != null) NLR(node.Left);
            if (node.Right != null) NLR(node.Right);
        }
        public void LRN(Node node)  //зворотній
        {
            if (node.Left != null) LRN(node.Left);
            if (node.Right != null) LRN(node.Right);
            do_something(node);
        }
        public void LNR(Node node)  //симетричний
        {
            if (node.Left != null) LNR(node.Left);
            do_something(node);
            if (node.Right != null) LNR(node.Right);
        }
    }
}