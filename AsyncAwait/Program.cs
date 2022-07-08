namespace AsynAwait {
    public class Program {
        public static void Main() {
            Task.Run(async () => {
                Barman barman = new Barman();

                /*Ponemos a ejecutar este metodo y como es un metodo asincrono,
                este se va a estar ejecutando mientras seguimos ejecutando
                las demas acciones necesarias*/
                Task<bool> tarea = barman.CalientaSnack();
                
                barman.HacerCoctel();

                bool resultado = await tarea; // Nos esperamos a que la tarea termine
            }).GetAwaiter().GetResult();
        }
    }

    public class Barman {
        /*Establecemos nuestro metodo como un metodo asincrono
        con async el cual nos regresara una Task de tipo bool, el cual
        nos va a ayudar a verificar cuando la tarea se termine*/
        public async Task<bool> CalientaSnack() {
            Console.WriteLine("Mete el snack al horno");

            // Hacemos una peticion http para que este metodo tarde tiempo xd
            HttpClient cliente = new HttpClient();
            await cliente.GetAsync("https://www.facebook.com");

            Console.WriteLine("Saca el snack del horno");

            return true;
        }

        public void HacerCoctel() {
            Console.WriteLine("Comienza a hacer el coctel");
            Thread.Sleep(500);
            Console.WriteLine("Termina de hacer el coctel");
        }
    }
}