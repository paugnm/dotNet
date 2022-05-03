using System;
using System.Collections;

namespace practica5Ej7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();
        }
    }

    class Persona
    {
        string Nombre { get; set; }
        char Sexo { get; set; }
        int Dni { get; set; }
        DateTime FechaNacimiento { get; set; }

        int Edad { get => (DateTime.Now - FechaNacimiento).Days / 365; }

        public Object this[int i]
        {
            get
            {
                if (i == 0) return Nombre;
                else if (i == 1) return Sexo;
                else if (i == 2) return Dni;
                else if (i == 3) return FechaNacimiento;
                else if (i == 4) return Edad;
                else return null;
            }
            set
            {
                if (i == 0) Nombre = (string)value;
                else if (i == 1) Sexo = (char)value;
                else if (i == 2) Dni = (int)value;
                else if (i == 3) FechaNacimiento = (DateTime)value;
                else return;
            }

        }

        //EJERCICIO 8: Completar la clase ListaDePersonas agregando dos indizadores de sólo lectura
        class ListaDePersonas
        {
            private Hashtable ht = new Hashtable();
            public void Agregar(Persona p)
            {
                ht[p.Dni] = p;
            }

            //Un índice entero que permite acceder a las personas de la lista por número de documento.
            public Persona this [int i] 
            {
                get 
                {
                    if (ht.ContainsKey(i)) 
                    {
                        return (Persona) ht[i];
                    } else
                    {
                        return null;
                    }
                }
            }
            public ArrayList this [char c] 
            {
                get
                {
                   ArrayList result = new ArrayList();
                   foreach (DictionaryEntry p in ht)
                   {
                       if (((Persona)p.Value).Nombre[0] == c) {
                           result.Add(p.Value);
                       }
                   }
                   return result; 
                }
            }

        }

    }
}
