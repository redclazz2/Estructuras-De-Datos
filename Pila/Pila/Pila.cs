using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pila
{
    internal class Pila
    {
        private Lista almacen = new Lista(); 
        
        //Métodos
        public void clear() 
        {
            almacen.clear();
        }

        public bool isEmpty() 
        {
            return almacen.isEmpty();
        }

        public object peek() 
        {
            return almacen.getFirst();
        }

        public object pop() 
        {
            try 
            {
                if (!isEmpty()) 
                {
                    var Object = almacen.getFirst();
                    almacen.remove(Object);
                    return Object;
                }
                else 
                {
                    return null;
                }
            }
            catch 
            {
                return null;
            }
        }

        public bool push(object Object) 
        {
            try 
            {
                almacen.addFirst(Object);
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public int size() 
        {
            return almacen.size();
        }
    }
}
