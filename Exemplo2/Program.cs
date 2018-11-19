using System;

namespace Exemplo2
{
    static class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> motodoImprimir =
                ((Func<int, int>)Fibonacci)
                .Imprimir();

            motodoImprimir(9);

            Console.ReadKey();
        }
        
        static int Fibonacci(int numero)
            => numero == 0 ? 0 : numero == 1 ? 1
            : Fibonacci(numero - 1) + Fibonacci(numero - 2);

        static Func<T, TResultado> Imprimir<T, TResultado>(this Func<T, TResultado> funcao)
            => parametro =>
            {
                TResultado resultado = funcao(parametro);
                System.Console.WriteLine($"Parâmetro: {parametro}, Resultado: {resultado}");
                return resultado;
            };
    }
}
