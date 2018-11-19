using System;
using System.Linq;

namespace Exemplo3
{
    class Program
    {
        static void Main(string[] args)
        {
            var resultado = Repositorio(3);

            Console.WriteLine(
                resultado.Match(
                    (existe) => existe.ToString(),
                    () => "Número não encontrado"
            ));

            Console.ReadKey();
        }

        static Option<int> Repositorio(int busca)
           => Enumerable.Range(0, 5).Where(c => c == busca)
           .FirstOrDefault();
    }

    public struct Option<T>
    {
        private readonly T _value;

        public bool IsNone => _value == null || _value.Equals(default(T));

        public bool IsSome => !IsNone;

        public Option(T value)
            => _value = value;

        public static Option<T> Some(T value)
            => new Option<T>(value);

        public static Option<T> None()
            => new Option<T>(default(T));

        public TResult Match<TResult>(Func<T, TResult> methodWhenSome, Func<TResult> methodWhenNone)
            => IsSome
            ? methodWhenSome(_value)
            : methodWhenNone();

        public static implicit operator Option<T>(T value)
            => Some(value);
    }
}
