using System;

namespace practica8Ej7
{
    class Program
    {
        static void Main(string[] args)
        {
            ContadorDeLineas contador = new ContadorDeLineas();
            contador.Contar();
            Console.ReadKey();
        }
    }


    class ContadorDeLineas
    {
        private int _cantLineas = 0;
        public void Contar()
        {
            Ingresador _ingresador = new Ingresador();

            //La clase ContadorDeLineas se suscribe al evento LineaNueva del objeto _ingresador
            _ingresador.LineaNueva += UnaLineaMas;

            _ingresador.Ingresar();

            Console.WriteLine($"Cantidad de líneas ingresadas: {_cantLineas}");
        }

        //Manejador del evento
        public void UnaLineaMas(object sender, EventArgs e) => _cantLineas++;
    }

    class Ingresador
    {
        private EventHandler _LineaNueva;
        public event EventHandler LineaNueva 
        {
            add 
            {
                _LineaNueva += value;
            }
            remove 
            {
                _LineaNueva -=value;
            }

        }

        public void Ingresar()
        {
            string st = Console.ReadLine();
            while (st != "")
            {

                //Si no tiene suscriptores, el evento no se produce
                if (_LineaNueva != null) 
                {
                    _LineaNueva(this, new EventArgs()); //Se produce el evento invocando a la lista de métodos encolados en el delegado
                }

                st = Console.ReadLine();
            }
        }
    }
}
