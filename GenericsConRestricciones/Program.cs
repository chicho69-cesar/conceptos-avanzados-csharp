namespace GenericsConRestricciones {
    class Program {
        static void Main(string[] args) {
            AlmacenEmpleados<Director> directores = new AlmacenEmpleados<Director>(5);

            directores.Agregar(new Director(2500));
            directores.Agregar(new Director(5000));
            directores.Agregar(new Director(2750));

            Console.WriteLine(directores);
        }
    }

    interface IEmpleados {
        decimal GetSalario();
    }

    /* Clase generia con restricciones, es una clase donde los tipos de datos
    genericos deben forzadamente emplear la interfaz IEmpleados */
    class AlmacenEmpleados<T> where T : IEmpleados {
        private int count = 0;
        private T[] empleados;

        public AlmacenEmpleados(int num) {
            empleados = new T[num];
        }

        public void Agregar(T obj) {
            empleados[count++] = obj;
        }

        public T Get(int i) {
            return empleados[i];
        }
    }

    class Director : IEmpleados {
        public decimal salario;

        public Director(decimal salario) {
            this.salario = salario;
        }

        public decimal GetSalario() => this.salario;
    }

    class Secretaria : IEmpleados {
        public decimal salario;

        public Secretaria(decimal salario) {
            this.salario = salario;
        }

        public decimal GetSalario() => this.salario;
    }

    class Electricista : IEmpleados {
        public decimal salario;

        public Electricista(decimal salario) {
            this.salario = salario;
        }

        public decimal GetSalario() => this.salario;
    }
}