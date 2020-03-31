using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    class DanielsLinkedList<T> : IEnumerable<T>
    {
        private Node<T> _head;
        private Node<T> _current;

        public T Current => throw new NotImplementedException();

        public DanielsLinkedList()
        {
            this._head = null;
            this._current = _head;
        }

        public IEnumerator<T> GetEnumerator()
        {
            _current = this._head;
            while (_current != null)
            {
                yield return _current.Item;
                _current = _current.Next;
            }
        }


        public void Remove(T item)
        {
            if (IsEmpty()) { return; }
            int i = 0;
            _current = _head;
            while (_current.Next != null)
            {
                if (_current.Item.Equals(item)) { break; }
                i++;
                _current = _current.Next;
            }

            if (!_current.Item.Equals(item))
            {
                return;
            }

            this.removeFromPos(i+1);
        }

        public void Add(T item)
        {
            Node<T> node = new Node<T>(item);
            if(IsEmpty())
            {
                this._head = node;
                this._head.Next = null;
                return;
            }

            Node<T> temp = this._head;
            while (temp.Next != null)
            {
                temp = temp.Next;

            }
            temp.Next = node;
        }

        public void AddToHead(Node<T> node)
        {
            if(IsEmpty())
            {
                this._head = node;
                return;
            }

            node.Next = this._head;
            this._head = node;

        }

        public void AddToPos(Node<T> node, int pos)
        {
            Node<T> temp = this._head;
            Node<T> prev = null;
            for(int i = 1; i < pos; i++)
            {
                if (temp.Next == null)
                {
                    Console.WriteLine("position too high ;)");
                    return;
                }
                prev = temp;
                temp = temp.Next;
                
            }

            prev.Next = node;
            node.Next = temp;
        }

        public void RemoveFromTail()
        {
            if(IsEmpty())
            {
                Console.WriteLine("bruh");
                return;
            }
            Node<T> temp = this._head;
            Node<T> prev = null;

            while(temp.Next !=null)
            {
                prev = temp;
                temp = temp.Next;
            }
            prev.Next = null;
        }

        public void RemoveFromFront()
        {
            this._head = this._head.Next;
        }

        public void removeFromPos(int pos)
        {
            Node<T> temp = this._head;
            Node<T> prev = temp;


            if(pos == 1)
            {
                RemoveFromFront();
                return;
            }
            for (int i = 1; i < pos; i++)
            {
                if (temp.Next == null)
                {
                    Console.WriteLine("position too high ;)");
                    return;
                }
                prev = temp;
                temp = temp.Next;
            }

            prev.Next = temp.Next;
        }

        public bool IsEmpty()
        {
            return this._head == null;
        }

        public void Dispose(){ }

        public bool MoveNext()
        {
            if(_current != null && _current.Next != null)
            {
                _current = _current.Next;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            _current = _head;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
