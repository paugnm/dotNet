using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace practica10Ej9
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task<int>> tareas = new List<Task<int>>();
            for (int n = 1; n <= 10; n++)
            {
                //a) Resolverlo utilizando un constructor de la clase Task
                Task<int> t= new Task<int>( (num) => Sumatoria((int)num), n);
                tareas.Add(t);
                t.Start();

                //b) Resolverlo utilizando el método StartNew de una instancia de TaskFactory
                //tareas.Add(Task.Factory.StartNew( (num) => Sumatoria((int)num), n));
            }
            
            
            
            Task<int>.WaitAll(tareas.ToArray());            
        
            foreach (Task<int> tarea in tareas) {            
                Console.WriteLine (tarea.Result);
            }            

            Console.ReadKey();
        }

        static int Sumatoria(int n)
        {
            int suma = 0;
            for (int i = 1; i <= n; i++)
            {
                suma += i;
            }
            return suma;
        }
    }
}
