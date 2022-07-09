/*Ejercicio: Crear los metodos Map y Filter de JavaScript, 
en C# con Pipes, utilizando listas*/

var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

var filter = numbers
    .Filter((List<int> list) => {
        List<int> result = new();

        for (int i = 0; i < list.Count; i++) {
            if (list[i] % 2 == 0) {
                result.Add(numbers[i]);
            }
        }

        return result;
    });

var map = numbers
    .Map((List<int> list) => {
        List<int> result = new();

        for (int i = 0; i < list.Count; i++) {
            result.Add(numbers[i] * 2);
        }

        return result;
    });

Console.WriteLine("FILTER");
foreach (var number in filter) {
    Console.WriteLine(number);
}

Console.WriteLine("\nMAP");
foreach (var number in map) {
    Console.WriteLine(number);
}

public static class Methos {
    public static TOut Map<TIn, TOut>(this TIn value, Func<TIn, TOut> fnOut)
        where TIn : class
        where TOut : class 
    {
        if (value is null)
            return null;

        return fnOut(value);
    }

    public static TOut Filter<TIn, TOut>(this TIn value, Func<TIn, TOut> fnOut)
        where TIn : class
        where TOut : class {
        if (value is null)
            return null;

        return fnOut(value);
    }
}