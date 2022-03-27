using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaCircularDoble
{
    internal class ListaCircularDoble
    {
        Node head;
        int tamano = 0;

        public Node Head 
        {
            get { return head; }
        }

        public ListaCircularDoble() 
        {
            this.head = null;
            this.tamano = 0;
        }

        public ListaCircularDoble(object o)
        {
            add(o);
        }

        public bool add(object Objeto) 
        {
            try 
            {
                var checkBool = false;
                if(Objeto != null) 
                {
                    if (isEmpty()) 
                    {
                        head = new Node(Objeto);
                        head.Next = head;
                        head.Previous = head;
                        tamano++;
                        checkBool = true;
                    }
                    else 
                    {
                        
                        head.Next = new Node(Objeto, head.Next);
                        if(tamano == 1) head.Previous = head.Next;
                        tamano++;
                        checkBool = true;
                    }
                }
                return checkBool;
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
                    if (nodo != null && Objeto != null)
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

        public ListaCircularDoble clone()
        {
            try
            {
                var clone = new ListaCircularDoble(); var currentNode = head;
                do
                {
                    clone.add(currentNode.Objeto);
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
            bool check = true;
            for (int i = 0; i < objetos.Length; i++)
            {
                if (!contains(objetos[i])) { check = false; i = objetos.Length + 1; }
            }
            return check;
        }

        public Node nodeOf(object o)
        {
            try
            {
                Node returnNode = null;
                if (o != null)
                {
                    if (head.Objeto.ToString() == o.ToString())
                    {
                        returnNode = head;
                    }
                    else
                    {
                        var tempNode = head.Next;
                        while (tempNode != head)
                        {
                            if (tempNode.Objeto.ToString() != o.ToString())
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
            return head == null ? null : head.Objeto;
        }

        public object get(Node nodo)
        {
            return nodo != null ? nodo.Objeto : null;
        }

        public object getPrevious(Node nodo) 
        {
            return nodo!=null ? nodo.Previous.Objeto : null;
        }

        public object getNext(Node nodo)
        {
            return (nodo != null) ? nodo.Next.Objeto : null;
        }

        public object getFirst()
        {
            return (head != null) ? head.Objeto : null;
        }

        public bool remove(object o) 
        {
            try 
            {
                var check = false;
                Node currentNode = head.Next;

                if(o != null && !isEmpty()) 
                {
                    if(o.ToString() == head.Objeto.ToString()) 
                    {
                        while(currentNode != head) 
                        {
                            if(currentNode.Next!= head) 
                            {
                                currentNode = currentNode.Next;
                            }
                            else 
                            {
                                head = head.Next;
                                currentNode.Next = head;
                                head.Previous = currentNode;
                                check = true;
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
                            if (currentNode.Next.Objeto.ToString() != o.ToString())
                            {
                                currentNode = currentNode.Next;
                            }
                            else 
                            {
                                currentNode.Next = currentNode.Next.Next;
                                currentNode.Next.Previous = currentNode;
                                tamano--;
                                check = true;
                                currentNode = head;
                            }
                        } 
                        while (currentNode != head);
                    }
                }
                return check;
            }
            catch 
            {
                return false;
            }
        }

        public bool remove(Node nodo) 
        {
            return nodo != null ? remove(nodo.Objeto) : false;
        }

        public bool removeAll<T>(T[] objetos)
        {
            bool returnVar = false;

            if (objetos.Length != 0)
            {
                for (int i = 0; i < objetos.Length; i++)
                {
                    if (objetos[i] != null)
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
                    if (Array.IndexOf(objetos, tempNode.Objeto) == -1)
                    {
                        remove(tempNode);
                    }
                    tempNode = tempNode.Next;
                }
                while (tempNode.Next != Head);

                if (Array.IndexOf(objetos, tempNode.Objeto) == -1) remove(tempNode);
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
                    node.Objeto = objeto;
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

        public ListaCircularDoble subList(Node from, Node to)
        {
            try
            {
                ListaCircularDoble returnList = null;
                if (from != null && to != null)
                {
                    ListaCircularDoble sub = new ListaCircularDoble();
                    while (from != to)
                    {
                        sub.add(from.Objeto);
                        from = from.Next;
                    }
                    sub.add(to.Objeto);
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
                    arrayTemp[i] = currentNode.Objeto;
                    currentNode = currentNode.Next;
                }
            }
            return arrayTemp;
        }

        public ListaCircularDoble sort(int a = 0)
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

        public override string ToString()
        {
            if (!isEmpty())
            {
                var nodoTemp = head.Next;
                string resultado = $"{{{nameof(Head)}={Head.Objeto}}}";
                resultado += $"{{{Head.Objeto} <->}}";
                while (nodoTemp != head)
                {
                    resultado += $"{{{nodoTemp.Objeto} <->}}";
                    nodoTemp = nodoTemp.Next;
                }
                return resultado;
            }
            return "";
        }

        public string ToStringE()
        {
            if (!isEmpty())
            {
                var nodoTemp = head.Previous.Previous;
                string resultado = $"{{Last Elmt Bfre Loop={Head.Previous.Objeto}}}";
                resultado += $"{{{Head.Previous.Objeto} <->}}";
                while (nodoTemp != head.Previous)
                {
                    resultado += $"{{{nodoTemp.Objeto} <->}}";
                    nodoTemp = nodoTemp.Previous;
                }
                return resultado;
            }
            return "";
        }
    }
}
