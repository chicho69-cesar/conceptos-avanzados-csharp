/*Sincronizacion: La sincronizacion de hilos nos ayuda a que diferentes
hilos se pueden sincronizar y por ende ejecutarse conjuntamente ambos
de manera sincronizada, cuando hablamos de manera sincronizada nos
referimos a que se ejecutan los comandos del primer hilo sincronizado
y despues los de los siguientes, para esto usamos el metodo Join()*/

namespace Threads {
    public class Thread2 {
        public static void Run() {
            Thread h1 = new Thread(() => {
                Console.WriteLine("Hola Mundo hilo1");
                Thread.Sleep(500);
                Console.WriteLine("Hola Mundo hilo1");
                Thread.Sleep(500);
                Console.WriteLine("Hola Mundo hilo1");
                Thread.Sleep(500);
            });
            h1.Start();
            h1.Join(); // Sincronizamos los hilos

            Thread h2 = new Thread(() => {
                Console.WriteLine("Hola Mundo hilo2");
                Thread.Sleep(500);
                Console.WriteLine("Hola Mundo hilo2");
                Thread.Sleep(500);
                Console.WriteLine("Hola Mundo hilo2");
                Thread.Sleep(500);
            });
            h2.Start();
            h2.Join();
        }
    }
}