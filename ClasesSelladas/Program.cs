namespace Interfaces {
    class Program {
        static void Main(string[] args) {
            Caballo caballo = new("Spirit");
            IMamiferoTerrestre iCaballo1 = caballo;
            ISaltoConPatas iCaballo2 = caballo;

            caballo.Galopar();
            caballo.Comer();
            Console.WriteLine($"El caballo tiene {iCaballo1.NumeroPatas()} patas");
            Console.WriteLine($"El caballo salta con {iCaballo2.NumeroPatas()} patas");

            Ballena ballena = new("Mobie Dick");
            ballena.Nadar();

            Console.WriteLine("\n\n\n\n");

            // Interfaces.Run();
        }
    }

    interface IMamiferoTerrestre {
        int NumeroPatas();
    }

    interface IAnimalesYDeportes {
        string TipoDeporte();
        bool EsOlimpico();
    }

    interface ISaltoConPatas {
        int NumeroPatas();
    }

    class Mamifero {
        protected string nombre = "";

        public Mamifero(string nombre) {
            this.nombre = nombre;
        }

        public void Respirar() {
            Console.WriteLine("Estoy pensando");
        }

        public virtual void Comer() {
            Console.WriteLine("Estoy comiendo");
        }

        public void Pensar() {
            Console.WriteLine("Estoy pensando");
        }
    }

    class Caballo : Mamifero, IMamiferoTerrestre, IAnimalesYDeportes, ISaltoConPatas {
        public Caballo(string nombre) : base(nombre) { }

        public override void Comer() {
            Console.WriteLine("Estoy comiendo pasto");
        }

        public void Galopar() {
            Console.WriteLine("Estoy galopando");
        }

        int IMamiferoTerrestre.NumeroPatas() {
            return 4;
        }

        int ISaltoConPatas.NumeroPatas() {
            return 2;
        }

        public string TipoDeporte() {
            return "Hipica";
        }

        public bool EsOlimpico() {
            return true;
        }
    }

    class Gorilla : Mamifero, IMamiferoTerrestre {
        public Gorilla(string nombre) : base(nombre) { }

        public override void Comer() {
            Console.WriteLine("Estoy comiendo bananas");
        }

        public void Trepar() {
            Console.WriteLine("Estoy trepando un arbol");
        }

        public int NumeroPatas() {
            return 2;
        }
    }

    class Humano : Mamifero, IAnimalesYDeportes {
        public Humano(string nombre) : base(nombre) { }

        public override void Comer() {
            Console.WriteLine("Estoy comiendo comida");
        }

        public void Trabajar() {
            Console.WriteLine("Estoy trabajando");
        }

        public string TipoDeporte() {
            return "Futbol";
        }

        public bool EsOlimpico() {
            return true;
        }
    }

    class Ballena : Mamifero {
        public Ballena(string nombre) : base(nombre) { }

        public override void Comer() {
            Console.WriteLine("Estoy comiendo comida marina");
        }

        public void Nadar() {
            Console.WriteLine("Estoy nadando");
        }
    }


    /* Las clases selladas impiden que se puedan heredar mas clases de ellas
    es decir son clases constantes que ademas impide que sus metodos sean 
    sobreescritos */
    sealed class Lagartija {
        string nombre = "Rango";
    }
}