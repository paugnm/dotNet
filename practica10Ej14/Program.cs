using System;
using System.Threading.Tasks;
using System.IO;

namespace practica10Ej14
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int> t = ContarPalabrasAsync("archivo.txt");
            Console.WriteLine($"Cantidad de palabras en el texto: {t.Result}");
            Console.ReadKey();
        }

        static async Task<int> ContarPalabrasAsync (string archivo) 
        {
            int contador = 0;
            char [] separador = new char [] {',', ' ', '.','\n','\r'};
            Task t1 = new Task ( () => 
            {
                Task<string> t = DevolverTextoAsync(archivo);
                string [] palabras = t.Result.Split(separador);
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