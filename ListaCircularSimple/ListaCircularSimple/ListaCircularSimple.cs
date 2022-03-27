using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaCircularSimple
{
    internal class ListaCircularSimple
    {
        Node head;
        int tamano = 0;

        public Node Head 
        {
            get { return head; }
        }

        public ListaCircularSimple() 
        {
            this.head = null;
            this.tamano = 0;
        }

        public ListaCircularSimple(object o)
        {
             add(o);
        }

        //Métodos
        public bool add(object o) 
        {
            try 
            {
                if(o != null) 
                {
                    if (isEmpty())
                    {
                        head = new Node(o);
                        head.Next = head;
                        tamano++;
                        return true;
                    }
                    else 
                    {
                        head.Next = new Node(o, head.Next);
                        tamano++;
                        return true;
                    }
                }
                else 
                {
                    return false;
                }

            }
            catch 
            {
                return false;
            }
        }

        public bool add(Node nodo, object Objeto) 
        {
            try 
            {
                bool check = false;
                if (isEmpty()) 
                {
                    add(Objeto);
                    check = true;
                }
                else 
                {
                    if(nodo != null && Objeto != null) 
                    {
                        nodo.Next = new Node(Objeto, nodo.Next);
                        tamano++;
                        check = true;
                    }
                }
                return check;
            }
            catch 
            {
                return false;
            }
        }

        public bool addAll<T>(T[] objetos) 
        {
            try
            {
                bool check = false;
                if (objetos != null && objetos.Length != 0)
                {
                    for (int i = 0; i < objetos.Length; i++)
                    {
                        add(objetos[i]);
                    }
                    check = true;
                }
                else check = false;
                return check;
            }
            catch 
            {
                return false;
            }
        }

        public bool addAll<T>(Node nodo, T[] objetos) 
        {
            try 
            {
                bool check = false;
                if (objetos.Length != 0 && nodo != null)
                {
                    if (isEmpty())
                    {
                        for (int i = 0; i < objetos.Length; i++)
                        {
                            add(objetos[i]);
                        }
                        check = true;
                    }
                    else
                    {
                        for (int w = 0; w < objetos.Length; w++)
                        {
                            add(nodo, objetos[w]);
                        }
                        check = true;
                    }
                }
                return check;
            }
            catch 
            {
                return false;
            }
        }

        public void clear() 
        {
            head = null;
            tamano = 0;
        }

        public ListaCircularSimple clone() 
        {
            try 
            {
                var clone = new ListaCircularSimple(); var currentNode = head;
                do
                {
                    clone.add(currentNode.Elemento);
                    currentNode = currentNode.Next;
                } while (currentNode != head);
                return clone;
            }
            catch 
            {
                return null;
            }
        }

        public bool contains(object Objeto) 
        {
            return nodeOf(Objeto) == null ? false : true; 
        }

        public bool containsAll<T>(T[] objetos) 
        {
            for (int i = 0; i < objetos.Length; i++)
            {
                if (!contains(objetos[i])) { return false; }
            }
            return true;
        }

        public Node nodeOf(object o) 
        {
            try 
            {
                Node returnNode = null;
                if (o != null)
                {
                    if (head.Elemento.ToString() == o.ToString())
                    {
                        returnNode = head;
                    }
                    else
                    {
                        var tempNode = head.Next;
                        while (tempNode != head)
                        {
                            if (tempNode.Elemento.ToString() != o.ToString())
                            {
                                tempNode = tempNode.Next;
                            }
                            else
                            {
                                returnNode = tempNode;
                                tempNode = head;
                            }
                        }
                    }
                }
                return returnNode;
            }
            catch 
            {
                return null;
            }
        }

        public bool isEmpty() 
        {
            return head == null;
        }

        public object get() 
        {
            return head == null ? null : head.Elemento;
        }

        public object get(Node nodo) 
        {
            return nodo != null ? nodo.Elemento : null;
        }

        public object getPrevious(Node nodo) 
        {
            try 
            {
                object returnResultado = null;
                var tempNode = head;
                bool checker = false;
                if(nodo != null) 
                {
                    while(tempNode.Next != head && checker == false) 
                    { 
                        if(nodo.Elemento.ToString() == tempNode.Next.Elemento.ToString()) 
                        {
                            returnResultado = tempNode.Elemento;
                            checker = true;
                        }
                        tempNode = tempNode.Next;
                    }
                }
                return returnResultado;
            }
            catch 
            {
                return null;
            }
        }

        public object getNext(Node nodo) 
        {
            return (nodo != null) ? nodo.Next.Elemento : null;
        }

        public object getFirst() 
        {
            return (head != null) ? head.Elemento : null;
        }

        public bool remove(object o) 
        {
            bool returnBoolean = false;
            Node currentNode = head.Next;

            if (o != null && !isEmpty()) 
            {
                if(o.ToString() == head.Elemento.ToString()) 
                {
                   while(currentNode != head)
                   {
                        if(currentNode.Next != head) 
                        {
                            currentNode = currentNode.Next;
                        }
                        else 
                        {
                            head = head.Next;
                            currentNode.Next = head;
                            returnBoolean = true;
                            currentNode = head;
                            tamano--;
                        } 
                   }
                }
                else 
                {
                    currentNode = head;
                    do
                    {
                        if (currentNode.Next.Elemento.ToString() != o.ToString())
                        {
                            currentNode = currentNode.Next;
                        }
                        else
                        {
                            currentNode.Next = currentNode.Next.Next;
                            returnBoolean = true;
                            tamano--;
                            currentNode = head;
                        }
                    }
                    while (currentNode != head);
                }
            }

            return returnBoolean;
        }

        public bool remove(Node nodo) 
        {
            return (nodo != null) ? remove(nodo.Elemento) : false;
        }

        public bool removeAll<T>(T[] objetos) 
        {
            bool returnVar = false;

            if(objetos.Length != 0) 
            {
                for(int i = 0; i < objetos.Length; i++) 
                {
                    if(objetos[i] != null) 
                    {
                        remove(objetos[i]);
                    }
                }
                returnVar = true;
            }

            return returnVar;
        }

        public bool retainAll<T>(T[] objetos)
        {
            try
            {
                Node tempNode = head;
                do
                {
                    if (Array.IndexOf(objetos, tempNode.Elemento) == -1)
                    {
                        remove(tempNode);
                    }
                    tempNode = tempNode.Next;
                }
                while(tempNode.Next != Head);

                if(Array.IndexOf(objetos, tempNode.Elemento) == -1) remove(tempNode);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool set(Node node, Object objeto)
        {
            try
            {
                if (node != null)
                {
                    node.Elemento = objeto;
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public int size() 
        {
            return tamano;
        }

        public ListaCircularSimple subList(Node from, Node to)
        {
            try
            {
                ListaCircularSimple returnList = null;
                if (from != null && to != null)
                {
                    ListaCircularSimple sub = new ListaCircularSimple();
                    while (from != to)
                    {
                        sub.add(from.Elemento);
                        from = from.Next;
                    }
                    sub.add(to.Elemento);
                    returnList = sub;
                }
                return returnList;
            }
            catch
            {
                return null;
            }
        }

        public object[] toArray()
        {
            var arrayTemp = new object[size()];
            var currentNode = head;
            if (!isEmpty())
            {
                for (int i = 0; i < arrayTemp.Length; i++)
                {
                    arrayTemp[i] = currentNode.Elemento;
                    currentNode = currentNode.Next;
                }
            }
            return arrayTemp;
        }

        public override string ToString()
        {
            var nodoTemp = head.Next;
            if (!isEmpty())
            {
                string resultado = $"{{{nameof(Head)}={Head.Elemento}}}";
                resultado += $"{{{Head.Elemento} ->}}";
                while (nodoTemp != head)
                {
                    resultado += $"{{{nodoTemp.Elemento} ->}}";
                    nodoTemp = nodoTemp.Next;
                }
                return resultado;
            }
            return "";
        }

        public ListaCircularSimple sort(int a = 0)
        {
            try
            {
                object[] elementos = toArray();
                if (a == 0) elementos = elementos.OrderBy(n => n.ToString()).ToArray();
                else elementos = elementos.OrderByDescending(n => n.ToString()).ToArray();
                clear();
                foreach (object elemento in elementos) add(elemento);
                return this;
            }
            catch
            {
                return null;
            }
        }

        public void imprimir()
        {
            if (!isEmpty())
            {
                var tempNode = head.Next;
                Console.WriteLine(head.Elemento.ToString());
                while (tempNode != head)
                {
                    Console.WriteLine(tempNode.Elemento.ToString());
                    tempNode = tempNode.Next;
                }
            }
            else
            {
                Console.WriteLine("Empty");
            }

        }

    }
}
