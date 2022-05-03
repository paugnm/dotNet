using System;

namespace practica6Ej8
{
    class Program
    {
        static void Main(string[] args)
        {
            Empleado[] empleados = new Empleado[] {
                new Administrativo("Ana", 20000000, DateTime.Parse("26/4/2018"), 10000) {Premio=1000},
                new Vendedor("Diego", 30000000, DateTime.Parse("2/4/2010"), 10000) {Comision=2000},
                new Vendedor("Luis", 33333333, DateTime.Parse("30/12/2011"), 10000) {Comision=2000}
            };
            foreach (Empleado e in empleados)
            {
                Console.WriteLine(e);
                e.AumentarSalario();
                Console.WriteLine(e);
            }
            Console.ReadKey();
        }
    }

    abstract class Empleado
    {
        public string Nombre { get; }
        public int Dni { get; }
        public DateTime FechaDeIngreso { get; }
        public double SalarioBase {get; protected set; }
        public abstract double Salario { get; }
        public int Antiguedad {get => (new DateTime(2020, 4, 26) - FechaDeIngreso).Days/365;} //Devuelve los años de antiguedad del empleado

        public Empleado(string nombre, int Dni, DateTime ingreso, double salarioBase)
        {
            this.Nombre = nombre;
            this.Dni = Dni;
            this.FechaDeIngreso = ingreso;
            this.SalarioBase = salarioBase;
        }

        public override string ToString() {
            return $"Nombre: {Nombre}, DNI: {Dni}, Antigüedad: {Antiguedad} \nSalario Base: {SalarioBase}, Salario: {Salario}\n--------------------------------------------";
        }

        public abstract void AumentarSalario();

    }
    class Administrativo : Empleado
    {
        public double Premio { get; set; }

        public override double Salario { get => SalarioBase + Premio; }
        public Administrativo(string nombre, int Dni, DateTime ingreso, Double salarioBase) : base(nombre, Dni, ingreso, salarioBase) { }

        public override void AumentarSalario()
        {
            SalarioBase *= 1 + (0.01 * Antiguedad);
        }

        public override string ToString()
        {
            return "Administrativo " + base.ToString();
        }

    }

    class Vendedor : Empleado
    {
        public double Comision { get; set; }
        public override double Salario { get => SalarioBase + Comision; }
        public Vendedor(string nombre, int Dni, DateTime ingreso, Double salarioBase) : base(nombre, Dni, ingreso, salarioBase) { }

        public override void AumentarSalario()
        {
            if (Antiguedad < 10)
            {
                SalarioBase *= 1.05;
            }
            else
            {
                SalarioBase *= 1.1;
            }
        }

        public override string ToString()
        {
            return "Vendedor " + base.ToString();
        }

    }
}
