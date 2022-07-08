using System;

namespace ClasesAnonimas {
    class Program {
        static void Main(string[] args) {
            // Creamos un objeto anonimo en C# al igual que como se hace en JS
            var objeto1 = new {
                Name = "Cesar",
                Lastname = "Villalobos Olmos",
                Age = 20,
                Email = "cesarvillalobosolmos.01@gmail.com",
                Salary = 1500M
            };

            var objeto2 = new {
                Name = "Liz",
                Lastname = "Sandoval Vallejo",
                Age = 20,
                Email = "lichasv1101@gmail.com",
                Salary = 1225M
            };

            // objeto1 = objeto2; Solo podemos hacer esto cuando los tipos de datos
            // y los campos deben de ser los mismos

            Console.WriteLine(objeto1);
            Console.WriteLine(objeto1.Name);
            Console.WriteLine(objeto1.Lastname);
            Console.WriteLine(objeto1.Age);
            Console.WriteLine(objeto1.Email);
            Console.WriteLine(objeto1.Salary);
        }
    }
}