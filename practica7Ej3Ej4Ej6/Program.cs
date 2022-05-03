using System;
using System.Collections;

namespace practica7Ej3
{
    class Program
    {
        static void Main(string[] args)
        {
            Ejecutar6();
            Console.ReadKey();
        }

        //EJECUTAR DEL EJERCICIO 3
        public static void Ejecutar3()
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList() {
                new Persona(),
                new Auto()
            };
            foreach (IComercial c in lista)
            {
                c.Importa();
            }
            foreach (IImportante i in lista)
            {
                i.Importa();
            }
            (lista[0] as Persona).Importa();
            (lista[1] as Auto).Importa();
        }

        //EJECUTAR DEL EJERCICIO 4
        public static void Ejecutar4()
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList() {
                new Persona() {Nombre="Zulema"},
                new Perro() {Nombre="Sultán"},
                new Persona() {Nombre="Claudia"},
                new Persona() {Nombre="Carlos"},
                new Perro() {Nombre="Chopper"},
            };
            lista.Sort(); //debe ordenar por Nombre alfabéticamente
            foreach (INombrable n in lista)
            {
                Console.WriteLine($"{n.Nombre}: {n}");
            }
        }

        //EJECUTAR DEL EJERCICIO 6
        public static void Ejecutar6()
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList() {
                new Persona() {Nombre="Ana María"},
                new Perro() {Nombre="Sultán"},
                new Persona() {Nombre="Ana"},
                new Persona() {Nombre="José Carlos"},
                new Perro() {Nombre="Chopper"}
            };
            lista.Sort(new ComparadorLongitudNombre()); //ordena por longitud de Nombre
            foreach (INombrable n in lista)
            {
                Console.WriteLine($"{n.Nombre.Length}: {n.Nombre}");
            }
        }
   
}


class Auto : IVendible, ILavable, IReciclable, IImportante, IComercial
{
    void IImportante.Importa()
    {
        Console.WriteLine("Auto importante");
    }
    void IComercial.Importa()
    {
        Console.WriteLine("Auto que se vende al exterior");
    }

    public void Importa()
    {
        Console.WriteLine("Método Importa() de la clase Auto");
    }
    public void Lavar()
    {
        Console.WriteLine("Lavando Auto");
    }

    public void Reciclar()
    {
        Console.WriteLine("Reciclando auto");
    }

    public void Secar()
    {
        Console.WriteLine("Secando auto");
    }

    public void SeVendeA(Persona p)
    {
        Console.WriteLine("Vendiendo auto a persona");
    }
}


class Persona : IAtendible, IImportante, IComercial, INombrable, IComparable
{
    public string Nombre { get; set; }

    public override string ToString()
    {
        return $"{Nombre} es una Persona";
    }
    public void Atender()
    {
        Console.WriteLine("Atendiendo persona");
    }

    void IImportante.Importa()
    {
        Console.WriteLine("Persona importante");
    }
    void IComercial.Importa()
    {
        Console.WriteLine("Persona vendiendo al exterior");
    }
    public void Importa()
    {
        Console.WriteLine("Método Importa() de la clase persona");
    }

    public int CompareTo(object obj)
    {
        string st1 = this.Nombre;
        string st2 = (obj as INombrable).Nombre;
        return st1.CompareTo(st2);
    }
}

class ComparadorLongitudNombre : IComparer
{
        public int Compare(object x, object y)
        {
            INombrable elem1 = x as INombrable;
            INombrable elem2 = y as INombrable;
            return elem1.Nombre.Length.CompareTo(elem2.Nombre.Length);
        }
}

class Libro : IAlquilable, IReciclable
{
    public void SeAlquilaA(Persona p)
    {
        Console.WriteLine("Alquilando libro a persona");
    }

    public void Reciclar()
    {
        Console.WriteLine("Reciclando libro");
    }

    public void EsDevueltoPor(Persona p)
    {
        Console.WriteLine("Libro devuelto por persona");
    }


}

class Pelicula : IAlquilable
{
    public virtual void EsDevueltoPor(Persona p)
    {
        Console.WriteLine("Pelicula devuelta por persona");
    }

    public virtual void SeAlquilaA(Persona p)
    {
        Console.WriteLine("Alquilando pelicula a persona");
    }

}

class PeliculaClasica : Pelicula, IVendible
{
    public void SeVendeA(Persona p)
    {
        Console.WriteLine("Vendiendo pelicula clasica a persona");
    }
    public override void SeAlquilaA(Persona p)
    {
        Console.WriteLine("Alquilando pelicula clasica a persona");
    }
    public override void EsDevueltoPor(Persona p)
    {
        Console.WriteLine("Pelicula clasica devuelta por persona");
    }

}


class Perro : IVendible, IAtendible, ILavable, INombrable, IComparable
{
    public string Nombre { get; set; }

    public override string ToString()
    {
        return $"{Nombre} es un Perro";
    }
    public int CompareTo(object obj)
    {
        string st1 = this.Nombre;
        string st2 = (obj as INombrable).Nombre;
        return st1.CompareTo(st2);
    }
    public void Atender()
    {
        Console.WriteLine("Atendiendo perro");
    }

    public void Lavar()
    {
        Console.WriteLine("Lavando perro");
    }

    public void Secar()
    {
        Console.WriteLine("Secando perro");
    }

    public void SeVendeA(Persona p)
    {
        Console.WriteLine("Vendiendo perro a persona");
    }
}

interface IComercial //Ejercicio 3
{
    void Importa();
}

interface IImportante //Ejercicio 3
{
    void Importa();
}

interface INombrable
{
    string Nombre { get; set; }
}
interface IVendible
{
    void SeVendeA(Persona p);
}

interface IAtendible
{
    void Atender();
}

interface IAlquilable
{
    void SeAlquilaA(Persona p);
    void EsDevueltoPor(Persona p);
}

interface ILavable
{
    void Lavar();
    void Secar();
}

interface IReciclable
{
    void Reciclar();
}
}