using System;
using System.Collections;
using System.Collections.Generic;

namespace practica9Ej4
{
    class Program
    {
        static void Main(string[] args)
        {
            ListaGenerica<int> lista = new ListaGenerica<int>();
            
            lista.AgregarAdelante(3);
            lista.AgregarAdelante(100);
            lista.AgregarAtras(10);
            lista.AgregarAtras(11);
            lista.AgregarAdelante(0);
            
            IEnumerator<int> enumerador = lista.GetEnumerator();
            
            while (enumerador.MoveNext())
            {
                int i = enumerador.Current;
                Console.Write(i + " ");
            }

            Console.ReadKey();
        }
    }

    class Nodo<T>
    {
        public T Valor { get; private set; }
        public Nodo<T> Proximo { get; set; } = null;

        public Nodo(T valor) => Valor = valor;

    }

    class ListaGenerica<T> 
    {
        private Nodo<T> _inicio = null;
        private Nodo<T> _ultimo = null;


        public void AgregarAdelante (T valor) 
        {
            if (_inicio == null)
            {
                _inicio = new Nodo<T> (valor);
                _ultimo = _inicio;
            } else {
                Nodo<T> aux = _inicio;
                _inicio = new Nodo<T> (valor);
                _inicio.Proximo = aux;
            }
        }

        public void AgregarAtras (T valor) 
        {
            if (_inicio == null)
            {
                _inicio = new Nodo<T> (valor);
                _ultimo = _inicio;
            } else {
                Nodo<T> aux = _ultimo;
                _ultimo = new Nodo<T>(valor);
                aux.Proximo = _ultimo;
            }
        }

        public IEnumerator<T> GetEnumerator() 
        {
            List<T> listaAux = new List<T>();
            Nodo<T> aux = _inicio;

            while (aux!=null) 
            {
                listaAux.Add(aux.Valor);
                aux = aux.Proximo;
            }

            return listaAux.GetEnumerator();
        }

    }
}
