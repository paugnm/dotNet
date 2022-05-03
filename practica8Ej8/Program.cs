using System;

namespace practica8Ej8
{
    class Program
    {
        static void Main(string[] args)
        {
            Ingresador ingresador = new Ingresador();
            ingresador.LineaVaciaIngresada += (sender, e) =>
            { Console.WriteLine("Se ingresó una línea en blanco"); };
            ingresador.NroIngresado += (sender, e) =>
            { Console.WriteLine($"Se ingresó el número {e.Valor}"); };
            ingresador.Ingresar();
            Console.ReadKey();
        }
    }


    class NroIngresadoEventArgs
    {
        public int Valor { get; set; }
        public NroIngresadoEventArgs (int num) => Valor = num;
    }
    delegate void LineaVaciaEventHandler(object sender, EventArgs e);
    delegate void NroIngresadoEventHandler(object sender, NroIngresadoEventArgs e);
    class Ingresador
    {
        private LineaVaciaEventHandler _LineaVaciaIngresada;
        public event LineaVaciaEventHandler LineaVaciaIngresada
        {
            add
            {
                _LineaVaciaIngresada += value;
            }
            remove
            {
                _LineaVaciaIngresada -= value;
            }
        }

        private NroIngresadoEventHandler _NroIngresado;
        public event NroIngresadoEventHandler NroIngresado
        {
            add
            {
                _NroIngresado += value;
            }
            remove
            {
                _NroIngresado -= value;
            }
        }

        public void Ingresar()
        {
            string st = Console.ReadLine();
            while (st != "fin")
            {
                if (st == "")
                {
                    if (_LineaVaciaIngresada != null) _LineaVaciaIngresada(this, new EventArgs());
                    
                }
                if (int.TryParse(st, out int num)) {
                    if (_NroIngresado!= null) _NroIngresado(this, new NroIngresadoEventArgs(num));
                    
                }
                st = Console.ReadLine();
            }
        }
    }
}
