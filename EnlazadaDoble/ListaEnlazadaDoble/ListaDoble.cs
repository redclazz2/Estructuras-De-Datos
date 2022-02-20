using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaEnlazadaDoble
{
    internal class ListaDoble
    {
        //Atributos

        Node head;
        Node tail;
        int tamano = 0;

        //Get Set
        public Node Head
        {
            get { return head; }
        }
        public Node Tail
        {
            get { return tail; }
        }

        public ListaDoble()
        {
            head = null;
            tail = null;
        }

        public ListaDoble(object objeto)
        {
            head = new Node(objeto);
            tail = head;
            tamano++;
        }

        //Métodos
        public bool add(object objeto)
        {
            try
            {
                if (isEmpty())
                {
                    head = new Node(objeto);
                    tail = head;
                    tamano++;
                    return true;
                }
                else
                {
                    tail.Next = new Node(objeto);
                    tail.Next.Previous = tail;
                    tail = tail.Next;
                    tamano++;
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool add(Node nodo, Object objeto)
        {
            try
            {
                if (isEmpty())
                {
                    add(objeto);
                    tamano++;
                    return true;
                }
                else
                {
                    if (nodo != null)
                    {
                        var tempNodo = new Node(objeto);
                        tempNodo.Next = nodo.Next;
                        tempNodo.Previous = nodo;
                        if(nodo.Next != null)
                        nodo.Next.Previous = tempNodo;
                        nodo.Next = tempNodo;
                        if (tempNodo.Next == null) tail = tempNodo;
                        tamano++;
                        return true;
                    }

                    return false;
                }
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
                if (objetos.Length != 0)
                {
                    for (int i = 0; i < objetos.Length; i++)
                    {
                        add(objetos[i]);
                    }
                    return true;
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

        public bool addAll<T>(Node nodo, T[] objetos)
        {
            try
            {
                Node currentSearchNode = head;
                if (objetos.Length != 0)
                {
                    if (isEmpty())
                    {
                        for (int i = 0; i < objetos.Length; i++)
                        {
                            add(objetos[i]); tamano++;
                        }
                        return true;
                    }

                    if (nodo != null)
                    {
                        var lastNode = nodo;
                        for (int w = 0; w < objetos.Length; w++)
                        {
                            add(lastNode, objetos[w]);
                            lastNode = lastNode.Next;
                        }
                        return true;
                    }
                    return false;
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

        public bool addFirst(object objeto)
        {
            try
            {
                if (isEmpty()) { add(objeto); tamano++; return true; }

                var a = head;
                head = new Node(objeto);
                head.Next = a;
                a.Previous = head;
                tamano++;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool addLast(object objeto)
        {
            return add(objeto);
        }

        public ListaDoble clone()
        {
            try
            {
                var clone = new ListaDoble(); var currentNode = head;
                while (currentNode != null)
                {
                    clone.add(currentNode.Objeto);
                    currentNode = currentNode.Next;
                }
                return clone;
            }
            catch
            {
                return null;
            }
        }

        public void clear()
        {
            head = null;
            tail = null;
            tamano = 0;
        }

        public bool contains(object objeto)
        {
            try
            {
                Node currentNode = head;
                bool respuesta = false;
                while (currentNode != null && respuesta == false)
                {
                    if (currentNode.Objeto.ToString() == objeto.ToString())
                    {
                        respuesta = true;
                    }
                    currentNode = currentNode.Next;
                }
                return respuesta;
            }
            catch
            {
                return false;
            }
        }

        public bool containsAll<T>(T[] objetos)
        {
            bool checker = true;
            for (int i = 0; i < objetos.Length; i++)
            {
                if (!contains(objetos[i])) { checker = false; i = objetos.Length; }
            }
            return checker;
        }

        public Node nodeOf(object objeto)
        {
            try
            {
                Node currentNode = head, returnNode = null;
                bool checker = false;

                while (currentNode != null && checker == false)
                {
                    if (currentNode.Objeto.ToString() == objeto.ToString())
                    {
                        returnNode = currentNode; checker = true;
                    }
                    else
                    {
                        currentNode = currentNode.Next;
                    }
                }
                return returnNode;
            }
            catch
            {
                return null;
            }
        }

        public bool isEquals(object objeto)
        {
            return contains(objeto);
        }

        public bool isEmpty()
        {
            if (head == null) return true; else return false;
        }

        public object get()
        {
            return getFirst();
        }

        public object get(Node nodo)
        {
            if(nodo != null)
            return nodo.Objeto;
            return null;
        }

        public object getPrevious(Node nodo)
        {
            if(nodo != null && nodo.Previous != null)
            return nodo.Previous.Objeto;
            return null;
        }

        public object getNext(Node nodo)
        {
            if (nodo != null && nodo.Next != null) return nodo.Next.Objeto; ;
            return null;
        }

        public object getFirst()
        {
            if (head == null) return null;
            return head.Objeto;
        }

        public object getLast()
        {
            if (tail == null) return null;
            return tail.Objeto;
        }

        public bool remove(object objeto)
        {
            try
            {
                if (getFirst().ToString() == objeto.ToString())
                {
                    head = head.Next;
                    if(head!=null)
                    head.Previous = null;
                    tamano--;
                    return true;
                }

                var tempNode = head;
                while (tempNode.Next != null)
                {
                    if (tempNode.Next.Objeto.ToString() == objeto.ToString())
                    {
                        tempNode.Next = tempNode.Next.Next;
                        if (tempNode.Next != null) {tempNode.Next.Previous = tempNode;} else { tail = tempNode; }
                        tamano--;
                        return true;
                    }
                    tempNode = tempNode.Next;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool remove(Node nodo)
        {
            if (nodo != null)
            return remove(nodo.Objeto);
            return false;
        }

        public bool removeAll<T>(T[] objetos)
        {
            try
            {
                for (int i = 0; i < objetos.Length; i++)
                {
                    if (objetos[i] != null)
                    {
                        remove(objetos[i]);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool retainAll<T>(T[] objetos)
        {
            try
            {
                Node tempNode = head;
                while (tempNode != null)
                {
                    if (Array.IndexOf(objetos, tempNode.Objeto) == -1)
                    {
                        remove(tempNode);
                    }
                    tempNode = tempNode.Next;
                }
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

        public ListaDoble subList(Node from, Node to)
        {
            try
            {
                if (from != null && to != null)
                {
                    ListaDoble sub = new ListaDoble();
                    while (from != to)
                    {
                        sub.add(from.Objeto);
                        from = from.Next;
                    }
                    sub.add(to.Objeto);
                    return sub;
                }
                return null;
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
                for (int i = 0; i < size(); i++)
                {
                    arrayTemp[i] = currentNode.Objeto;
                    currentNode = currentNode.Next;
                }
            }
            return arrayTemp;
        }

        public ListaDoble sort(int a = 0)
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
            var nodoTemp = head;
            if (!isEmpty())
            {
                string resultado = $"{{{nameof(Head)}={Head.Objeto}, {nameof(Tail)}={Tail.Objeto}}}";
                while (nodoTemp != null)
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
            var nodoTemp = tail;
            if (!isEmpty())
            {
                string resultado = $"{{{nameof(Tail)}={Tail.Objeto}, {nameof(Head)}={Head.Objeto}}}";
                while (nodoTemp != null)
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
