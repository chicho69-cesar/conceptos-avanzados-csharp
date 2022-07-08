/*Clase Parallel: Esta clase nos va a permitir trabaja con varias
tasks de manera sencilla, ahorrando y optimizando tiempos y recursos.
Para esto lo que hace es que crea multiples hilos para que cada uno
de ellos se encargue de llevar a cabo la tarea que queremos que realizen*/

namespace Tasks {
    public class Task4 {
        private static int acumulador = 0;

        public static void Run() {
            /*for (int i = 0; i < 100; i++) {
                RealizarTarea(i);
                Console.WriteLine($"Acumulador vale {acumulador}. Tarea realizada por {Thread.CurrentThread.ManagedThreadId}");
            }*/

            /*Sintaxis: For(Inicio, Fin, Metodo a realizar)*/
            //Parallel.For(0, 100, RealizarTarea);

            Parallel.For(0, 100, dato => {
                acumulador = dato % 2 == 0 ? acumulador + dato : acumulador - dato;
                Console.WriteLine($"Dato vale: {dato}, y amumulador vale {acumulador}");
            });
        }

        public static void RealizarTarea(int num) {
            if (acumulador % 2 == 0) {
                acumulador += num;
            } else {
                acumulador -= num;
            }

            Console.WriteLine($"Acumulador vale {acumulador}. Tarea realizada por {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(100);
        }
    }
}