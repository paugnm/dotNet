using System;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;

namespace practica10Ej15
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int[]> tarea = CantidadDePalabrasPorArchivoAsync("archivo1.txt","archivo2.txt");

            int[] resultado = tarea.Result;

            for(int i = 0; i<resultado.Length; i++){
                Console.WriteLine($"Cantidad de palabras en el texto {i}: {resultado[i]}");
            }
            Console.ReadKey();
        }


        static async Task<int[]> CantidadDePalabrasPorArchivoAsync (params string[] archivos)
        {
            List<Task<int>> tareas = new List<Task<int>>();
            List<int> contadorPalabras = new List<int>();   
            
            foreach (string archivo in archivos) 
            {
                tareas.Add(ContarPalabrasAsync(archivo));
            }

            await Task.WhenAll(tareas.ToArray());
            
            foreach(Task<int> tarea in tareas) 
            {
                contadorPalabras.Add(tarea.Result);

            }
            return contadorPalabras.ToArray();
        }


        static async Task<int> ContarPalabrasAsync(string archivo)
        {
            int contador = 0;
            char[] separador = new char[] { ',', ' ', '.', '\n', '\r' };
            Task t1 = new Task(() =>
          {
              Task<string> t = DevolverTextoAsync(archivo);
              string[] palabras = t.Result.Split(separador);
              contador = palabras.Length;
          }
            );
            t1.Start();
            await t1;
            return contador;
        }

        static async Task<string> DevolverTextoAsync(string archivo)
        {
            string texto = null;

            Task t = new Task(() =>
           {
               StreamReader sr = new StreamReader(archivo);
               texto = sr.ReadToEnd();
               sr.Close();
           }
            );
            t.Start();
            await t;
            return texto;
        }

    }
}
