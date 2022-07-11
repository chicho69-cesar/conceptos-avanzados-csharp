namespace TuplasProgramacionFuncional {
    class Program {
        static void Main() {
            // Execute1();
            Execute2();
        }

        public static void Execute1() {
            var counter = Counter();

            counter.increment();
            counter.increment();

            Console.WriteLine(counter.getState());

            counter.substract();

            Console.WriteLine(counter.getState());
        }

        public static void Execute2() {
            var beer = Beer();

            beer.Counter.increment();
            beer.Counter.increment();

            Console.WriteLine(beer.Counter.getState());

            beer.BeerDB.Add(10);
        }

        // Esto es composicion
        public static (
            (Action increment, Action substract, Func<int> getState) Counter,
            (Action<int> Add, Action<int> Update, Action<int> Delete) BeerDB
        ) Beer() {
            return (
                Counter(),
                BeerDB()
            );
        }

        public static (Action increment, Action substract, Func<int> getState) Counter() {
            int i = 0;

            void increment() => i++;
            Action substract = () => i--; // Es igual al de arriba
            Func<int> getState = () => i;

            return (increment, substract, getState);
        }

        public static (Action<int> Add, Action<int> Update, Action<int> Delete) BeerDB() {
            return (
                (num) => Console.WriteLine("Agregada " + num),
                (num) => Console.WriteLine("Editada " + num),
                (num) => Console.WriteLine("Eliminada " + num)
            );
        }
    }
}