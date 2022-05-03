using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace practica9Ej10
{
    class Program
    {
        static void Main(string[] args)
        {

            // Console.Write(">> Ingresar el nombre del primer archivo: ");
            // string archivo1 = Console.ReadLine();

            // Console.Write(">> Ingresar el nombre del segundo archivo: ");
            // string archivo2 = Console.ReadLine();

            List<string> lista1 = ObtenerListaDePalabras("archivo1.txt");
            List<string> lista2 = ObtenerListaDePalabras("archivo2.txt");

            SortedSet<string> listaOrdenada1 = new SortedSet<string>(lista1);
            SortedSet<string> listaOrdenada2 = new SortedSet<string>(lista2);

            listaOrdenada1.IntersectWith(listaOrdenada2);

            //Convierto el SortedSet en una lista para usar el metodo ConvertAll
            List<string> lista = new List<string>(listaOrdenada1);

            List<PalabraPosiciones> listaFinal = lista.ConvertAll(new Converter<string, PalabraPosiciones>(Convertir));  //Convertir es un delegado Converter que recibe el valor string de entrada y devuelve un valor de tipo PalabrasPosiciones

            foreach (PalabraPosiciones palabra in listaFinal) {
                palabra.AsignarPosiciones(lista1, lista2);
            }          
           
           foreach (PalabraPosiciones palabra in listaFinal) {
                palabra.MostrarPosiciones();
            } 


            Console.ReadKey();
        }

        static List<string> ObtenerListaDePalabras(string archivo) {
            StreamReader sr = null; 
            try {                           
                sr = new StreamReader(archivo);
                string texto = sr.ReadToEnd();                
                char[] separadores = new char[] { ' ', ',', ':', '.', '(', ')', '\n', '\r' };                
                string [] aux = texto.ToLower().Split(separadores);                     
                List<string> listaDePalabras = new List <string> (aux);                
                return listaDePalabras;
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                return null;
                }
            finally {
                if (sr != null) sr.Close();
            }                
        }

        static PalabraPosiciones Convertir(string palabra) 
        {
            PalabraPosiciones aux = new PalabraPosiciones(palabra);
            return aux; 
        }

    }       


    class PalabraPosiciones
    {
        public string Palabra { private set; get; }
        public List<List<int>> Posiciones { private set; get; } = new List<List<int>>();

        public PalabraPosiciones (string palabra) {
            this.Palabra = palabra;
        }

        public void AsignarPosiciones (params List<string>[] listasDePalabras) {
                
            //Recorro cada una de las listas que recibi como parametro, que son listas de palabras de diferentes archivos
        
            //Voy guardando en la lista de listas la posicion de la palabra en cada texto
            for (int i = 0; i<listasDePalabras.Length; i++) {                        
            
                Posiciones.Add(new List<int>());

                for(int pos = 0; pos<listasDePalabras[i].Count; pos++) {
                    if (listasDePalabras[i][pos]== this.Palabra) {
                        Posiciones[i].Add(pos);
                    }
                }              
            }  
        }
        public void MostrarPosiciones() {
            Console.WriteLine($"Palabra: {this.Palabra}");

            for(int i=0; i<Posiciones.Count; i++) {             
               
                Console.Write($"\t|--Posiciones en texto{i}: --> ");
                foreach (int pos in Posiciones[i]) {
                    
                    Console.Write($"{pos} ");
                }
            Console.WriteLine();    
            }    
            Console.WriteLine();         
           
        }
    }
}
