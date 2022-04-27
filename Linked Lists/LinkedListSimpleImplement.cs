public class GenericList<T>
{
    public class Node
    {
        // fields
        private Node next;
        private T data;

        // construtor
        public Node(T t)
        {
            next = null;
            data = t;
        }

        // property setter and getter
        public Node Next
        {
            get { return next; }
            set { next = value; }
        }
        public T Data
        {
            get { return data; }
            set { data = value; }
        }
    }

    private Node head;
    private Node Tail;

    //constructor
    public GenericList()
    {
        head = null;
        Tail = null;
    }
    public void AddHead(T t)
    {
        Node n = new Node(t);
        n.Next = head;
        head = n;
    }
    public void AddTail(T t)
    {
        Node n = new Node(t);

        Node current = head;

        while (current.Next != null)
        {
            current = current.Next;
        }
        current.Next = n;

    }

    public IEnumerator<T> GetEnumerator()
    {
        Node current = head;

        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }
}

class Program
{
    static void Main()
    {
        GenericList<object> list = new();

        list.AddHead(1);
        list.AddHead(5);
        list.AddHead(4);
        list.AddHead(3);

        list.AddTail(3);
        foreach (object i in list)
        {
            Console.WriteLine(i);
        }

    }
}