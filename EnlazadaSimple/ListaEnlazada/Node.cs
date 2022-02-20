using System.Runtime.InteropServices;
using System.Xml;

namespace ListaEnlazada
{
    public class Node
    {
        private object objeto;
        private Node next;

        public Node(object objeto)
        {
            this.objeto = objeto;
            next = null;
        }

        public Node(object objeto, Node next)
        {
            this.objeto = objeto;
            this.next = next;
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
        
    }
}