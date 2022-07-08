/*Pool de Threads (ThreadPool): Un pool de threads es un conjunto de threads
los cuales se utilizan para que a cada uno de los threads que componen
a dicho conjunto se le asigna una tarea para que la realice de manera
simultanea con las tareas que realizan los demas threads, y si quedan
tareas por realizar estas seran hechas cuando alguno de los threads 
ya termino con su tarea. Con esto optimizamos los recursos de nuestro
equipo de computo*/

namespace Threads {
    public class Thread5 {
        public static void Run() {
            /*Creamos 500 hilos de manera tradicional asignando
            a cada uno de los hilos una tarea determinada*/
            /*for (int i = 0; i < 500; i++) {
                Thread hilo = new Thread(EjecutarTarea);
                hilo.Start();
            }*/

            for (int i = 0; i < 500; i++) {
                // Creamos nuestro Threadpool
                ThreadPool.QueueUserWorkItem(EjecutarTarea, i);
            }

            Console.ReadLine();
        }

        // Para los threadpool debemos de pasar un objeto de estado
        public static void EjecutarTarea(Object stateInfo) {
            int numTarea = (int)stateInfo;

            Console.WriteLine($"El hilo n° {Thread.CurrentThread.ManagedThreadId} ha comenzado su tarea. -> {numTarea}");
            Thread.Sleep(1000);
            Console.WriteLine($"El hilo n° {Thread.CurrentThread.ManagedThreadId} ha terminado su tarea. -> {numTarea}");
        }
    }
}