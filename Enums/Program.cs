namespace Enums {
    class Program {
        static void Main(string[] args) {
            Estaciones alergia = Estaciones.Primavera;
            Console.WriteLine(alergia);

            string valor = alergia.ToString();
            Console.WriteLine(valor);

            Empleado empleado = new Empleado();
            empleado.MostrarBonus();
        }
    }

    // Creamos nuestra enumeracion de las estaciones del año
    enum Estaciones {
        Primavera, Verano, Otoño, Invierno
    }

    class Empleado {
        // Podemos inicializar los valores de los enum
        enum Bonus {
            bajo = 100, normal = 500, bueno = 1000, extra = 2500
        }

        Bonus bonus = Bonus.bueno;

        public void MostrarBonus() {
            Console.WriteLine($"\nEl bonues de este empleado es: {(double)bonus:C2}");
        }
    }
}