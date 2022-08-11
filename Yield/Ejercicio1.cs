namespace Yield {
    public class Ejercicio1 {
        public static void Run() {
            List<Coche> coches = new List<Coche>() {
                new Coche { Marca = MarcaCoche.Audi, Modelo = "A1" },
                new Coche { Marca = MarcaCoche.Audi, Modelo = "A2" },
                new Coche { Marca = MarcaCoche.Ferrari, Modelo = "Furia" },
                new Coche { Marca = MarcaCoche.Lamborghini, Modelo = "Diablo" }
            };

            foreach (string modelo in FiltrarCoches(coches)) {
                Console.WriteLine($"El modelo del coche es: { modelo }");
            }
        }

        public static IEnumerable<string> FiltrarCoches(List<Coche> coches) {
            foreach (var coche in coches) {
                if (coche.Marca == MarcaCoche.Audi) {
                    /*Con yield lo que sucede es que va a estar recorriendo
                    los elementos de la lista y cada que uno cumpla con la condicion
                    lo va a regresar y una vez que el recurso que lo solicito
                    lo utilice se va a volver a ejecutar el metodo si es que siguen
                    habiendo mas elementos que pueden cumplir con la condicion*/
                    yield return coche.Modelo;
                }
            }
        }
    }

    public enum MarcaCoche {
        Audi, Ferrari, Lamborghini, Tesla
    }

    public class Coche {
        public MarcaCoche Marca { get; set; }
        public string Modelo { get; set; }
    }
}