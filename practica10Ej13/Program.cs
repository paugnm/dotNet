using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace practica10Ej13
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<string> t = DevolverTextoAsync("archivo.txt");
            Console.WriteLine(t.Result);
            Console.ReadKey();
        }

        static async Task<string> DevolverTextoAsync(string archivo) 
        {
            string texto = null;

            Task t = new Task (() => 
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
