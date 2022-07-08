namespace Destructores {
    class Program {
        static void Main(string[] args) {
            Persona persona = new("Cesar");
            persona.MostrarNombre();

            persona = null; // Aqui se ejecuta el destructor, porque el objeto perdio la referencia
        }
    }

    class Persona {
        public string Nombre { get; set; }

        public Persona(string nombre) {
            Nombre = nombre;
        }

        public void MostrarNombre() {
            Console.WriteLine($"Hola me llamo {Nombre}");
        }
        
        // Creamos el destructor de nuestra clase
        ~Persona () {
            Nombre = "";
        }
    }
}