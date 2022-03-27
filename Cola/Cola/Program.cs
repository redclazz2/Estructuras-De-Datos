using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Implementación de la cola: ");
            Cola cola = new Cola();

            Console.WriteLine("Método Insert: ");
            cola.insert(1);
            cola.insert("Dos");
            cola.insert("Socorro");
            Console.WriteLine(cola.ToString());

            Console.WriteLine("\nMétodo Extract:");
            Console.WriteLine(cola.extract());
            Console.WriteLine(cola.ToString());

            Console.WriteLine("\nMétodo isEmpty:");
            Console.WriteLine("Para una cola NO vacía:");
            Console.WriteLine(cola.isEmpty());
            Console.WriteLine("Para una cola vacía:");
            Cola prueba = new Cola();
            Console.WriteLine(prueba.isEmpty());

            Console.WriteLine("\nMétodo Size: ");
            Console.WriteLine(cola.size());
            cola.insert("H");
            cola.insert("O");
            cola.insert("L");
            cola.insert("A");
            Console.WriteLine(cola.size());

            Console.WriteLine("\nMétodo Search: ");
            Console.WriteLine("Elemento contenido: ");
            Console.WriteLine(cola.search("L"));
            Console.WriteLine("Elemento No contenido: ");
            Console.WriteLine(cola.search("!"));

            Console.WriteLine("Método sort: ");
            Console.WriteLine(cola.ToString());
            cola.sort();
            Console.WriteLine(cola.ToString());

            Console.WriteLine("\nMétodo toString: ");
            Console.WriteLine(cola.ToString());

            Console.WriteLine("\nMétodo Reverse: ");
            cola.reverse();
            Console.WriteLine(cola.ToString());
            
            Console.ReadLine();
        }
    }
}
