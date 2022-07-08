/*Cancelacion de Tasks: La cancelacion de tasks como su nombre se indica
nos ayuda a cancelar un tasks cuando algo en especial pasa en el programa*/

namespace Tasks {
    public class Task5 {
        static int acumulador = 0;

        public static void Run() {
            // Creamos un token de cancelacion
            CancellationTokenSource token = new CancellationTokenSource();
            CancellationToken cancelacion = token.Token;

            Task tarea = Task.Run(() => RealizarTara(cancelacion));

            for (int i = 0; i < 100; i++) {
                acumulador += (new Random()).Next(10);
                Thread.Sleep(100);

                if (acumulador > 100) {
                    token.Cancel(); // Cancelamos la tarea
                    break;
                }
            }

            Thread.Sleep(100);
            Console.WriteLine("El acumulador llego a: " + acumulador);

            Console.ReadLine();
        }

        public static void RealizarTara(CancellationToken cancelacion) {
            for (int i = 0; i < 100; i++) {
                acumulador++;

                var hilo = Thread.CurrentThread.ManagedThreadId;
                Thread.Sleep(100);

                Console.WriteLine("Tarea ejecutandose por el hilo " + hilo);
                Console.WriteLine("Acumulador: " + acumulador);

                // Verificamos si la tarea ya a sido cancelada
                if (cancelacion.IsCancellationRequested) {
                    return;
                }
            }
        }
    }
}