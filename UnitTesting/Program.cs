namespace UnitTesting {
    public class Program {
        static void Main(string[] args) {

        }

        public static string Algo() {
            return "Algo";
        }

        public static bool login(string user, string password) =>
            user == "chicho69" && password == "12345" ? true : false;

        public static bool EsPrimo(int numero) {
            int contador = 0;
            for (int i = 1; i <= numero; i++) 
                if (numero % i == 0) contador++;
            return contador <= 2;
        }
    }
}