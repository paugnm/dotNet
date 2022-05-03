using System;
using System.Collections;

delegate bool Condicion(int n);
delegate int Funcion(int n);
delegate int Suma(int x, int y);

namespace practica8Ej5
{
    class Program
    {
        static void Main(string[] args)
        {
            ListaDeEnteros lista1 = new ListaDeEnteros();
            for (int i = 1; i <= 10; i++)
            {
                lista1.Agregar(i);
            }
            foreach (int i in lista1)
            {
                Console.Write(i + "-");
            }
            Console.WriteLine();
            ListaDeEnteros lista2 = lista1.Seleccionar(n => n % 2 == 0);
            ListaDeEnteros lista3 = lista2.Aplicar(n => n * 5);
            ListaDeEnteros lista4 = lista1.Seleccionar(n => n > 7).Aplicar(n => n + 10);
            ListaDeEnteros lista5 = ListaDeEnteros.Combinar(lista3, lista4, (x, y) => x + y);
            lista1.Imprimir();
            lista2.Imprimir();
            lista3.Imprimir();
            lista4.Imprimir();
            lista5.Imprimir();
            ListaDeEnteros.Combinar(lista5, lista3, (x, y) => x + 2 * y).Imprimir();
            Console.ReadKey();
        }
    }

    class ListaDeEnteros : IEnumerable
    {
        ArrayList lista = new ArrayList();

        public static ListaDeEnteros Combinar(ListaDeEnteros listaA, ListaDeEnteros listaB, Suma s)
        {
            ListaDeEnteros resultado = new ListaDeEnteros();

            //Guardo la longitud de la lista que sea más corta. 
            int recorrido;
            recorrido = listaA.Cantidad < listaB.Cantidad ? listaA.Cantidad : listaB.Cantidad;

            //Dentro de este for me aseguro que ambas listas tienen elementos en la posición i simultaneamente 
            for (int i = 0; i < recorrido; i++)
            {
                resultado.Agregar(s(listaA.ElementoEnPos(i), listaB.ElementoEnPos(i)));
            }

            //Termino de recorrer la lista con mas elementos
            if (listaA.Cantidad > listaB.Cantidad)
            {
                for (int i = recorrido; i < listaA.Cantidad; i++)
                {
                    resultado.Agregar(s(listaA.ElementoEnPos(i), 0));
                }
            }
            else
            {
                for (int i = recorrido; i < listaB.Cantidad; i++)
                {
                    resultado.Agregar(s(listaB.ElementoEnPos(i), 0));
                }
            }
            return resultado;

        }

        public int ElementoEnPos(int pos)
        {
            return (int)lista[pos];
        }
        public ListaDeEnteros Seleccionar(Condicion c)
        {
            ListaDeEnteros resultado = new ListaDeEnteros();
            foreach (int elem in this)
            {
                if (c(elem)) resultado.Agregar(elem);
            }
            return resultado;
        }

        public ListaDeEnteros Aplicar(Funcion f)
        {
            ListaDeEnteros resultado = new ListaDeEnteros();

            foreach (int elem in this)
            {
                resultado.Agregar(f(elem));
            }

            return resultado;
        }

        public void Agregar(int i) => lista.Add(i);


        public IEnumerator GetEnumerator()
        {
            //El campo "lista" es un ArrayList, y la clase ArrayList implementa la interface IEnumerable
            return lista.GetEnumerator();
        }

        public void Imprimir()
        {
            Console.WriteLine();
            foreach (int elem in lista)
            {
                Console.Write($"{elem}, ");
            }
        }

        public int Cantidad => lista.Count;

    }
}
