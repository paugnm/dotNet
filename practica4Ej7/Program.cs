using System;
using System.Collections;

namespace practica4
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
            n.Insertar(-5);
            n.Insertar(100);
            foreach (int i in n.GetInOrder())
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();

            Console.WriteLine($"Altura del árbol: {n.GetAltura()}");
            Console.WriteLine($"Cantidad de nodos: {n.GetCantNodos()}");
            Console.WriteLine($"Valor máximo: {n.GetValorMaximo()}");
            Console.WriteLine($"Valor mínimo: {n.GetValorMinimo()}");

            Console.ReadKey();

        }
    }

    class Nodo
    {
        int valor;
        public Nodo HijoIzq { get; private set; }
        public Nodo HijoDer { get; private set; }

        //Constructor. Inicializa el nodo (que será la raíz del árbol) con el valor pasado como parametro y los dos hijos en null
        public Nodo(int valor)
        {
            this.valor = valor;
            this.HijoIzq = null;
            this.HijoDer = null;
        }

        public void Insertar(int valor)
        {
            //Si el valor es igual a otro que ya existe en el árbol, salgo del método con un return y le devuelvo el control al método invocador
            if (this.valor == valor)
            {
                return;
            }

            //Si el valor que queremos insertar es menor, vamos a la rama izquierda            
            else if (this.valor > valor)
            {
                if (this.HijoIzq == null)
                {  //Si no tiene hijos, lo creo y lo agrego
                    Nodo n = new Nodo(valor);
                    this.HijoIzq = n;
                }
                else
                {
                    HijoIzq.Insertar(valor);  //Si tiene, llamo recursivamente al método insertar
                }

            //Si el valor que queremos insertar es mayor, vamos a la rama derecha            
            }
            else
            {
                if (this.HijoDer == null)
                {
                    Nodo n = new Nodo(valor);
                    HijoDer = n;
                }
                else
                {
                    HijoDer.Insertar(valor);
                }
            }
        }

        public ArrayList GetInOrder()
        {
            ArrayList arr = new ArrayList();

            //Llamo a un método privado para que recorra el árbol en orden y vaya guardando los valores en un ArrayList pasado por referencia. De Esta manera no pierdo la firma pedida en el main
            recorrerEnOrden(ref arr);
            return arr;
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

            Nodo nodo = null;
            Queue q = new Queue();

            q.Enqueue(this);
            q.Enqueue(null);

            while (q.Count != 0)
            {
                nodo = (Nodo)q.Dequeue();
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

        public int GetValorMaximo()
        {
            int max;
            //Como es un árbol binario de búsqueda, al hacer recorrido en orden, los valores van a ser devueltos de menor a mayor
            //Por lo tanto, llamo al método recorrerEnOrden que ya estaba creado. El último valor de ese arraylist será el mayor
            ArrayList arr = new ArrayList();

            recorrerEnOrden(ref arr);
            max = (int)arr[arr.Count - 1];

            return max;

        }
        public int GetValorMinimo()
        {
            int min;
            ArrayList arr = new ArrayList();
            recorrerEnOrden(ref arr);
            min = (int)arr[0];
            return min;

        }
    }
}