using System;
using System.IO;

namespace LinkedList
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //Read file path through command line
            Console.Write("Input file path: ");
            try
            {
                string path = Path.GetFullPath(Console.ReadLine());
                if (path.Length == 0)
                {
                    Console.WriteLine(" path not found");
                }
                else
                {
                    FileReader fileReader = new FileReader();
                    fileReader.run(@path);
                }
            }catch(FileNotFoundException exception)
            {
                Console.WriteLine("File is not found");
                Console.WriteLine(exception);
            }
        }
    }

    class FileReader
    {
        private LinkedList linkedList = new LinkedList();
        //It gets each line from the input file, and it insert or delete the value
        private void handleInput(string line, LinkedList linkedList)
        {
            //function is the first character in the line which is 'i' or 'd'
            char function = line[0];
            //data is the integer value in the line
            int data = Int16.Parse(line.Substring(2));

            if (function == 'i')
            {
                linkedList.newNode(data);
            }
            else if (function == 'd')
            {
                linkedList.deleteNode(data);
            }
            else
            {
                System.Console.WriteLine("Try to put i or d");
            }
        }
        public void run(string fileName)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(fileName);

            string line;
            //line is each line in the input file
            while ((line = file.ReadLine()) != null)
            {
                handleInput(line, linkedList);
            }

            file.Close();

            linkedList.printData();
        }
        
    }
   
    class Node
    {
        private int? data;
        private Node next = null;
        //data: value
        //next: next linked node
        public Node(int data, Node next)
        {
            this.data = data;
            this.next = next;
        }
        public int? getData()
        {
            return data;
        }
        public Node getNext()
        {
            return next;
        }
        public void setNext(Node nextNode)
        {
            next = nextNode;
        }
    }

    class LinkedList
    {
        //first node in LinkedList
        private Node head;
        //Insert new node with new data
        public void newNode(int data)
        {
            // If first node is null
            if (head is null)
            {
                head = new Node(data, null);
            }
            // Else add new node to end
            else
            {
                Node current = head;
                // At end if current.next is null
                while (current.getNext() != null)
                {
                    current = current.getNext();
                }
                current.setNext(new Node(data, null));
            }
        }

        public void deleteNode(int data)
        {
            Node current = head;
            Node previous = head;
            //if the first node is 
            if (current.getData() == data)
            {
                head = current.getNext();
            } 
            else
            {
                //At end if the current data is the data we are looking for
                while (current.getData() != data)
                {
                    previous = current;
                    current = current.getNext();
                    if(current == null)
                    {
                        break;
                    }else if(current.getData() == data) {
                        previous.setNext(current.getNext());
                        break;
                    }
                }
            }
        }
        public void printData()
        {
            int i = 1;
            Node current = head;

            while (current != null)
            {
                System.Console.WriteLine("Node" + i + ":" + current.getData());
                current = current.getNext();
                i++;
            }
        }
    }
}
