/*Tareas completadas: Como su nombre lo indica esta es una tecnica
que usamos cuando queremos que un hilo ejecute una accion hasta que
otro hilo haya completado esa u otra tarea diferente*/

namespace Threads {
    public class Thread4 {
        public static void Run() {
            /*Creamos nuestra tarea para determinar a que hora
            un determinado termina su tarea*/
            var tarea = new TaskCompletionSource<bool>();

            var hilo1 = new Thread(() => {
                for (int i = 0; i < 5; i++) {
                    Console.WriteLine("Hilo 1");
                    Thread.Sleep(500);
                }

                tarea.TrySetResult(true); // Le decimos que la tarea ya termino
            });

            var hilo2 = new Thread(() => {
                for (int i = 0; i < 5; i++) {
                    Console.WriteLine("Hilo 2");
                    Thread.Sleep(500);
                }
            });

            var hilo3 = new Thread(() => {
                for (int i = 0; i < 5; i++) {
                    Console.WriteLine("Hilo 3");
                    Thread.Sleep(500);
                }

                tarea.TrySetResult(true);
            });

            hilo1.Start();

            /*Hacemos que el siguiente hilo se ejecute hasta que el hilo1
            termine de hacer la tarea especificada*/
            var resultado = tarea.Task.Result;

            hilo2.Start();
            hilo3.Start();
        }
    }
}