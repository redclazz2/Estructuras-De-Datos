using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pila
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pila pilaPrueba = new Pila();

            Console.WriteLine("Método Peek cuando está vacía:" + pilaPrueba.size());
            Console.WriteLine(pilaPrueba.peek());

            Console.WriteLine("\nMétodo Push:");
            Console.WriteLine(pilaPrueba.push(2));

            Console.WriteLine("\nMétodo Peek cuando tiene un elemento:" + pilaPrueba.size());
            Console.WriteLine(pilaPrueba.peek());

            Console.WriteLine("\nMétodo Push para un segundo elemento:");
            Console.WriteLine(pilaPrueba.push(3));

            Console.WriteLine("\nMétodo Peek cuando se agrega un elemento:");
            Console.WriteLine(pilaPrueba.peek());

            Console.WriteLine("\nMétodo Pop:");
            Console.WriteLine(pilaPrueba.pop());

            Console.WriteLine("\nMétodo Peek después del pop:");
            Console.WriteLine(pilaPrueba.peek());

            Console.WriteLine("\nMétodo Pop para dejar la lista vacía:");
            Console.WriteLine("Tamaño antes del pop final: " + pilaPrueba.size());
            Console.WriteLine(pilaPrueba.pop());
            Console.WriteLine("Tamaño después del pop final: " + pilaPrueba.size());

            Console.WriteLine(".");
            Console.ReadLine();
        }
    }
}
