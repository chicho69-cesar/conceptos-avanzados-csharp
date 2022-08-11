/*Hilo.- Un hilo en programacion se considera como una operacion
asincrona, donde podemos tener direferentes hilos que lo que hacen
es que cada uno va realizando trabajos simultaneamente al hilo
principal, el cual es el flujo principal y los hilos son flujos
secundarios que se ejecutan paralelamente*/

using System.Threading;

namespace Threads {
    public class Program {
        public static void Main(string[] args) {
            // Run();
            Thread6.Run();
        }

        public static void Run() {
            /*Creamos un hilo de ejecucion paralelo al hilo principal
             el cual se crea mediante la clase Thread*/
            Thread hilo = new Thread(() => {
                Console.WriteLine("Hola Mundo desde hilo 1");
                Thread.Sleep(1000); // Durmimos el hilo principal 1 segundo

                Console.WriteLine("Hola Mundo desde hilo 1");
                Thread.Sleep(1000);

                Console.WriteLine("Hola Mundo desde hilo 1");
                Thread.Sleep(1000);

                Console.WriteLine("Hola Mundo desde hilo 1");
                Thread.Sleep(1000);

                Console.WriteLine("Hola Mundo desde hilo 1");
                Thread.Sleep(1000);
            });
            hilo.Start(); // Iniciamos el hilo de ejecucion

            // Creamos otro hilo de ejecucion mediante el metodo Saludo
            Thread hilo2 = new Thread(Saludo);
            hilo2.Start();

            Console.WriteLine("Hilo Principal uwu");
        }

        public static void Saludo() {
            Console.WriteLine("Hola Mundo desde hilo 2");
            Thread.Sleep(500); 

            Console.WriteLine("Hola Mundo desde hilo 2");
            Thread.Sleep(500);

            Console.WriteLine("Hola Mundo desde hilo 2");
            Thread.Sleep(500);

            Console.WriteLine("Hola Mundo desde hilo 2");
            Thread.Sleep(500);

            Console.WriteLine("Hola Mundo desde hilo 2");
            Thread.Sleep(500);
        }
    }
}