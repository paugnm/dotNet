using System;
using System.Collections;

namespace practica7Ej8
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable rango = Rango(6, 30, 3);
            IEnumerable potencias = Potencias(2, 10);
            IEnumerable divisibles = DivisiblesPor(rango, 6);
            
            foreach (int i in rango)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
           
            foreach (int i in potencias)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            
            foreach (int i in divisibles)
            {
                Console.Write(i + " ");
            }
            Console.ReadKey();
        }

        static IEnumerable Rango (int i, int j, int p) 
        {
            for (int comienzo = i; comienzo <= j; comienzo = comienzo+p) 
            {
                yield return comienzo;
            }    
        }

        static IEnumerable Potencias (int b, int k) 
        {
            for (int i = 1; i <= k; i++) 
            {
                yield return (int) Math.Pow(b,i);
            }    
        }

        static IEnumerable DivisiblesPor (IEnumerable e, int i) 
        {
            foreach (int elem in e) 
            {
                if (elem % i == 0) yield return elem;
            }    
        }
    }
}
