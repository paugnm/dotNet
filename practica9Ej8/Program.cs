using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;

namespace practica9Ej8
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = null;
            //Console.Write(">>Ingrese el nombre del archivo: ");
            string nombreArchivo =  "parrafo.txt"; //Console.ReadLine();
            try 
            {
                sr = new StreamReader(nombreArchivo);
                string texto = sr.ReadToEnd();
                char[] separadores = new char[] {' ', ':', '.', '(', ')', ',', '\n', '\r'};
                string [] palabras = texto.Split(separadores);
                
                SortedDictionary<string, int> contador = ContarPalabras (palabras);

                foreach (KeyValuePair<string,int> par in contador) {
                    Console.WriteLine($"{par.Key}: {par.Value}");
                }
                
            
            } catch (Exception e){
                Console.WriteLine(e.Message);
            
            } finally {
                if (sr != null) sr.Close();
            }  

            Console.ReadKey();
        }

        static SortedDictionary<string, int> ContarPalabras (string[] palabras) 
        {
            SortedDictionary<string, int> resultado = new SortedDictionary<string, int>();
            foreach (string palabra in palabras) {
                
                if (resultado.ContainsKey(palabra)) {
                    resultado[palabra]++;
                
                } else {
                    
                    resultado.Add(palabra,1);
                }
            }
            
            return resultado;
        }
    }
}
