/* Lambdas :
    Las expresiones lambda son funciones anonimas que se usan para ejecutar funciones
    que no necesitan ser nombradas ademas de que tambien nos permiten simplificar
    mucho el codigo que desarrollamos. Este tipo de expresiones se usan principalmente 
    para crear delegados sencillos, para expresiones LINQ query, etc.*/

namespace DPyL {
    public class Lambdas {
        public delegate double Operaciones1(double numero);
        public delegate double Operaciones2(double numero1, double numero2);

        public delegate bool EncontrarLeon(Animal animal);

        public static void Run() {
            /*----- PARTE 1 -----*/
            Operaciones1 operacion1 = new Operaciones1(Cuadrado);
            Console.WriteLine($"El cuadrado de 4 es: {operacion1(4)}");

            // Otra forma de usar una expresion lambda
            operacion1 = new Operaciones1(num => num * num);
            Console.WriteLine($"El cuadrado de 5 es: {operacion1(5)}");

            Operaciones2 operacion2 = new Operaciones2((num1, num2) => num1 + num2);
            Console.WriteLine($"La suma de 12 y 7 es: {operacion2(12, 7)}");


            /*----- PARTE 2 -----*/
            List<int> numeros = new List<int>();
            numeros.AddRange(new int[] {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20
            });

            // Usamos una expresion lambda para sustituir al predicado
            List<int> pares = numeros.FindAll(num => num % 2 == 0);

            // Tambien aqui podemos usar una expresion lambda
            pares.ForEach(num => {
                Console.Write(num + " - ");
            });


            /*----- PARTE 3 -----*/
            Animal animal1 = new Animal() { Nombre = "Rambo", Edad = 4, Raza = "Perro" };
            Animal animal2 = new Animal() { Nombre = "Michi", Edad = 2, Raza = "Gato" };
            Animal animal3 = new Animal() { Nombre = "Alex", Edad = 7, Raza = "Leon" };

            List<Animal> animales = new List<Animal>() { animal1, animal2, animal3 };

            Console.WriteLine("\n");
            animales.ForEach(animal => {
                EncontrarLeon encontrar = animal => animal.Raza == "Leon";
                Console.WriteLine((encontrar(animal))? $"{animal.Nombre} SI es un Leon" : $"{animal.Nombre} NO es un Leon");
            });
        }

        /* Esta es una expresion lambda la cual nos ahorra tener que definir el cuerpo
         de la funcion y ademas nos evitamos el return*/
        public static double Cuadrado(double num) => num * num;
    }

    public class Animal {
        private string _nombre;
        private int _edad;
        private string _raza;

        public string Nombre { get => _nombre; set => _nombre = value; }
        public int Edad { get => _edad; set => _edad = value; }
        public string Raza { get => _raza; set => _raza = value; }
    }
}