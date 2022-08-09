namespace Tasks {
    class Program {
        static void Main() {
            var source = new CancellationTokenSource();
            var token = source.Token;

            // Creamos una coleccion de tareas asicronas
            Task[] tasks = new Task[3];
            tasks[0] = Task.Run(() => Request1(token));
            tasks[1] = Task.Run(Request2);
            tasks[2] = Task.Run(() => Request1(token));

            Console.WriteLine("I'm waiting for my request finished...\n");

            Thread.Sleep(500);
            source.Cancel();

            try {
                // Esperamos a que se completen todas las tareas
                Task.WaitAll(tasks);

                foreach (var task in tasks) {
                    Console.Write($"\n{ task.Id } { task.Status }");
                }
            } catch { }

            Console.WriteLine("\n\nAll tasks ended with exit :)");
        }

        public static void Request1(CancellationToken cancellation) {
            Thread.Sleep(4000);
            if (cancellation.IsCancellationRequested) return;
            Console.WriteLine("Request to service 1");
        }

        public static void Request2() {
            Thread.Sleep(2000);
            Console.WriteLine("Request to service 2");
        }
    }
}