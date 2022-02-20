using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaEnlazada
{
    internal class Lista
    {
        Node head;
        Node tail;

        public Node Head
        {
            get { return head; }
        }

        public Lista() 
        {
            head = null;
            tail = null;
        }   

        public Lista(object objeto) 
        {
            head = new Node(objeto);
            tail = head;
        }

        public bool add(object objeto) 
        {
            try 
            {
                if (isEmpty())
                {
                    head = new Node(objeto);
                    tail = head;
                    return true;
                }
                else
                {
                    tail.Next = new Node(objeto);
                    tail = tail.Next;
                    return true;
                }
            }
            catch 
            {
                return false;
            }
        }

        public bool addFirst(object objeto) 
        {
            try 
            {
                var a = head;
                head = new Node(objeto);
                head.Next = a;
                a = null;
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public bool addLast(object objeto) 
        {
            try 
            {
                tail.Next = new Node(objeto);
                tail = tail.Next;
                return true;
            }
            catch 
            {
                return false;
            }
        }
/*
        public bool remove(object objeto)
        {
            try 
            {
                var currentNode = head; 
                var lastNode = head; 
                var nextNode = currentNode.Next;
                for (int i = 0; i < size()-1; i++)
                {
                    if (Object.Equals(currentNode.Objeto,objeto))
                    {
                        lastNode.Next = nextNode;
                        currentNode.Next = null;
                        return true;
                    }
                    else 
                    {
                        lastNode = currentNode;
                        currentNode = currentNode.Next;
                        nextNode = currentNode.Next;
                    }
                }
                return false;
               
            }
            catch
            {
                return false;
            }
        }
*/
        public void clear() 
        {
            head = null;
            tail = null;
        }

        public bool isEmpty() 
        {
            if (head == null) return true; else return false;
        }

        public object getFirst() 
        {
            return head.Objeto;
        }

        public object getLast() 
        {
            return tail.Objeto;
        }

        public object[] toArray()
        {
            var arrayTemp = new object[size()]; 
            var currentNode = head;

            for(int i = 0; i < size(); i++) 
            {
                arrayTemp[i] = currentNode.Objeto;
                currentNode = currentNode.Next;
            }

            return arrayTemp;
        }

        public int size() 
        {
            int contador = 0; Node currentNode = head;
            while (true) 
            {
                contador++;
                if (currentNode.Next != null) currentNode = currentNode.Next; else break;               
            }

            return contador;
        }

    }
}
