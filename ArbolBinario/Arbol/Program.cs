using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arbol
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Prueba de la implementación de arbol binario: ");
            ArbolBinario arbol = new ArbolBinario(1);
            arbol.root.right = new Node("/");
            arbol.root.left = new Node("*");

            arbol.root.right.right = new Node("D");
            arbol.root.right.left = new Node("C");

            arbol.root.left.right = new Node("B");
            arbol.root.left.left = new Node("A");

            arbol.PreOrden(arbol.root);
            Console.WriteLine("");
            arbol.InOrden(arbol.root);
            Console.WriteLine("");
            arbol.PosOrden(arbol.root);
            arbol.WidthOrder(arbol.root);

            Console.WriteLine();
            Console.WriteLine(arbol.Height(arbol.root));
            Console.WriteLine(arbol.NodeCount(arbol.root));
            Console.WriteLine(arbol.isFull());

            Console.WriteLine("-----------------------------");
            arbol.WidthOrder(arbol.root);
            arbol.Add("E");
            arbol.Add("F");
            arbol.Add("G");
            arbol.Add("H");
            arbol.Add("I");
            arbol.Add("FG");
            arbol.Add(null);
            arbol.WidthOrder(arbol.root);
            Console.WriteLine(arbol.isBalanced(arbol.root.right));

            //arbol.BinaryInsert(1,arbol.root);
            //arbol.BinaryInsert(-5, arbol.root);
            //arbol.BinaryInsert(2, arbol.root);
            //arbol.BinaryInsert(-4, arbol.root);
            //arbol.BinaryInsert(70, arbol.root);
            //arbol.BinaryInsert(60, arbol.root);
            //arbol.BinaryInsert(80, arbol.root);
            //arbol.BinaryInsert("socorro",arbol.root);
            //arbol.BinaryInsert(new Node(23),arbol.root);
            //arbol.BinaryInsert(45, arbol.root);
            //arbol.WidthOrder(arbol.root);
            Console.ReadLine();
        }
    }
}
