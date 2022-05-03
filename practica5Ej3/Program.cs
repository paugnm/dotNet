using System;
using System.Collections;

namespace practica5Ej3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cuenta c1 = new Cuenta();
            // c1.Depositar(100).Depositar(50).Extraer(120).Extraer(50);
            // Cuenta c2 = new Cuenta();
            // c2.Depositar(200).Depositar(800);
            // new Cuenta().Depositar(20).Extraer(20);
            // c2.Extraer(1000).Extraer(1);
            // Console.WriteLine("\nDETALLE");
            // Cuenta.ImprimirDetalle();
            new Cuenta();
            new Cuenta();
            ArrayList cuentas = Cuenta.GetCuentas;
            // se recuperó la lista de cuentas creadas
            (cuentas[0] as Cuenta).Depositar(50);
            // se depositó 50 en la primera cuenta de la lista devuelta
            cuentas.RemoveAt(0);
            Console.WriteLine(cuentas.Count);
            // se borró un elemento de la lista devuelta
            // pero la clase Cuenta sigue manteniendo todos
            // los datos "La cuenta id: 1 tiene 50 de saldo"
            cuentas = Cuenta.GetCuentas;
            Console.WriteLine(cuentas.Count);
            // se recupera nuevamente la lista de cuentas
            (cuentas[0] as Cuenta).Extraer(30);
            //se extrae 25 de la cuenta id: 1 que tenía 50 de saldo

            Console.ReadKey();
        }
    }

    class Cuenta
    {
        static int s_id = 0;
        static int s_totalDepositos = 0;
        static int s_totalExtracciones = 0;
        static int s_cantDepositos = 0;
        static int s_cantExtracciones = 0;
        static int s_extraccionesDenegadas = 0;
        static ArrayList cuentas = new ArrayList();
        //EJERCICIO 3: Reemplazar el método estático GetCuentas() del ejercicio anterior por una propiedad estática de sólo lectura. 
        public static ArrayList GetCuentas { get => (ArrayList)cuentas.Clone(); } 
        //Con el método Clone() guardo la referencia al Arraylist original. Las modificaciones internas que haga a las cuentas se van a ver en ambos pero si borro un elemento no se verá afectada la lista original
        int saldo;
        public Cuenta()
        {
            s_id++;
            saldo = 0;
            cuentas.Add(this);
            Console.WriteLine($"Se creó la cuenta Id={s_id}");
        }

        public Cuenta Depositar(int monto)
        {
            saldo += monto;
            s_cantDepositos++;
            s_totalDepositos += monto;
            Console.WriteLine($"Se deposito {monto} en la cuenta {s_id} (Saldo = {saldo})");
            return this;

        }

        public Cuenta Extraer(int monto)
        {
            if (monto <= saldo)
            {
                saldo -= monto;
                s_cantExtracciones++;
                s_totalExtracciones += monto;
                Console.WriteLine($"Se extrajo {monto} de la cuenta {s_id} (Saldo = {saldo})");
            }
            else
            {
                Console.WriteLine("Operación denegada - Saldo insuficiente");
                s_extraccionesDenegadas++;
            }
            return this;
        }

        public static void ImprimirDetalle()
        {
            Console.WriteLine($"CUENTAS CREADAS: {s_id}");
            Console.Write($"DEPÓSITOS: {s_cantDepositos,-20}");
            Console.WriteLine($"- Total depositado: {s_totalDepositos}");
            Console.Write($"EXTRACCIONES: {s_cantExtracciones,-17}");
            Console.WriteLine($"- Total extraido: {s_totalExtracciones}");
            Console.WriteLine("{0}{1}", "- Saldo:", s_totalDepositos - s_totalExtracciones);
            Console.WriteLine();
            Console.WriteLine($" * Se denegaron {s_extraccionesDenegadas} por falta de fondos");


        }
    }
}
