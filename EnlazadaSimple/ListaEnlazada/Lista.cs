using System;
using System.Linq;

namespace ListaEnlazada
{
    internal class Lista
    {
        //Atributos
        Node head;
        Node tail;
        int tamano;

        //Get Set
        public Node Head
        {
            get { return head; }
        }

        public Node Tail 
        {
            get { return tail; }
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
            tamano += 1;
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
                    if(nodo!= null)
                    {
                        var tempNodo = new Node(objeto);
                        tempNodo.Next = nodo.Next;
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

        public bool addAll<T>(Node nodo,T[] objetos) 
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

                    if(nodo != null) 
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

        public bool remove(object objeto)
        {
            try
            {
                if (getFirst().ToString() == objeto.ToString())
                {
                    head = head.Next;
                    tamano--;
                    return true;
                }
                var tempNode = head;
                while(tempNode.Next != null)
                {
                    if(tempNode.Next.Objeto.ToString() == objeto.ToString()) 
                    {
                        tempNode.Next = tempNode.Next.Next;
                        if (tempNode.Next == null)
                        {
                            tail = tempNode;
                        }                       
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
            if(nodo != null)
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

        public bool contains(object objeto)
        {
            try 
            {
                Node currentNode = head; 
                bool respuesta = false;
                while(currentNode != null && respuesta == false) 
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
            for(int i = 0; i < objetos.Length ; i++) 
            {
                if (!contains(objetos[i])) { return false; }
            }
            return true;
        }

        public void clear() 
        {
            head = null;
            tail = null;
            tamano = 0;
        }

        public bool isEmpty() 
        {
            if (head == null) return true; else return false;
        }

        public object getFirst() 
        {
            if(head == null) return null;
            return head.Objeto;
        }

        public object getLast() 
        {
            if(tail == null) return null;
            return tail.Objeto;
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

        public int size() 
        {
            return tamano;
        }

        public Node nodeOf(object objeto) 
        {
            try
            {
                Node currentNode = head, returnNode = null;
                bool checker = false;

                while(currentNode != null && checker == false) 
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

        public object getNext(Node nodo) 
        {
            if (nodo != null && nodo.Next != null) return nodo.Next.Objeto; ;
            return null;
        }

        public object getPrevious(Node nodo)
        {
            var tempNode = head;
            object returnResultado = null;
            bool checker = false;
            if(nodo != null) 
            {
                while (tempNode.Next != null && checker == false)
                {
                    if (nodo.Objeto.ToString() == tempNode.Next.Objeto.ToString())
                    {
                        returnResultado = tempNode.Objeto;
                        checker = true;
                    }
                    tempNode = tempNode.Next;
                }
                return returnResultado;
            }
            return null;
        }

        public bool set(Node node, Object objeto) 
        {
            try 
            {
                if(node != null) 
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

        public bool isEquals(object objeto) 
        {
            return contains(objeto);
        }

        public override string ToString()
        {
            var nodoTemp = head;
            if (!isEmpty()) 
            {
                string resultado = $"{{{nameof(Head)}={Head.Objeto}, {nameof(Tail)}={Tail.Objeto}}}";
                while (nodoTemp != null)
                {
                    resultado += $"{{{nodoTemp.Objeto} ->}}";
                    nodoTemp = nodoTemp.Next;
                }
                return resultado;
            }
            return "";
        }

        public bool retainAll<T>(T[] objetos) 
        {
            try 
            {
                Node tempNode = head;
                while(tempNode != null) 
                {
                    if (Array.IndexOf(objetos,tempNode.Objeto) == -1) 
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

        public Lista clone() 
        {
            try 
            {
                var clone = new Lista(); var currentNode = head;
                while(currentNode != null) 
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

        public Lista subList(Node from,Node to)
        {
            try 
            {
                if(from != null && to != null) 
                {
                    Lista sub = new Lista();
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

        public Lista sort(int a = 0) 
        {
            try 
            {
                object[] elementos = toArray();
                if(a == 0) elementos = elementos.OrderBy(n => n.ToString()).ToArray();
                else elementos = elementos.OrderByDescending(n => n.ToString()).ToArray();
                clear();
                foreach(object elemento in elementos) add(elemento);
                return this;
            }
            catch 
            {
                return null;
            }
        }
    }
}
