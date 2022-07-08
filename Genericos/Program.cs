namespace Genericos {
    class Program {
        static void Main(string[] args) {
            Nodo<string> nodo1 = new Nodo<string>("Cesar");
            Nodo<int> nodo2 = new Nodo<int>(125);
            Nodo<bool> nodo3 = new Nodo<bool>(true);

            nodo1.MostrarValor();
            nodo2.MostrarValor();
            nodo3.MostrarValor();
        }
    }

    /* Creamos una clase que emplea valores genericos, es decir, los atributos
    que empléen el tipo de dato T, podra almacenar valores de datos indiferentes, 
    como por ejemplo strings, ints, doubles, bools, etc.*/
    class Nodo<T> {
        private T _value;
        public T Value { get => _value; set => _value = value; }

        public Nodo(T value) {
            Value = value;
        }

        public void MostrarValor() {
            Console.WriteLine(Value);
        }
    }
}