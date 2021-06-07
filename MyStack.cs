namespace HELP_I_NEED_SOMEBODY
{
    public class MyStack
    {
        private int _size;
	    public Node Bottom;
	    public Node Top;
	    public class Node
	    {
		    public double Value;
		    public Node Prev;
		    public Node(double val)
		    {
			    Value = val;
			    Prev = null;
		    }
	    }
	    public MyStack()
	    {
		    Bottom = Top = null;
		    _size = 0;
	    }
	    public void Push(double val)
	    {
		    Node n = new Node(val);
		    _size++;
		    if (Top == null)
		    {
        				Bottom = Top = n;
		    }
		    else
		    {
			    n.Prev = Top;
			    Top = n;
		    }
	    }
	    public double Pop()
	    {
		    Node n = Bottom;
		    if (_size == 1)
		    {
			    _size--;
			    Bottom = Top = null;
		    }
		    else
		    {
			    Top = Top.Prev;
			    _size--;
		    }
		    return n.Value;
	    }
	    public int Size()
	    {
		    return _size;
	    }
    }
}