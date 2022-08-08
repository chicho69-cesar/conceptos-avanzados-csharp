namespace ExcepcionesPersonalizadas;

public class Program {
    public static void Main(string[] args) {
        int x = 11;

        try {
            Test(x);
        } catch (PersonalException e) {
            Console.WriteLine(e.Message);
        }
    }

    public static void Test(int x) {
        if (x % 2 == 0) {
            Console.WriteLine("El numero es par");
        } else {
            throw new PersonalException("El numero no es par bro :(");
        }
    }
}

public class PersonalException : Exception {
    public PersonalException() { }
    public PersonalException(string message) : base(message) { }
}