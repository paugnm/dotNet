using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace practica10Ej8
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task> tareas = new List<Task>();
            for (int a = 1; a <= 3; a++)
            {
                for (int b = a + 2; b <= a + 4; b++)
                {
                    int auxA = a; //Asi creo una copia por valor de a y b (sino se pasan por referencia dentro de la expresión lambda)
                    int auxB = b;
                    Task t = Task.Run(() => Sumatoria(auxA,auxB));
                    tareas.Add(t);
                }
            }
            Task.WaitAll(tareas.ToArray());

            Console.ReadKey();     
        }

        static void Sumatoria(int a, int b) {
            int sumatoria = 0;
            for (int inicio = a; inicio <= b; inicio++) {
                sumatoria += inicio;
            }
            Console.WriteLine($"Suma desde {a} hasta {b} = {sumatoria}");
        }
    }
}
