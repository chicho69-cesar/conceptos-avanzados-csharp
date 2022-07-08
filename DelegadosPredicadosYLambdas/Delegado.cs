/* Delegados: 
    Los delegados son funciones que delegan tareas en otras funciones, son muy similares
    a los apuntadores o punteros de c++ ya que un delegado es una referencia a un metodo,
    en c# son muy usados para llamar a eventos en interfaces graficas, se redecu 
    significativamente el codigo al manejar diferentes escenarios y hacen el codigo muy reutilizable*/

namespace DPyL {
    public class Delegado {
        // Definicion del objeto delegado
        delegate void ObjetoDelegado();
        delegate void Delegate(string mensaje);

        public static void Run() {
            // Creamos un delegado el cual apunta al metodo saludo de la clase MensajeBienvenida
            ObjetoDelegado saludo1 = new ObjetoDelegado(MensajeBienvenida.Saludo);
            ObjetoDelegado saludo2 = new ObjetoDelegado(MensajeDespedida.Saludo);

            // Mandamos llamar a los metodos delegados
            saludo1();
            saludo2();

            // Apuntamos nuestro delegado a otro metodo
            saludo2 = new ObjetoDelegado(MensajeBienvenida.Saludo);
            saludo1 = new ObjetoDelegado(MensajeDespedida.Saludo);

            // Mandamos llamar a los metodos delegados
            saludo1();
            saludo2();

            // Creamos un delegado con parametros
            Delegate delegado = new Delegate(Mensaje.Saludo);
            delegado("\nJajajaja como estas");
        }
    }

    internal class MensajeBienvenida {
        public static void Saludo() {
            Console.WriteLine("Hola Mundo!!!");
        }
    }

    class MensajeDespedida {
        public static void Saludo() {
            Console.WriteLine("Bye Mundo!!!");
        }
    }

    class Mensaje {
        public static void Saludo(string mensaje) {
            Console.WriteLine(mensaje);
        }
    }
}