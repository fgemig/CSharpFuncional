using System;
using System.Collections.Generic;
using System.Linq;

namespace Exemplo1
{
    class Program
    {
        static void Main(string[] args)
        {
            GerarNumerosPares();

            Console.ReadKey();            
        }

        static void GerarNumerosPares()
        {
            var lista = Enumerable.Range(0, 10).ToList();

            Iterar(lista, c =>
            {
                if (c % 2 == 0)
                    Console.WriteLine(c);
            });
        }

        static void Iterar(List<int> numeros, Action<int> funcao)
        {
            foreach (var numero in numeros)
                funcao(numero);
        }
    }
}
