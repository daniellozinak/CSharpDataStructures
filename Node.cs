
namespace DataStructures
{
    class Node<T>
    {
        private T _item;
        private Node<T> _next;

        public Node()
        {
            this._next = null;
        }

        public Node(T item)
        {
            this._item = item;
        }

        public T Item
        {
            get { return _item; }
            set { _item = value; }
        }

        public Node<T> Next
        {
            get { return _next; }
            set { _next = value; }
        }
    }
}
