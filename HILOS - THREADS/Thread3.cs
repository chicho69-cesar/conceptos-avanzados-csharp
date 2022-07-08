/*Bloqueos: Los bloqueos se utilizan cuando queremos que una parte
de nuestro codigo se bloquée mientras otro hilo este ejecutando esa
parte del codigo, de esta manera evitamos que distintos hilos
ejecuten ese codigo de manera simultanea*/

namespace Threads {
    public class Thread3 {
        public static void Run() {
            CuentaBancaria cuenta = new CuentaBancaria(2000);

            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < 15; i++) {
                Thread t = new Thread(cuenta.Retirar);
                t.Name = $"{i + 1}";
                threads.Add(t);
            }

            for (int i = 0; i < 15; i++) {
                threads[i].Start();
                threads[i].Join();
            }
        }
    }

    class CuentaBancaria {
        private Object bloqueo = new Object();
        public double Saldo { get; set; }

        public CuentaBancaria(double saldo) {
            Saldo = saldo;
        }

        public double RetirarDinero(double cantidad) {
            if (Saldo - cantidad < 0) {
                Console.WriteLine(
                    $"Lo siento le quedan {Saldo:C2} en su cuenta" +
                    $"\tHilo: {Thread.CurrentThread.Name}"
                );

                return Saldo;
            } 
            
            lock(bloqueo) { /*Aqui lo que estamos haciendo es que
            estamos bloqueando este trozo de codigo para que cuando
            un hilo lo este ejecutando los demas se queden esperando
            hasta que dicho hilo termine y de esta manera evitar
            que varios hilos lo ejecuten al mismo tiempo*/
                if (Saldo >= cantidad) {
                    Console.WriteLine(
                        $"Se retiraron {cantidad:C2} de su cuenta" +
                        $"\tHilo: {Thread.CurrentThread.Name}"
                    );

                    Saldo -= cantidad;
                }

                return Saldo;
            }
        }

        public void Retirar() {
            RetirarDinero(500);
        }
    }
}