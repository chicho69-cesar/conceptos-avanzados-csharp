/* Delegados Predicados: 
    Estos son delegados que devuelven true y false, es decir bool o boolean, estos 
    sirven para muchas tareas diferentes. Muy utilizados para filtrar listas de valores
    comprobando si una condicion es cierta para un valor dado*/

namespace DPyL {
    public class DelegadosPredicados {
        public static void Run() {
            List<int> numeros = new List<int>();
            numeros.AddRange(new int[] { 
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 
            });

            // Creamos nuestro predicado
            Predicate<int> delegadoPredicado = new Predicate<int>(FiltrarPares);
            // Usamos el delegado predicado
            List<int> pares = numeros.FindAll(delegadoPredicado);

            // Imprimimos el resultado del predicado
            Console.WriteLine("Numeros pares");
            foreach (int i in pares) {
                Console.Write(i + " - ");
            }

            List<int> primos = numeros.FindAll(new Predicate<int>(FiltrarPrimos));
            Console.WriteLine("\n\nNumeros primos");
            foreach(int i in primos) {
                Console.Write(i + " - ");
            }
        }

        // Creamos la funcion para el delegado predicado para filtrar numeros pares
        static bool FiltrarPares(int num) {
            return (num % 2 == 0);
        }

        static bool FiltrarPrimos(int num) {
            int count = 0;
            for (int i = 1; i <= num; i++) {
                if (num % i == 0) count++;
            }
            return count <= 2;
        }
    }
}