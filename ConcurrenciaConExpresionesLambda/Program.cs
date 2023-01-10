using System.Diagnostics;

namespace ConcurrenciaConLambdas {
    class Program {
        static void Main(string[] args) {
            var watch = Stopwatch.StartNew();
            var tasks = new List<Task>();

            for (int i = 0; i < 100; i++) {
                tasks.Add(Task.Factory.StartNew(
                    async () => {
                        var client = new HttpClient();
                        var response = await client.GetAsync("https://jsonplaceholder.typicode.com/todos/" + i);
                        var result = await response.Content.ReadAsStringAsync();

                        Console.WriteLine(result);
                    }
                ));
            }

            Task.WaitAll(tasks.ToArray());
            watch.Stop();

            Console.WriteLine(watch.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
}