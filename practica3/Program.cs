using System;
using System.Collections;
using System.Text;

namespace practica3
{
    class Program
    {
        // static void Main(string[] args)
        // {   
        //     //EJERCICIO 12
        //     //Utilizar la clase Queue (cola) para implementar un programa que realice el cifrado de un texto
        //     //aplicando la técnica de clave repetitiva. La técnica de clave repetitiva consiste en desplazar un
        //     //carácter una cantidad constante de acuerdo a la lista de valores que se encuentra en la clave. 

        //     //Creo un arreglo que guarde los 28 caracteres
        //     char [] tablaDeReferencia= "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ ".ToCharArray();
            
        //     //Creo la clave para cifrar y descifrar
        //     int [] clave = new int [] {5,3,9,7};
            
        //     Console.Write(">>Texto a cifrar: ");
        //     string texto = Console.ReadLine().ToUpper();
            
        //     cifrar (ref texto, clave, tablaDeReferencia);
        //     Console.WriteLine($"Texto cifrado: {texto}");

        //     descifrar (ref texto, clave, tablaDeReferencia);
        //     Console.WriteLine($"Texto descifrado: {texto.ToLower()}");

        //     Console.ReadKey();
        // }

        // static void cifrar (ref string texto, int [] numClave, char [] tablaDeReferencia) {
            
        //     Queue clave = encolarNumeros (numClave);
            
        //     StringBuilder textoAux = new StringBuilder(texto);
            
        //     for (int i = 0; i<textoAux.Length; i++ ) {
                
        //         int indice = Array.IndexOf(tablaDeReferencia, textoAux[i]);
             
        //         int valorClave = (int) clave.Dequeue();
                // clave.Enqueue(valorClave);  //Vuelvo a encolar el valor que saque para manterner el orden
                
        //         if (indice + valorClave < tablaDeReferencia.Length) {
        //             textoAux[i] = tablaDeReferencia [indice + valorClave]; 
        //         } else {
        //             textoAux[i] = tablaDeReferencia [indice + valorClave - tablaDeReferencia.Length];
        //         }

        //     }
        //     texto = textoAux.ToString();

        // }

        // static void descifrar (ref string texto, int [] numClave, char [] tablaDeReferencia) {
            
        //     StringBuilder textoAux = new StringBuilder(texto);

        //     Queue clave = encolarNumeros (numClave);
            
        //     for (int i = 0; i<textoAux.Length; i++ ) {
                
        //         int indice = Array.IndexOf(tablaDeReferencia, textoAux[i]);
             
        //         int valorClave = (int) clave.Dequeue();
        //         clave.Enqueue(valorClave);
                
        //         if (indice - valorClave >= 0) {
        //             textoAux[i] = tablaDeReferencia [indice - valorClave]; 
        //         } else {
        //             textoAux[i] = tablaDeReferencia [tablaDeReferencia.Length + indice - valorClave];
        //         }

        //     }
        //     texto = textoAux.ToString();
        // }

        // static Queue encolarNumeros (int[] num) {
            
        //     Queue clave = new Queue();

        //     foreach(int n in num) clave.Enqueue(n);

        //     return clave;
        // } 

        static void Main(string[] args)
        {   
            //EJERCICIO 14
            //Utilizar la clase Stack (pila) para implementar un programa que pase un número en base 10 a otra base realizando divisiones 
            //sucesivas. Por ejemplo para pasar 35 en base 10 a binario dividimos sucesivamente por dos hasta encontrar un cociente menor que
            //el divisor, luego el resultado se obtiene leyendo de abajo hacia arriba el cociente de la última división seguida por todos los 
            //restos.

            Stack pila = new Stack();
            
            Console.Write(">>Ingrese un numero en base 10: ");
            int num = int.Parse(Console.ReadLine());

            while (num >= 2) {
                pila.Push(num % 2);
                num = num / 2;
            }
            pila.Push(num);

            StringBuilder st = new StringBuilder();
            while (pila.Count > 0) {
                st.Append(pila.Pop());
            }

            int numBase2 = int.Parse(st.ToString()); 

            Console.WriteLine($"El numero en base 2 es: {numBase2}");

            Console.ReadKey();
        }
        
    }
}
