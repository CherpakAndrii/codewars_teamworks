namespace HELP_I_NEED_SOMEBODY
{
	public class MyQueue
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

		public MyQueue()
		{
			First = Last = null;
			_size = 0;
		}

		public void Push(double val)
		{
			Node n = new Node(val);
			_size++;
			if (First == null)
			{
				First = Last = n;
			}
			else
			{
				Last.Next = n;
				Last = n;
			}
		}
		public double Pop()
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
		public int Size()
		{
			return _size;
		}
	}
}