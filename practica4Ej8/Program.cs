using System;

namespace practica4Ej8
{
    class Program
    {
        static void Main(string[] args)
        {
            Matriz A = new Matriz(2, 3);
            for (int i = 0; i < 6; i++) A.SetElemento(i / 3, i % 3, (i + 1) / 3.0);
            Console.WriteLine("Impresión de la matriz A");
            A.Imprimir("0.000");
            double[,] aux = new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Matriz B = new Matriz(aux);
            Console.WriteLine("\nImpresión de la matriz B");
            B.Imprimir();
            Console.WriteLine("\nAcceso al elemento B[1,2]={0}", B.GetElemento(1, 2));
            Console.Write("\nfila 1 de A: ");
            foreach (double d in A.GetFila(1)) Console.Write("{0:0.0} ", d);
            Console.Write("\n\nColumna 0 de B: ");
            foreach (double d in B.GetColumna(0)) Console.Write("{0} ", d);
            Console.Write("\n\nDiagonal principal de B: ");
            foreach (double d in B.GetDiagonalPrincipal()) Console.Write("{0} ", d);
            Console.Write("\n\nDiagonal secundaria de B: ");
            foreach (double d in B.GetDiagonalSecundaria()) Console.Write("{0} ", d);
            A.MultiplicarPor(B);
            Console.WriteLine("\n\nA multiplicado por B");
            A.Imprimir();
            Console.ReadKey();
        }
    }

    class Matriz
    {
        double[,] matriz;

        public Matriz(int filas, int columnas)
        {
            this.matriz = new double[filas, columnas];
        }

        public Matriz(double[,] matriz)
        {
            this.matriz = matriz;
        }

        public void SetElemento(int fila, int columna, double elemento)
        {
            this.matriz[fila, columna] = elemento;
        }

        public double GetElemento(int fila, int columna)
        {
            return this.matriz[fila, columna];
        }

        public void Imprimir()
        {
            for (int fila = 0; fila < this.matriz.GetLength(0); fila++)
            {
                for (int columna = 0; columna < this.matriz.GetLength(1); columna++)
                {
                    Console.Write($"{matriz[fila, columna]} ");
                }
                Console.WriteLine();
            }
        }

        public void Imprimir(string formatString)
        {
            for (int fila = 0; fila < this.matriz.GetLength(0); fila++)
            {
                for (int columna = 0; columna < this.matriz.GetLength(1); columna++)
                {
                    Console.Write($"{matriz[fila, columna].ToString(formatString)}  ");
                }
                Console.WriteLine();
            }
        }

        public double[] GetFila(int fila)
        {
            double[] elemFila = new double[matriz.GetLength(1)];
            for (int columna = 0; columna < matriz.GetLength(1); columna++)
            {
                elemFila[columna] = matriz[fila, columna];
            }
            return elemFila;
        }

        public double[] GetColumna(int columna)
        {
            double[] elemColum = new double[matriz.GetLength(0)];
            
            for (int fila = 0; fila < matriz.GetLength(0); fila++)
            {
                elemColum[columna] = matriz[fila, columna];
            }
            return elemColum;   
        }

        public double[] GetDiagonalPrincipal()
        {
            double [] elemsDiagPrincipal = new double[matriz.GetLength(0)];

            //Primero verifico que la matriz sea cuadrada. Sino no puedo obtener la diagonal principal
            if (matriz.GetLength(0) == matriz.GetLength(1)) 
            {
                for (int fila=0; fila < matriz.GetLength(0); fila++) 
                {
                    for (int columna=0; columna < matriz.GetLength(1); columna++)
                    {
                        if (fila == columna) elemsDiagPrincipal[fila] = matriz[fila, columna];
                    }
                }
                return elemsDiagPrincipal;
            }
            //Si la matriz no es cuadradada retorna null
            return null;
        }

        public double[] GetDiagonalSecundaria()
        {
            double [] elemsDiagSecundaria = new double[matriz.GetLength(0)];

            //Vefico que la matriz sea cuadrada
            if (matriz.GetLength(0) == matriz.GetLength(1)) 
            {
                //Si la suma de las posiciones de fila y columna es igual a "Condicion", el elemento es parte de la diagonal secundaria
                int condicion = matriz.GetLength(0) - 1; 

                for (int fila=0; fila < matriz.GetLength(0); fila++) 
                {
                    for (int columna=0; columna < matriz.GetLength(1); columna++)
                    {
                        if (fila + columna == condicion) elemsDiagSecundaria[fila] = matriz[fila, columna];
                    }
                }
                return elemsDiagSecundaria;
            }
            //Si la matriz no es cuadrada retorna null
            return null;
        }

        public void MultiplicarPor(Matriz m)
        {
            int cantFilas = matriz.GetLength(0);
            int cantColum = matriz.GetLength(1);

            double [,] resultado = new double [cantFilas, cantColum];

            for (int fila=0; fila < cantFilas; fila++) 
            {
                for (int columna=0; columna < cantColum; columna++)
                {
                    resultado[fila,columna]=0;

                    for (int i=0; i<=cantFilas; i++) 
                    {
                        double elem1 = m.GetElemento(i,columna);  
                        double elem2 = matriz[fila,i];
                        resultado[fila,columna] += elem1  * elem2;                      
                    }
                }    
            }
            this.matriz = resultado;    
        }

        public double[][] GetArregloDeArreglo() 
        {   
            double [][] arr = new double[matriz.GetLength(0)][];
            for (int fila = 0; fila < matriz.GetLength(0); fila++) 
            {
                arr[fila] = GetFila(fila);
            }
            return arr;
        }

        public void Sumarle(Matriz m) 
        {
            for (int fila=0; fila < matriz.GetLength(0); fila++) 
            {
                for (int columna=0; columna < matriz.GetLength(1); columna++)
                {
                    this.matriz[fila,columna] += m.GetElemento(fila,columna); 
                }
            }        
        }

        public void Restarle(Matriz m) 
        {
            for (int fila=0; fila < matriz.GetLength(0); fila++) 
            {
                for (int columna=0; columna < matriz.GetLength(1); columna++)
                {
                    this.matriz[fila,columna] -= m.GetElemento(fila,columna); 
                }
            }        
        }
    }
}
