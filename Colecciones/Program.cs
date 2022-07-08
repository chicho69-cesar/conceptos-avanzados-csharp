namespace Colecciones {
    class Program {
        static void Main(string[] args) {
            List<int> list = new List<int>(); // Creamos una coleccion de list de ints
            Queue<int> queue = new Queue<int>(); // Creamos una cola de ints
            Stack<int> stack = new Stack<int>(); // Creamos una pila de ints
            LinkedList<int> linkedList = new LinkedList<int>(); // Creamos una lista enlazada de ints
            HashSet<int> hash = new HashSet<int>(); // Creamos una tabla hash
            Dictionary<int, string> map = new Dictionary<int, string>(); // Creamos un diccionario de datos
            SortedList<int, string> sortedList = new SortedList<int, string>(); // Diccionario con elementos ordenados

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            list.ForEach(x => {
                Console.Write(x + " - ");
            });

            Console.WriteLine();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            while (queue.Count > 0) {
                Console.Write(queue.Dequeue() + " - ");
            }

            Console.WriteLine();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            while (stack.Count > 0) {
                Console.Write(stack.Pop() + " - ");
            }

            Console.WriteLine();

            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);
            linkedList.AddLast(4);
            linkedList.AddLast(5);
            
            foreach (var item in linkedList) {
                Console.Write(item + " - ");
            }
            linkedList.Clear();

            Console.WriteLine();

            hash.Add(1);
            hash.Add(2);
            hash.Add(3);
            hash.Add(4);
            hash.Add(5);

            foreach (var item in hash) {
                Console.Write(item + " - ");
            }
            hash.Clear();

            Console.WriteLine();

            map.Add(1, "Cesar");
            map.Add(2, "Karen");
            map.Add(3, "Liz");
            map.Add(4, "Lucy");
            map.Add(5, "Mariana");

            // Primera forma de recorrer un diccionario
            foreach (var item in map) {
                Console.Write(item + " - ");
            }

            Console.WriteLine();

            // Segunda forma de recorrer un diccionario con clave - valor
            foreach (KeyValuePair<int, string> persona in map) {
                Console.Write($"Key: {persona.Key}, Value: {persona.Value} - ");
            }

            map.Clear();

            Console.WriteLine();

            sortedList.Add(1, "Cesar");
            sortedList.Add(5, "Karen");
            sortedList.Add(4, "Liz");
            sortedList.Add(3, "Lucy");
            sortedList.Add(2, "Mariana");

            foreach (var item in sortedList) {
                Console.Write(item + " - ");
            }
            sortedList.Clear();
        }
    }
}