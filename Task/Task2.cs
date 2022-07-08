/*Tasks consecutivas: Estas tasks son tareas donde una se realiza solo
cuando otra tarea ya haya terminado las sentencias que tenia que llevar 
a cabo, es como si fueran hilos sincronizados.*/

namespace Tasks {
    public class Task2 {
        public static void Init() {
            /*Con el metodo Run lo que hacemos es que creamos un task que va
            a ser consecutiva con las Tasks que se declaren posteriormente*/
            Task tarea1 = Task.Run(() => RealizarTarea());
            
            /*Le decimos a la tarea 2 que se inicie hasta que la tarea 1
            ya se haya completado*/
            Task tarea2 = tarea1.ContinueWith(RealizarOtraTarea);

            Console.ReadLine();
        }

        public static void RealizarTarea() {
            for (int i = 0; i < 10; i++) {
                var hilo = Thread.CurrentThread.ManagedThreadId;
                Thread.Sleep(100);
                Console.WriteLine("Esta vuelta corresponde a " + hilo);
            }
        }

        public static void RealizarOtraTarea(Task obj) {
            for (int i = 0; i < 10; i++) {
                var hilo = Thread.CurrentThread.ManagedThreadId;
                Thread.Sleep(100);
                Console.WriteLine("Estas es otra tarea y esta vuelta corresponde a " + hilo);
            }
        }
    }
}