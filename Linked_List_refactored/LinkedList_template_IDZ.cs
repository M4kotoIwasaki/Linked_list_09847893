namespace LinkedList_template_IDZ
{
    public class Node
    {
        private int data;
        private Node next;

        public Node(int data, Node next)
        {
            this.data = data;
            this.next = next;
        }

        public int Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public Node Next
        {
            get { return this.next; }
            set { this.next = value; }
        }
    }

    public class LinkedList
    {
        private Node head;

        public LinkedList()
        {
            this.head = null;
        }

        public bool Empty
        { get { return this.head == null; } }

        public void Clear()
        {
            Node current = this.head;

            while (current != null)
            {
                Node temp = current;
                current = current.Next;
                temp.Next = null;
            }

            this.head = null;
        }


        public void AddEnd(int data)
        {
            Node newNode = new Node(data, null);

            if (this.head == null)
            {
                this.head = newNode;
            }
            else
            {
                Node current = this.head;

                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = newNode;
            }
        }

        public bool Contains(int data)
        {
            Node current = this.head;

            while (current != null)
            {
                if (current.Data == data)
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }
        public void Print()
        {
            Node current = this.head;

            while (current != null)
            {
                Console.Write(current.Data);

                if (current.Next != null)
                {
                    Console.Write(" -> ");
                }

                current = current.Next;
            }

            Console.WriteLine();
        }

        public void SearchByValue(int value)
        {
            Node current = this.head;
            int index = 0;
            bool found = false;

            while (current != null)
            {
                if (current.Data == value)
                {
                    Console.WriteLine($"Элемент {value} найден на позиции: {index}.");
                    found = true;
                }

                current = current.Next;
                index++;
            }

            if (!found)
            {
                Console.WriteLine($"Ничего не найдено.");
            }
        }

        public void DeletingOccurrences(int value)
        {
            Node current = this.head;
            Node previous = null;

            while (current != null)
            {
                if (current.Data == value)
                {
                    Node temp = current;

                    if (previous == null)
                    {
                        this.head = current.Next;
                    }
                    else
                    {
                        previous.Next = current.Next;
                    }

                    current = current.Next;
                    temp.Next = null;
                }
                else
                {
                    previous = current;
                    current = current.Next;
                }
            }
        }

        public void DeletingBeforeOccurrence(int value)
        {
            if (head == null || head.Next == null)
            {
                return;
            }

            while (head != null && head.Next != null && head.Next.Data == value)
            {
                Node temp = head;
                head = head.Next;
                temp.Next = null;
            }

            Node previous = null;
            Node current = head;

            while (current != null && current.Next != null)
            {
                if (current.Next.Data == value)
                {
                    Node temp = current;

                    if (previous != null)
                    {
                        previous.Next = current.Next;
                    }
                    else
                    {
                        head = current.Next;
                    }

                    current = current.Next;
                    temp.Next = null;
                }
                else
                {
                    previous = current;
                    current = current.Next;
                }
            }
        }

        public LinkedList Difference(LinkedList secondList)
        {
            LinkedList result = new LinkedList();
            Node current = this.head;

            while (current != null)
            {
                if (!secondList.Contains(current.Data))
                {
                    result.AddEnd(current.Data);
                }

                current = current.Next;
            }
            return result;
        }
        
        public LinkedList Dividers(LinkedList selectedList)
        {
            LinkedList result = new LinkedList();
            int value;
            Node current = this.head;

            //value = current.Data;
            while (current != null)
            {
                value = current.Data;
                for (int i = 1; i <= value ; i++)
                {
                    
                    if (value % i == 0)
                    {
                        result.AddEnd(i);
                    }
                }
                current = current.Next;
            }
            return result;
        }
        /*public LinkedList Dividers(LinkedList selectedList)
        {
            LinkedList result = new LinkedList(); 
            Node current = this.head;

            while (current != null)
            {
                int counter = 2;
                
                for (int i = 2; i <= current.Data / 2; i++)
                {
                    if (current.Data % i == 0)
                    {
                        counter++;
                    }
                    
                    if (counter >= 4)
                    {
                        result.AddEnd(current.Data);
                        break;
                    }
                }
                current = current.Next;
            }
            return result;
        }*/
    }
}