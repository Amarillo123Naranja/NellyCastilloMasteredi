using System;
using System.Runtime.Intrinsics.X86;

namespace Palindromo // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1, num2, mult;
            string lista;
            bool bandera = false;


            while (bandera == false)
            {
                Console.WriteLine("Ingrese un numero: ");
                num1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese un numero");
                num2 = int.Parse(Console.ReadLine());

                mult = num1 * num2;

                Console.WriteLine("El resultado es: " + mult);



                lista = Convert.ToString(mult);

                string aux = string.Empty;//se crea una lista vacia
                int i = lista.Length;
                for (int j = i - 1; j >= 0; j--)
                {
                    aux = aux + lista[j];
                }
                if (aux == lista)
                {
                    bandera = true;
                    Console.WriteLine(lista + " es palindromo");
                }
                else
                {
                    bandera = false;
                    Console.WriteLine(lista + " no es palindromo");

                }
                Console.WriteLine(aux);
            }
        }
    }

}

                