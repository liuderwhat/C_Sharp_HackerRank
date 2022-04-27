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
    private Node tail;

    //constructor
    public GenericList()
    {
        head = null;
        tail = null;
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
        n.Next = head;
    }

    public void insertNodeAtPosition(T data, int position)
    {
        Node n = new Node(data);
        Node current = head;

        if (position == 0 || current == null)
        {
            n.Next = head;
            head = n;
        }
        else
        {
            int counter = 0;
            while (true)
            {
                if (counter + 1 == position)
                {
                    n.Next = current.Next;
                    current.Next = n;
                    break;
                }
                counter++;
                current = current.Next;
            }
        }
    }

    public void Delete(int position)
    {
        Node current = head;
        Node prev = head;

        int counter = 0;

        if (current != null)
        {
            while (counter != position)
            {
                counter++;
                prev = current;
                current = current.Next;
            }
            prev.Next = current.Next;
        }
    }

    public void ReverseList()
    {
        Node tail = null;
        Node t = null;

        while (head != null)
        {

            t = head.Next;
            head.Next = tail;
            tail = head;
            head = t;
        }
        head = tail;
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
    public bool CheckCycle()
    {
        Node slow = head;
        Node fast = head;
        //Console.WriteLine(fast.Data);
        while (fast != null && fast.Next != null)
        {
            fast = (fast.Next).Next;
            slow = slow.Next;

            if (fast == slow && fast != null)
            {
                Console.WriteLine("Cycle Detection");
                return true;
            }
        }
        return false;
        //result:
        //        Console.WriteLine("Cycle Detection");
    }

}

class Program
{
    static void Main()
    {
        GenericList<object> list = new();

        list.AddHead(1);
        list.AddHead(2);
        list.AddHead(3);
        list.AddHead(4);
        list.AddTail(3);
        //list.insertNodeAtPosition(87, 1);
        //list.Delete(2);
        //list.ReverseList();
        if (!list.CheckCycle())
        {
            foreach (object i in list)
            {
                Console.WriteLine(i);
            }
        }



    }
}