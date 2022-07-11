/* Memoization: Es un proceso de optimizacion que tiene la informatica, 
donde te ayuda a ahorrarte calculos, este concepto esta muy ligado
al concepto de funcion pura.

    Funcion pura: Una funcion pura tiene dos propiedades, si tu metes
    un grupo de parametros, y este grupo siempre es el mismo el 
    resultado no tiene porque cambiar, la segunda propiedad es que
    una funcion pura no tiene efectos colaterales o cambios en efectos
    externos a la funcion, si tu recibes un objeto este objeto no debe
    de ser mutado, si vas a hacer un cambio debes de crear un nuevo
    objeto y regresar ese nuevo objeto

Aqui la memoization nos ayuda a que si tienes una funcion pura, es 
recomendable ahorrarte ese calculo guardandolo en la memoria cache
para poder acceder al resultado desde esa cache y optimizar el proceso
para reducir tiempo y ahorrarte ese tiempo*/

using System.Collections.Concurrent;
using System.Diagnostics;

namespace MemoizatedProject {
    static class Program {
        static void Main() {
            Func<long, long> factorial = null;
            factorial = (num) 
                => num > 1 ? num * factorial(num - 1) : 1;


            // NORMAL
            var stopWatch1 = Stopwatch.StartNew();

            for (int i = 1; i <= 1_000_000; i++)
                factorial(9);

            Console.WriteLine(stopWatch1.ElapsedMilliseconds);

            // MEMORIZADO
            var factorial2 = factorial.Memoize();
            var stopWatch2 = Stopwatch.StartNew();

            for (int i = 1; i <= 1_000_000; i++)
                factorial2(9);

            Console.WriteLine(stopWatch2.ElapsedMilliseconds);
        }

        public static Func<T, TResult> Memoize<T, TResult>(this Func<T, TResult> func) {
            var cache = new ConcurrentDictionary<T, TResult>();
            return (a) => cache.GetOrAdd(a, func);
        }
    }
}