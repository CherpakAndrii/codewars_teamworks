using System;

namespace HELP_I_NEED_SOMEBODY
{
    public class HashTable
    {
        private class Node
        {
            public readonly string Key;
            public readonly double Value;

            public Node(string key, double value)
            {
                Key = key;
                Value = value;
            }
        }
        private int _tableSize;
        private int _numberOfElements;
        private Node[] _data;

        public HashTable()
        {
            _data = new Node[50];
            _tableSize = 50;
            _numberOfElements = 0;
        }

        public void Add(string key, double value)
        {
            int Id = Math.Abs(key.GetHashCode()) % _tableSize;
            Console.WriteLine(key.GetHashCode() % _tableSize);
            while (_data[Id] != null) Id = (Id + 1) % _tableSize;
            _data[Id] = new Node(key, value);
            _numberOfElements++;
            if (_numberOfElements >= _tableSize * 0.8) Resize();
        }

        public double FindByKey(string key)
        {
            int id = Math.Abs(key.GetHashCode()) % _tableSize;
            while (_data[id] != null && _data[id].Key != key) id = (id + 1) % _tableSize;
            if (_data[id] == null) return default;
            return _data[id].Value;
        }

        private void Resize()
        {
            Node[] oldArray = _data;
            _data = new Node[_tableSize * 2];
            _tableSize *= 2;
            _numberOfElements = 0;
            foreach (Node node in oldArray)
            {
                if (node != null)
                {
                    Add(node.Key, node.Value);
                }
            }
        }
    }
}