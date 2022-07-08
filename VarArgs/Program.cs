/*Los varargs o argumentos variables son como su nombre nos los puede indicar
un tipo de argumentos especiales, los cuales al ser usados en un metodo
nos van a permitir que ese metodo recibe un cierto numero de argumentos al
momento de ser utilizado, es decir, cuando usemos ese metodo, podremos pasarle
uno, dos, cinco, treinta argumentos sin necesidad de sobrecargar dicho 
metodo para que reciba ese numero de argumentos*/

namespace VarArgs {
    public class Program {
        public static void Main(string[] args) {
            Metodo("Hola", "Mundo");
            Metodo("Como", "estas", "me", "llamo", "Cesar");

            Console.WriteLine("Primera suma: " + Suma(1, 2, 3, 4));
            Console.WriteLine("Segunda suma: " + Suma(5, 6, 7, 8, 9, 10));
            Console.WriteLine("Tercera suma: " + Suma(57, 81, 142, 493));
        }

        /*Creamos un metodo con numero de argumentos variables*/
        public static void Metodo(params string[] cadenas) {
            foreach (var c in cadenas) { // los argumentos se manejan como un arreglo
                Console.Write(c + " ");
            }

            Console.WriteLine();
        }

        public static int Suma(params int[] numeros) {
            int acumulador = 0;

            foreach (int numero in numeros) {
                acumulador += numero;
            }

            return acumulador;
        }
    }
}