/*Ejercicio.- Implementar una función que recibe por parametro 
un IEnumerable<T> y un batch size. Esta tiene que dividir ese IEnumerable 
para devolver un IEnumerable<List<T>> donde cada uno de los List<T> 
es igual o menor que el batch size*/

namespace Yield {
    public static class Ejercicio2 {
        public static void Run() {
            IEnumerable<IEnumerable<int>> nums = new List<List<int>>() {
                new List<int> { 1, 2 },
                new List<int> { 3, 4 },
                new List<int> { 5 }
            };

            foreach (var result in nums.Batch(2)) {
                foreach (var item in result) {
                    foreach (var value in item) {
                        Console.WriteLine(value);
                    }
                }
            }
        }

        public static IEnumerable<List<T>> Batch<T>(this IEnumerable<T> enumerable, int batchCount) {
            using var enumerator = enumerable.GetEnumerator(); // Obtenemos la iteracion sobre la que va la enumeracion
            
            while (enumerator.MoveNext()) {
                List<T> result = new();
                var position = 0;

                do {
                    result.Add(enumerator.Current); // Agregamos la iteracion actual al resultado
                    position++;
                } while (position < batchCount && enumerator.MoveNext());

                yield return result;
            }
        }
    }
}