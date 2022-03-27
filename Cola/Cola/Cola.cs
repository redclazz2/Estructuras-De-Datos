using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cola
{
    internal class Cola
    {
        ListaDoble almacen = new ListaDoble();

        public Cola(object elemento) 
        {
            almacen.add(elemento);
        }

        public Cola() 
        {
        
        }
        
        //Métodos
        public void clear() 
        {
            almacen.clear();
        }

        public bool isEmpty() 
        {
            return almacen.isEmpty();
        }

        public object extract() 
        {
            var tempObj = (almacen.Head != null) ? almacen.getFirst() : null;
            almacen.remove(almacen.Head);
            return tempObj;
        }

        public bool insert(object objecto) 
        {
            var boolCheck = false;
            if(objecto != null) 
            {
                almacen.add(objecto);
                boolCheck = true;
            }
            return boolCheck;
        }

        public int size() 
        {
            return almacen.size();
        }

        public bool search(object objeto) 
        {
            return almacen.contains(objeto);
        }

        public void sort() 
        {
            almacen.sort();
        }

        public void reverse() 
        {
            var tempList = almacen.clone();
            Node TempNode = tempList.Tail;
            clear();
            while(TempNode != null) 
            {
                insert(TempNode.Objeto);
                TempNode = TempNode.Previous;
            }
        }

        public override string ToString()
        {
            return almacen.ToString();
        }

    }
}
