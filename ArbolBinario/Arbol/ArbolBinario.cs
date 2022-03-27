using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Cola;

namespace Arbol
{
    internal class ArbolBinario
    {
        int tamano = 0;
        public Node root;

        public ArbolBinario() { this.root = null; }

        public ArbolBinario(object objeto) 
        {
           root = new Node(objeto);
        }

        public bool isEmpty()
        {
            return (root == null) ? true : false;
        }

        public void PreOrden(Node node)
        {
            Console.Write(node.Objeto);
            if (node.left != null) PreOrden(node.left);
            if (node.right != null) PreOrden(node.right);
        }

        public void InOrden(Node node)
        {
            if (node.left != null) InOrden(node.left);
            Console.Write(node.Objeto);
            if (node.right != null) InOrden(node.right);
        }

        public void PosOrden(Node node)
        {
            if (node.left != null) PosOrden(node.left);
            if (node.right != null) PosOrden(node.right);
            Console.Write(node.Objeto);
        }

        //Existen dos versiones de WidthOrder en esta implementación de arbol, la primera es una forma recursiva,
        //La segunda es iterativa por medio de una cola.

        public void WidthOrder(Node node, Node lastNode = null)
        {
            if (lastNode == null) Console.Write(node.Objeto);
            if (node.left != null) Console.Write(node.left.Objeto);
            if (node.right != null) Console.Write(node.right.Objeto);

            if (lastNode != null)
            {
                if (lastNode.right.left != null && lastNode.right.right != null)
                {
                    Console.Write(lastNode.right.left.Objeto);
                    Console.Write(lastNode.right.right.Objeto);
                    WidthOrder(node.left, node);
                }
            }
            else
            {
                WidthOrder(node.left, node);
            }
        }

        public void WidthOrder(Node node)
        {
            Cola.Cola tempCola = new Cola.Cola();
            tempCola.insert(node);
            Console.WriteLine();
            while (!tempCola.isEmpty())
            {
                Node tempNode = (Node)tempCola.extract();
                Console.Write(tempNode.Objeto + " ");
                if (tempNode.left != null) tempCola.insert(tempNode.left);
                if (tempNode.right != null) tempCola.insert(tempNode.right);
            }
        }

        public int Height(Node nodo)
        {
            int altural = 0, alturar = 0;
            if (isEmpty())
            {
                return 0;
            }
            else
            {
                if (nodo.left != null) altural = Height(nodo.left);
                if (nodo.right != null) alturar = Height(nodo.right);
                if (altural > alturar)
                {
                    return altural + 1;
                }
                else
                {
                    return alturar + 1;
                }
            }
        }

        public int NodeCount(Node node)
        {
            int num = 0;
            if (!isEmpty()) 
            {
                Cola.Cola tempCola = new Cola.Cola();
                tempCola.insert(node);
                while (!tempCola.isEmpty())
                {
                    Node tempNode = (Node)tempCola.extract();
                    num++;
                    if (tempNode.left != null) tempCola.insert(tempNode.left);
                    if (tempNode.right != null) tempCola.insert(tempNode.right);
                }
            }
            return num;
        }

        public bool isFull() 
        {
            return (NodeCount(root) % 2 != 0) ? true : false;
        }

        public bool Add(object objeto) 
        {
            bool check = false;
            if(objeto!= null)
            if (isEmpty()) 
            {
                root = new Node(objeto);
                check = true;
            }
            else 
            {
                Cola.Cola tempCola = new Cola.Cola();
                tempCola.insert(root);
                while (check == false)
                {
                    Node tempNode = (Node)tempCola.extract();
                    if (tempNode.left != null && check == false)
                    { 
                        tempCola.insert(tempNode.left);
                        if (tempNode.right != null && check == false)
                        {
                            tempCola.insert(tempNode.right);
                        }
                        else
                        {
                            tempNode.right = new Node(objeto);
                            tempCola.clear();
                            check = true;
                        }
                    }
                    else
                    { 
                        tempNode.left = new Node(objeto);
                        tempCola.clear();
                        check = true;
                    }
                }
            }
            return check;
        }

        public int size() 
        {
            return tamano;
        }

        public bool BinaryInsert(object objeto, Node searchNode, Node addNode = null) 
        {
            bool check = false;
            if (isEmpty()) 
            {
                root = new Node(objeto);
            }
            else 
            {
                if (objeto != null)
                {
                    Node tempNode = null;
                    if (addNode == null)
                    {
                        tempNode = new Node(objeto);
                    }
                    else
                    {
                        tempNode = addNode;
                    }
                    var compar = tempNode.ID.CompareTo(searchNode.ID);
                    if (compar != 0)
                    {
                        if (compar > 0) 
                        {
                            if (searchNode.left == null) searchNode.left = tempNode;
                            else BinaryInsert(objeto, searchNode.left, tempNode);
                            check = true;
                        }
                        else 
                        {
                            if (searchNode.right == null) searchNode.right = tempNode;
                            else BinaryInsert(objeto, searchNode.right, tempNode);
                            check = true;
                        }
                    }
                }
            }
            return check;
        }

        public bool isBalanced(Node nodo)
        {
            int altural = 0, alturar = 0;
            bool returnvar=false;
            if(!isEmpty())
            {
                if (nodo != null) 
                {
                    if (nodo.left != null) altural += Height(nodo.left);
                    if (nodo.right != null) alturar += Height(nodo.right);
                }
            }
            var sum = altural - alturar;
            if (sum>= -1 && sum <= 1) 
            {
                returnvar = true;
            }
            return returnvar;
        }
    }
}
