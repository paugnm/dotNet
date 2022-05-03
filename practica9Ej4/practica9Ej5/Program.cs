using System;
using System.Collections;
using System.Collections.Generic;

namespace practica4Ej7
{
    class Program
    {
        static void Main(string[] args)
        {
            Nodo n = new Nodo(7);
n.Insertar(8);
n.Insertar(10);
n.Insertar(3);
n.Insertar(1);
n.Insertar(5);
n.Insertar(14);
foreach (int i in n.GetInOrder())
{
Console.Write(i + " ");
}
Console.WriteLine();
Console.WriteLine(n.GetAltura());
Console.WriteLine(n.GetCantNodos());
Console.WriteLine(n.GetValorMaximo());
Console.WriteLine(n.GetValorMinimo());

            Console.ReadKey();
        }

    }


    class Nodo<T> where T : IComparable
    {
        T valor;
        public Nodo<T> HijoIzq { get; private set; }
        public Nodo<T> HijoDer { get; private set; }

        private List<T> InOrder 
        {
            get => this.GetInOrder();
        }

        //Constructor. Inicializa el nodo (que será la raíz del árbol) con el valor pasado como parametro y los dos hijos en null
        public Nodo(T valor)
        {
            this.valor = valor;
            this.HijoIzq = null;
            this.HijoDer = null;
        }

        public void Insertar(T valor)
        {
            //Si el valor es igual a otro que ya existe en el árbol, salgo del método con un return y le devuelvo el control al método invocador
            if (this.valor == valor)
            {
                return;
            }

            //Si el valor del nodo es mayor al valor que queremos insertar, vamos a la rama izquierda            
            else if (this.valor > valor)
            {
                if (this.HijoIzq == null)
                {  //Si no tiene hijos, lo creo y lo agrego
                    Nodo<T> n = new Nodo<T>(valor);
                    this.HijoIzq = n;
                }
                else
                {
                    HijoIzq.Insertar(valor);  //Si tiene, llamo recursivamente al método insertar
                }

                //Si el valor del nodo es menor al valor que queremos insertar, vamos a la rama derecha            
            }
            else
            {
                if (this.HijoDer == null)
                {
                    Nodo<T> n = new Nodo<T>(valor);
                    HijoDer = n;
                }
                else
                {
                    HijoDer.Insertar(valor);
                }
            }
        }

        public List<T> GetInOrder()
        {
            List<T> lista = new List<T>();

            //Llamo a un método privado para que recorra el árbol en orden y vaya guardando los valores en un ArrayList pasado por referencia. De Esta manera no pierdo la firma pedida en el main
            recorrerEnOrden(ref lista);
            return lista;
        }

        private void recorrerEnOrden(ref ArrayList arr)
        {
            if (this.HijoIzq != null) this.HijoIzq.recorrerEnOrden(ref arr);

            arr.Add(this.valor);

            if (this.HijoDer != null) this.HijoDer.recorrerEnOrden(ref arr);

        }

        public int GetCantNodos()
        {
            int contador = 0;
            ContarNodos(ref contador);
            return contador;
        }

        private void ContarNodos(ref int contador)
        {
            contador++;

            if (this.HijoIzq != null) this.HijoIzq.ContarNodos(ref contador);

            if (this.HijoDer != null) this.HijoDer.ContarNodos(ref contador);

        }

        public int GetAltura()
        {
            int altura = 0;

            //Llamo un método privado que hace un recorrido por niveles y calcula la altura del árbol
            recorridoPorNiveles(ref altura);

            return altura;

        }

        private void recorridoPorNiveles(ref int altura)
        {

            Nodo<T> nodo = null;
            Queue q = new Queue();

            q.Enqueue(this);
            q.Enqueue(null);

            while (q.Count != 0)
            {
                nodo = (Nodo<T>)q.Dequeue();
                if (nodo != null)
                {
                    if (nodo.HijoIzq != null)
                    {
                        q.Enqueue(nodo.HijoIzq);
                    }
                    if (nodo.HijoDer != null)
                    {
                        q.Enqueue(nodo.HijoDer);
                    }
                }
                else
                {
                    if (q.Count != 0)
                    {
                        altura++;
                        q.Enqueue(null);
                    }
                }
            }
        }

        public T GetValorMaximo()
        {
            T max;
            //Como es un árbol binario de búsqueda, al hacer recorrido en orden, los valores van a ser devueltos de menor a mayor
            //Por lo tanto, llamo al método recorrerEnOrden que ya estaba creado. El último valor de ese arraylist será el mayor
            ArrayList arr = new ArrayList();

            recorrerEnOrden(ref arr);
            max = (T)arr[arr.Count - 1];

            return max;

        }
        public T GetValorMinimo()
        {
            T min;
            ArrayList arr = new ArrayList();
            recorrerEnOrden(ref arr);
            min = (T)arr[0];
            return min;

        }
    }


}
