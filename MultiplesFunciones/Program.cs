Func<int, int, int> fn = (int a, int b) => {
    Console.WriteLine("Ejecuta 1");
    return a * b;
};

fn += (int a, int b) => {
    Console.WriteLine("Ejecuta 2");
    return a + b;
};

fn += (int a, int b) => {
    Console.WriteLine("Ejecuta 3");
    return a - b;
};

var res = fn(15, 6);
Console.WriteLine("El resultado es {0}", res);