using System;
using System.Collections;
using System.Collections.Generic;

namespace practica9Ej5
{
    class Program
    {
        static void Main(string[] args)
        {
            Nodo<int> n = new Nodo<int>(7);
            n.Insertar(3);
            n.Insertar(1);
            n.Insertar(5);
            n.Insertar(12);
            foreach (int elem in n.InOrder)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Altura: {n.Altura}");
            Console.WriteLine($"Cantidad: {n.CantNodos}");
            Console.WriteLine($"Mínimo: {n.ValorMinimo}");
            Console.WriteLine($"Máximo: {n.ValorMaximo}");
            Nodo<string> n2 = new Nodo<string>("hola");
            n2.Insertar("Mundo");
            n2.Insertar("XYZ");
            n2.Insertar("ABC");
            foreach (string elem in n2.InOrder)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Altura: {n2.Altura}");
            Console.WriteLine($"Cantidad: {n2.CantNodos}");
            Console.WriteLine($"Mínimo: {n2.ValorMinimo}");
            Console.WriteLine($"Máximo: {n2.ValorMaximo}");

            Console.ReadKey();

        }
    }

    class Nodo <T> where T: IComparable
    {
        T valor;
        public Nodo<T> HijoIzq { get; private set; }
        public Nodo<T> HijoDer { get; private set; }

        public int Altura {get => GetAltura();} 
        public int CantNodos {get => GetCantNodos();}
        
        public T ValorMaximo {get => GetValorMaximo();}
        public T ValorMinimo {get => GetValorMinimo();}
        public List<T> InOrder {get => GetInOrder();}

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
            if (this.valor.CompareTo(valor) == 0)
            {
                return;
            }

            //Si el valor del nodo es mayor al valor que queremos insertar, vamos a la rama izquierda            
            else if (this.valor.CompareTo(valor)>0)
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

        private List<T> GetInOrder()
        {
            List<T> lista = new List<T>();

            //Llamo a un método privado para que recorra el árbol en orden y vaya guardando los valores en una lista genérica pasado por referencia. De Esta manera no pierdo la firma pedida en el main
            recorrerEnOrden(ref lista);
            return lista;
        }

        private void recorrerEnOrden(ref List<T> lista)
        {
            if (this.HijoIzq != null) this.HijoIzq.recorrerEnOrden(ref lista);

            lista.Add(this.valor);

            if (this.HijoDer != null) this.HijoDer.recorrerEnOrden(ref lista);

        }

        private int GetCantNodos()
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

        private int GetAltura()
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

        private T GetValorMaximo()
        {
            T max;
            //Como es un árbol binario de búsqueda, al hacer recorrido en orden, los valores van a ser devueltos de menor a mayor
            //Por lo tanto, llamo al método recorrerEnOrden que ya estaba creado. El último valor de ese arraylist será el mayor
            List<T> lista = new List<T>();

            recorrerEnOrden(ref lista);
            max = (T)lista[lista.Count -1];

            return max;

        }
        private T GetValorMinimo()
        {
            T min;
            List<T> lista = new List<T>();
            recorrerEnOrden(ref lista);
            min = (T)lista[0];
            return min;

        }
    }


}
