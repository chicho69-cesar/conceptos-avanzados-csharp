namespace Clousures {
    class Program {
        static void Main() {
            Action fn = Execute(2);
            Some(fn);
            Some(fn);
        }

        static void Some(Action fn) {
            Console.WriteLine("\nInicio");
            fn();
            fn();
            fn();
            Console.WriteLine("Fin");
        }

        static Action Execute(int n) {
            int i = 0;
            Console.WriteLine("Hola me he inicializado");

            return () => {
                if (i < n) {
                    Console.WriteLine("Hola me ejecuto gg");
                } else {
                    Console.WriteLine("Hola ya no me ejecuto xd");
                }

                i++;
            };
        }
    }
}