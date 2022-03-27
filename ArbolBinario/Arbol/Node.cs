using System;
using System.Text;
namespace Arbol
{
    internal class Node
    {
        private object objeto;
        private string id;
        public Node left;
        public Node right;

        public string ID 
        {
            get { return id; }
            set { id = value; }
        }

        public Node(object objeto) 
        {
            this.objeto = objeto;
            this.right = null;
            this.left = null;
            this.id = getId();
        }

        public Node(object objeto, Node right, Node left) 
        {
            this.objeto = objeto;
            this.right = right;
            this.left = left;
            this.id = getId();
        }

        public object Objeto 
        {
            get { return objeto; }
        }

        public string getId() 
        {
            byte[] data = Encoding.Default.GetBytes(objeto.ToString());
            string key = BitConverter.ToString(data);
            return key.Replace("-", "");
        }
    }
}
