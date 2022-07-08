/*Task: Es parecido a una promesa en JavaScript, solo que en C# como es un
lenguaje multihilo estas promesas no se realizan de manera paralelo en un solo
hilo como en JavaScript, sino que cada una de estas promesas o Tasks se realizan
en hilos secundarios, podriamos decir que un hilo es el medio mediante el
cual la promesa se cumple.*/

namespace Tasks {
    public class Program {
        public static async Task Main() {
            var tarea1 = new Task(() => {
                Thread.Sleep(1000);
                Console.WriteLine("La tarea interna 1 del task");
            });
            tarea1.Start();

            var tarea2 = new Task(() => {
                Thread.Sleep(1000);
                Console.WriteLine("La tarea interna 2 del task");
            });
            tarea2.Start();

            Console.WriteLine("Hago algo mas mientras hacemos las tareas");

            await tarea1; // Esperamos a la tarea 1
            await tarea2;

            // Esperamos el resultado del metodo asincrono
            Console.WriteLine($"\nEl resultado es: {await RandomAsync(100)}\n");

            Console.WriteLine("Ha terminado la tarea");
            Console.ReadLine();

            // Task1.Run();
            // Task2.Init();
            // Task3.Run();
            // Task4.Run();
            // Task5.Run();
        }

        /*Creamos un metodo para obtener un numero aleatorio de manera
        asincrona*/
        public static async Task<int> RandomAsync(int limite) {
            var tarea = new Task<int>(() => (new Random()).Next(limite));
            tarea.Start();

            int resultado = await tarea;

            return resultado;
        }
    }
}