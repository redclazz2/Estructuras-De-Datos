using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaCircularSimple
{
    internal class Node
    {
        private object elemento;
        private Node next;

        public object Elemento 
        {
            get { return elemento; }
            set { elemento = value; }
        }

        public Node Next 
        {
            get { return next; }
            set { next = value; }
        }

        public Node(object dato, Node next) 
        {
            this.elemento = dato;
            this.next = next;
        }

        public Node(object objeto) 
        {
            this.elemento=objeto;
            this.next=null;
        }
    }
}
