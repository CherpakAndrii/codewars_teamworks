namespace HELP_I_NEED_SOMEBODY
{
    public class MyLinkedList
    {
        private int _size;
	    public Node First;
	    public Node Last;
	    public class Node
	    {
		    public double Value;
		    public Node Next;
		    public Node(double val)
		    {
			    Value = val;
			    Next = null;
		    }
	    }
	    public MyLinkedList() 
        {
			First = Last = null;
	        _size = 0;
        }
	    public void PushBack(double val)
		{
			Node n = new Node(val);
			_size++;
			if (First == null) First = Last = n;
			else
			{
				Last.Next = n;
				Last = n;
			}
		}
	    public void PushFront(double val)
		{
			Node n = new Node(val);
			_size++;
			if (First == null)
			{
				First = Last = n;
			}
			else
			{
				n.Next = First;
				First = n;
			}
		}
	    public double PopFront()
		{
			Node n = First;
			if (_size == 1)
			{
				_size--;
				First = Last = null;
			}
			else
			{
				First = First.Next;
				_size--;
			}
			return n.Value;
		}
	    public double this[int ind]
		{
			get
			{
				Node n = First;
				if (ind < 0 && -ind <= _size) ind = _size - ind;
				if (ind > _size) return Last.Value;
				for (int ctr = 0; ctr < ind; ctr++) n = n.Next;
				return n.Value;
			}
		}
	    public int Size()
	    {
		    return _size;
	    }
    }
}