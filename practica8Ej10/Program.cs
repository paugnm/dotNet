using System;

namespace practica8Ej10
{
    class Program
    {
        static void Main(string[] args)
        {
            Articulo a = new Articulo();
            a.PrecioCambiado += precioCambiado;
            a.Codigo = 1;
            a.Precio = 10;
            a.Precio = 12;
            a.Precio = 12;
            a.Precio = 14;
            Console.ReadKey();
        }
        public static void precioCambiado(object sender, PrecioCambiadoEventArgs e)
        {
            string texto = $"Artículo {e.Codigo} valía {e.PrecioAnterior}";
            texto += $" y ahora vale {e.PrecioNuevo}";
            Console.WriteLine(texto);
        }
    }

    delegate void PrecioCambiadoEventHandler(object sender, PrecioCambiadoEventArgs e);

    class PrecioCambiadoEventArgs
    {
        public int PrecioNuevo { get; set; }
        public int PrecioAnterior { get; set; }
        public int Codigo { get; set; }

    }
    class Articulo
    {
        private int _precio;

        public int Precio
        {
            get => _precio;
            set
            {
                if (_precio != value)
                {
                    if (_PrecioCambiado != null)
                    {
                        PrecioCambiadoEventArgs e = new PrecioCambiadoEventArgs();
                        e.PrecioAnterior = _precio;
                        e.PrecioNuevo = value;
                        e.Codigo = this.Codigo;
                        _PrecioCambiado(this, e);
                    }
                    _precio = value;
                }
            }
        }
        public int Codigo { get; set; }
        private PrecioCambiadoEventHandler _PrecioCambiado;
        public event PrecioCambiadoEventHandler PrecioCambiado
        {
            add
            {
                _PrecioCambiado += value;
            }
            remove
            {
                _PrecioCambiado -= value;
            }
        }
    }
}
