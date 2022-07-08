namespace Tasks {
    public class Task1 {
        public static void Run() {
            Task tarea1 = new Task(RealizarTarea); // Creamos nuestra tarea
            tarea1.Start(); // Iniciamos nuestra tarea

            Task tarea2 = new Task(RealizarTarea);
            tarea2.Start();

            Task tarea3 = new Task(() => {
                for (int i = 0; i < 100; i++) {
                    var hilo = Thread.CurrentThread.ManagedThreadId;
                    Thread.Sleep(100);
                    Console.WriteLine("Esta vuelta corresponde a " + hilo + " " +
                        "Ejecutandose desde el main");
                }
            });
            tarea3.Start();

            Console.ReadLine();
        }

        public static void RealizarTarea() {
            for (int i = 0; i < 100; i++) {
                var hilo = Thread.CurrentThread.ManagedThreadId;
                Thread.Sleep(100);
                Console.WriteLine("Esta vuelta corresponde a " + hilo);
            }
        }
    }
}