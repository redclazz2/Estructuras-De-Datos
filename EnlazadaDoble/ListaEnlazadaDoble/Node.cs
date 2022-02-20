using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaEnlazadaDoble
{
    internal class Node
    {
        private object objeto;
        private Node next;
        private Node previous;

        public Node(object objeto)
        {
            this.objeto = objeto;
            next = null;
            previous = null;
        }

        public Node(object objeto, Node next)
        {
            this.objeto = objeto;
            this.next = next;
            previous = next.previous;
        }

        public object Objeto
        {
            get { return objeto; }
            set { objeto = value; }
        }

        public Node Next
        {
            get { return next; }
            set { next = value; }
        }

        public Node Previous
        {
            get { return previous; }
            set { previous = value; }
        }
    }
}
