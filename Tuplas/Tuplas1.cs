namespace Tuplas {
    public class Tuplas1 {
        public static void Run() {
            /* Esta es la sintaxis basica de una tupla, donde podemos ver que se
             trata de una estructura de datos simple, la cual simplemente cuenta
             prodiamos decir con dos atributos */
            (int num1, int num2) tupla = (1, 2);

            Console.WriteLine(tupla);
            Console.WriteLine(tupla.num1);
            Console.WriteLine(tupla.num2);

            tupla.num1 = 5;
            tupla.num2 = 15;

            Console.WriteLine(tupla);
            Console.WriteLine(tupla.num1);
            Console.WriteLine(tupla.num2);
        }
    }
}