using System;
using System.Collections;
using System.IO;

namespace practica7Ej10
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList listaDeAutos = new ArrayList();
            Console.WriteLine("Menú de opciones");
            Console.WriteLine("================");
            Console.WriteLine();
            Console.WriteLine("     1. Ingresar autos desde la consola");
            Console.WriteLine("     2. Cargar de la lista de autos desde el disco");
            Console.WriteLine("     3. Guardar lista de autos en el disco");
            Console.WriteLine("     4. Listar por consola");
            Console.WriteLine("     5. Salir");
            ConsoleKeyInfo tecla;
            do
            {
                Console.Write("\nIngrese su opción: ");                
                tecla = Console.ReadKey(false);
                switch (tecla.KeyChar)
                {
                    case '1': 
                        LeerDesdeConsola(listaDeAutos);
                        break;
                    case '2': 
                        CargarDesdeDisco(listaDeAutos); 
                        break;
                    case '3':
                        GuardarEnDisco(listaDeAutos); 
                        break;
                    case '4': 
                        ListarEnPantalla(listaDeAutos);
                        break;
                }
            } while (tecla.KeyChar != '5');
        }

        static void ListarEnPantalla(ArrayList lista)
        {
            Console.WriteLine();
            foreach (Auto a in lista)
            {
                Console.WriteLine($"Marca: {a.Marca} - Modelo: {a.Modelo}");
            }

        }


        static void GuardarEnDisco(ArrayList lista)
        {
            StreamWriter sw = new StreamWriter("listaDeAutosNueva.txt");
            foreach (Auto a in lista)
            {
                sw.WriteLine($"Marca: {a.Marca} - Modelo:{a.Modelo}");
            }
            sw.Close();

        }

        static void CargarDesdeDisco(ArrayList lista)
        {
            StreamReader sr = new StreamReader("autos.txt");
            string marca;
            int modelo;
            while (!sr.EndOfStream)
            {
                marca = sr.ReadLine();
                modelo = int.Parse(sr.ReadLine());
                Auto a = new Auto { Marca = marca, Modelo = modelo };
                lista.Add(a);
            }
            sr.Close();
        }

        static void LeerDesdeConsola(ArrayList lista)
        {
            Console.Write("Ingrese la marca del auto: ");
            string marca = Console.ReadLine();
            while (marca != "")
            {
                Console.Write("Ingrese el modelo del auto: ");
                int modelo = int.Parse(Console.ReadLine());
                Auto a = new Auto { Marca = marca, Modelo = modelo };
                lista.Add(a);
                Console.Write("\nIngrese la marca del auto: ");
                marca = Console.ReadLine();
            }
        }

    }

    class Auto
    {
        public string Marca { get; set; }
        public int Modelo { get; set; }
    }
}
