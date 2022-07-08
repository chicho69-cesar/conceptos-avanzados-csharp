namespace Tasks {
    public class Task3 {
        public static void Run() {
            RealizarTodasLasTareas();
            Console.ReadLine();
        }

        public static void RealizarTodasLasTareas() {
            var tarea1 = Task.Run(() => {
                RealizarTarea1();
            });

            tarea1.Wait(); // Esperamos a que la tarea1 termine

            var tarea2 = Task.Run(() => {
                RealizarTarea2();
            });

            /*Task.WaitAll(tarea1, tarea2); Esperamos a que terminen todas 
            las tareas que especificamos, para que las demas tareas inicien*/

            /*Task.WaitAny(tarea1, tarea2); Esperamos a que termine cualquiera
            de las que especifiquemos para que las demas incien, es decir, si
            la tarea1 termina, aunque la 2 aun no las demas comenzara con 
            su ejecucion*/

            tarea2.Wait(); // Esperamos a que la tarea2 termine

            var tarea3 = Task.Run(() => {
                RealizarTarea3();
            });
        }

        public static void RealizarTarea1() {
            for (int i = 0; i < 5; i++) {
                var hilo = Thread.CurrentThread.ManagedThreadId;
                Thread.Sleep(300);
                Console.WriteLine("Tarea 1.- Esta vuelta corresponde a " + hilo);
            }
        }

        public static void RealizarTarea2() {
            for (int i = 0; i < 5; i++) {
                var hilo = Thread.CurrentThread.ManagedThreadId;
                Thread.Sleep(200);
                Console.WriteLine("Tarea 2.- Esta vuelta corresponde a " + hilo);
            }
        }

        public static void RealizarTarea3() {
            for (int i = 0; i < 5; i++) {
                var hilo = Thread.CurrentThread.ManagedThreadId;
                Thread.Sleep(100);
                Console.WriteLine("Tarea 3.- Esta vuelta corresponde a " + hilo);
            }
        }
    }
}