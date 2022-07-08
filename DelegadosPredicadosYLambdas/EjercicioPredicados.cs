namespace DPyL {
    public class EjercicioPredicados {
        public static void Run() {
            List<Persona> personas = new List<Persona>();

            personas.Add(new Persona() { Nombre = "Juan", Edad = 18});
            personas.Add(new Persona() { Nombre = "Cesar", Edad = 20});
            personas.Add(new Persona() { Nombre = "Lucy", Edad = 23});
            personas.Add(new Persona() { Nombre = "Ana", Edad = 21});
            personas.Add(new Persona() { Nombre = "Liz", Edad = 20});

            Predicate<Persona> predicado = new Predicate<Persona>(ExistePersona);

            bool existe = personas.Exists(predicado);

            if (existe) Console.WriteLine("Juan si esta en la lista");
            else Console.WriteLine("No hay nadie llamado Juan");
        }

        static bool ExistePersona(Persona persona) {
            return persona.Nombre.Equals("Juan");
        }
    }

    class Persona {
        private string _nombre;
        private int _edad;

        public string Nombre { get => _nombre; set => _nombre = value; }
        public int Edad { get => _edad; set => _edad = value; }
    }
}