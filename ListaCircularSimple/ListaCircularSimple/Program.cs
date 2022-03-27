using System;

namespace ListaCircularSimple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListaCircularSimple listaCircular = new ListaCircularSimple();

            Console.WriteLine("Método Add: ");
            for (int i = 0; i < 5; i++)
            {
                listaCircular.add(i);
            }
            Console.WriteLine(listaCircular);

            Console.WriteLine("\nMétodo Add con un nodo específico: ");
            listaCircular.add(listaCircular.nodeOf(1), "socorro");
            Console.WriteLine(listaCircular);

            Console.WriteLine("\nMétodo Add All:");
            int[] testArray = new int[] { 21,22,23,24,25};
            listaCircular.addAll(testArray);
            Console.WriteLine(listaCircular);

            Console.WriteLine("\nMétodo Add All después de un nodo específico: ");
            string[] testArray2 = new string[] { "Hola", "Adios", "Hasta Nunca!" };
            listaCircular.addAll(listaCircular.nodeOf("socorro"),testArray2);
            Console.WriteLine(listaCircular);

            Console.WriteLine("\nMétodo Clear: ");
            //listaCircular.clear();
            //listaCircular.imprimir();

            Console.WriteLine("\nMétodo List Clone: ");
            ListaCircularSimple NuevaLista = listaCircular.clone();
            Console.WriteLine(NuevaLista);

            Console.WriteLine("\nMétodo Contains: ");
            Console.WriteLine(listaCircular.contains("Hasta Nunca!"));

            Console.WriteLine("\nMétodo Contains All: ");
            Console.WriteLine(listaCircular.containsAll(new int[] { 1,2,0987654321}));

            Console.WriteLine("\nMétodo NodeOf: ");
            Console.WriteLine(listaCircular.nodeOf(1).Elemento);

            Console.WriteLine("\nMétodo isEmpty: ");
            Console.WriteLine(listaCircular.isEmpty());

            Console.WriteLine("\nMétodo get");
            Console.WriteLine(listaCircular.get());

            Console.WriteLine("\nMétodo get para un nodo específico: ");
            Console.WriteLine(listaCircular.get(listaCircular.nodeOf(0)));

            Console.WriteLine("\nMétodo get previous: ");
            Console.WriteLine(listaCircular.getPrevious(listaCircular.nodeOf(1)));

            Console.WriteLine("\nMétodo get next: ");
            Console.WriteLine(listaCircular.getNext(listaCircular.nodeOf("socorro")));
            
            Console.WriteLine("\nMétodo Remove: ");
            Console.WriteLine(listaCircular);
            listaCircular.remove("Hola");
            Console.WriteLine(listaCircular);

            Console.WriteLine("\nMétodo remove (Para un nodo específico)");
            Console.WriteLine(listaCircular);
            Console.WriteLine(listaCircular.remove(listaCircular.nodeOf(24)));
            Console.WriteLine(listaCircular.remove(listaCircular.nodeOf(4)));
            Console.WriteLine(listaCircular.remove(listaCircular.nodeOf("Adios")));
            Console.WriteLine(listaCircular);

            Console.WriteLine("\nMétodo removeAll: ");
            string[] myTestArray = new string[] { "so", "co", "rro" };
            Console.WriteLine(listaCircular.addAll(myTestArray));
            Console.WriteLine(listaCircular.ToString());
            Console.WriteLine(listaCircular.removeAll(myTestArray));
            Console.WriteLine(listaCircular.removeAll(testArray2));
            Console.WriteLine(listaCircular.ToString());

            Console.WriteLine("\nMétodo retain all: ");
            Console.WriteLine(listaCircular);
            listaCircular.retainAll(new int[] { 1,2,3});
            Console.WriteLine(listaCircular);

            Console.WriteLine("\nMétodo set: ");
            listaCircular.set(listaCircular.nodeOf(2),"socorrox2");
            Console.WriteLine(listaCircular);

            Console.WriteLine("\nMétodo Size: ");
            Console.WriteLine(listaCircular.size());

            Console.WriteLine("\nMétodo toArray: ");
            Console.WriteLine(String.Join(", ",listaCircular.toArray()));

            Console.WriteLine("\nMétodo subList: ");
            listaCircular.addAll(new int[] {6,7,8,9});
            Console.WriteLine(listaCircular);
            Console.WriteLine(listaCircular.subList(listaCircular.nodeOf(7),listaCircular.nodeOf(8)));

            Console.WriteLine("\nMétodo Sort: ");
            Console.WriteLine(listaCircular.sort());
            Console.WriteLine(listaCircular.sort(1));
            Console.ReadLine();
        }
    }
}
