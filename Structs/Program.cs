/* Las clases se almacenan en la memoria heap y las struct se almacenan 
 en la memoria stack, es decir, en la pila

 La principal diferencias es que la memoria heap almacena la informacion de
manera constante, mientras que el stack es una memoria dinamica que esta
cambiando durante la ejecucion del programa */

namespace Structs {
    class Program {
        static void Main(string[] args) {
            Persona persona = new Persona("Cesar");
            persona.MostrarInfo();
            persona.CambiarNombre("Alonso");
            persona.MostrarInfo();
        }
    }

    // Las estructuras se definen igual que una clase, tanto los atributos como los metodos

    /* Caracteristicas de las struct: 
     1.- No permite la declaracion de un constructor por defecto
     2.- El compilador no incia los campos, puedes iniciarlos en el constructor
     3.- No puede haber sobrecarga de constructores
     4.- No heredan de otras clases o estructuras pero si implementan interfaces
     5.- Son selladas sealed
     6.- Son usadas cuando necesitas trabajar con una cantidad elevada de datos
    en memoria
     7.- Cuando las instancias no deban cambiar, es decir, son inmutables
     8.- Cuando la instancia tenga un tamaño inferior a 16 bytes
     9.- Cuando no necesites combertir a objeto(boxing y unboxing) */
    struct Persona {
        string nombre;

        public Persona(string nombre) {
            this.nombre = nombre;
        }

        public void MostrarInfo() {
            Console.WriteLine("Hola soy " + nombre);
        }

        public void CambiarNombre(string nuevoNombre) {
            nombre = nuevoNombre;
        }
    }
}