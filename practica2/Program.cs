using System;

namespace practica2
{
    class Program
    {
        //     static void Main(string[] args)
        //     {
        //     //EJERCICIO 14
        //     //Implementar un programa que muestre todos los números primos entre 1 y un número natural dado (pasado al programa como argumento
        //     //por la línea de comandos). Definir el método static bool esPrimo(int n) que devuelve true sólo si n es primo. 
        //         
        //     //Pasé como argumento el numero 100 
        //         int num = int.Parse(args[0]);

        //         Console.WriteLine($"Numeros primos entre 1 y {num}: ");

        //         for (int i = 1; i < num; i++) {
        //             if (esPrimo(i)) Console.Write ($"{i,-3}");
        //         }


        //         Console.ReadKey();
        //     }


        //     // Comprueba si n es divisible entre 2 y la raiz cuadrada de n
        //     static bool esPrimo (int n) {

        //         int limite = (int) Math.Sqrt(n);

        //         for (int i = 2; i <= limite; i++) {

        //             if (n % i == 0) return false;
        //         }

        //         return true;
        //     }
        // }


        //     static void Main(string[] args)
        //     {
        //         //EJERCICIO 16
        //         //Escribir una función (método static int Fac(int n)) que calcule el factorial de un número n pasado al programa como parámetro 
        //         //por la línea de comandos. c) idem a b) pero 
        //         //con expression-bodied methods (Tip: utilizar el operador condicional ternario)

        //         //En args[1] pasé el número 10 para probar
        //         int num = int.Parse(args[1]);

        //         //a) Factorial con función no recursiva
        //         Console.WriteLine ($"Inciso A -> Factorial de {num} = {FacNoRecursivo(num)}");

        //         //b) Definiendo una función recursiva 
        //         Console.WriteLine ($"Inciso B -> Factorial de {num} = {FacRecursivo(num)}");

        //         //c) idem a b) pero con expression-bodied methods (Tip: utilizar el operador condicional ternario)
        //         Console.WriteLine ($"Inciso C -> Factorial de {num} = {FactorialC(num)}");

        //         Console.ReadKey();
        //     }

        //     static int FacNoRecursivo (int n) {
        //         int total = 1;
        //         for (int i = n; i > 0; i--) {
        //             total *= i;
        //         }
        //         return total;
        //     }

        //     static int FacRecursivo (int n) {
        //         if (n == 1) return n; 
        //         else {
        //             return n * FacRecursivo(n-1);
        //         }
        //     }
        //     static int FactorialC (int n) => (n == 1) ? n : n * FactorialC(n-1);

        // }

        static void Main(string[] args)
        {
        //EJERCICIO 17    
        //Ídem. al ejercicio 16.a) y 16.b) pero devolviendo el resultado en un parámetro de salida static void Fac(int n, out int f)    

        //Método no recursivo       
        int f; //En esta variable se guarda el resultado del factorial
        int num = int.Parse(args[1]);
        FacNoRecursivo(num, out f);
        Console.WriteLine ($"Factorial de {num} (método no recursivo) = {f}");

        //Método recursivo
        FacRecursivo(num, out f);
        Console.WriteLine ($"Factorial de {num} (método recursivo) = {f}");

        Console.ReadKey();

        }

        static void FacNoRecursivo(int n, out int f) {
            //Lo primero que se debe hacer es inicializar el parametro de salida f
            f = 1;
            for (int i = 1; i <= n; i++) {
                f *= i;
            } 
        }

        static void FacRecursivo(int n, out int f) {
            if (n == 1) {
                f = n ;
            } else {
                FacRecursivo(n-1, out f);
                f *= n; 
            }
        }

    }
}    
