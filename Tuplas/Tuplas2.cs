namespace Tuplas {
    public class Tuplas2 {
        public static void Run() {
            // Primera forma de definir una tupla
            (int, string) tupla1 = (20, "Cesar");
            Console.WriteLine(tupla1.Item1);
            Console.WriteLine(tupla1.Item2);

            // Podemos definir una tupla con var
            var tupla2 = (21, "Carolina");
            Console.WriteLine(tupla2.Item1);
            Console.WriteLine(tupla2.Item2);

            // Podemos agregar objetos a una tupla
            var tupla3 = (1, new Persona {
                Name = "Adrian",
                Age = 21
            });
            Console.WriteLine(tupla3.Item2.Age);
            Console.WriteLine(tupla3.Item2.Name);

            // Podemos definir un nombre a los elementos de la tupla
            var tupla4 = (age: 20, name: "Karen");
            Console.WriteLine(tupla4.age);
            Console.WriteLine(tupla4.name);

            // Creamos un objeto y usamos el metodo que regresa una tupla
            var objeto1 = new Persona {
                Age = 20,
                Name = "Thaily"
            };
            Console.WriteLine(objeto1.GetData().age);
            Console.WriteLine(objeto1.GetData().name);

            // Podemos usar la deconstruccion, pero tiene que tener el metodo Deconstruct
            var objeto2 = new Persona {
                Age = 20,
                Name = "Lizeth"
            };
            var (edad, nombre, _) = objeto2; // Deconstruimos el objeto ignorando el campo email
            Console.WriteLine(edad);
            Console.WriteLine(nombre);
        }
    }

    public class Persona {
        public int Age { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        // Podemos regresar una tupla en un metodo
        public (int age, string? name) GetData() => (Age, Name);

        /*Usamos la deconstruccion para obtener valores mas rapido
        mediante una tupla, cabe mencionar que este metodo se debe
        de llamar asi tal cual para que funcione*/
        public void Deconstruct(out int age, out string? name, out string? email) =>
            (age, name, email) = (Age, Name, Email);
    }
}