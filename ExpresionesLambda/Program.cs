namespace ExpresionesLambda {
    class Program {
        static void Main() {
            // Expresion lambda que regresa un int y recibe un int
            Func<int, int> func = (number) => {
                return number * 2;
            };

            int result = func(5);
            Console.WriteLine(result);

            // Expresion lambda que recibe dos int y regresa un int
            Func<int, int, int> sum = (a, b) => a + b;
            Console.WriteLine(sum(4, 9));

            Func<int, int, int> max = (a, b) => {
                return a > b ? a : b;
            };
            Console.WriteLine(
                "El mayor elemento entre {0} y {1} es {2}", 
                10, 4, max(10, 4)
            );

            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Func<int, bool> getPairs = (number) => number % 2 == 0;

            var pairs = numbers.Where(n => getPairs(n));
            var inpairs = numbers.Where(n => n % 2 != 0);

            pairs.ToList().ForEach(e => Console.Write(e + " -> "));
            Console.WriteLine();
            inpairs.ToList().ForEach(e => Console.Write(e + " -> "));

            Action<int> print = (number) => Console.WriteLine(number);
            print(10);

            Action<List<int>> show = (numbers) => {
                foreach (var n in numbers) 
                    print(n);
            };
            show(numbers);



            // FUNCION DE ORDEN SUPERIOR
            // Siempre el ultimo parametro es el tipo de regreso
            Func<int, Func<int, int>, int> fnHighter = (number, fn) => {
                if (number > 100)
                    return fn(number);
                else
                    return number;
            };

            var res = fnHighter(600, n => n * 2);
            Console.WriteLine("El resultado de la funcion de orden superior es: " + res);
        }
    }
}