namespace LINQ {
    public class LINQ2 {
        public static void Run() {
            Control control = new Control();

            control.AgregarDatos();
            control.ObtenerProgramadores();
            control.EmpleadosOrdenados();
            control.EmpleadosGoogle();
            control.UsoLet();

            Console.Write("\nEscribe el id de la empresa a buscar sus empleados: ");
            string? empresa = Console.ReadLine();
            control.EmpleadosEmpresa(empresa);
        }
    }

    class Control {
        public List<Empresa> Empresas { get; set; }
        public List<Empleado> Empleados { get; set; }

        public Control() {
            Empresas = new List<Empresa>();
            Empleados = new List<Empleado>();
        }

        public void AgregarDatos() {
            Empresas.Add(new Empresa() { Id = 1, Name = "Google" });
            Empresas.Add(new Empresa() { Id = 2, Name = "Facebook" });
            Empresas.Add(new Empresa() { Id = 3, Name = "Microsoft" });

            Empleados.Add(new Empleado() { Id = 1, Name = "Cesar", Puesto = "Programador", Salary = 2500, EmpresaId = 1 });
            Empleados.Add(new Empleado() { Id = 2, Name = "Lucy", Puesto = "Programador", Salary = 2350, EmpresaId = 2 });
            Empleados.Add(new Empleado() { Id = 3, Name = "Karen", Puesto = "Diseñadora", Salary = 1500, EmpresaId = 1 });
            Empleados.Add(new Empleado() { Id = 4, Name = "Ana", Puesto = "Analista", Salary = 2500, EmpresaId = 3 });
            Empleados.Add(new Empleado() { Id = 5, Name = "Liz", Puesto = "Electronica", Salary = 1000, EmpresaId = 1 });
        }

        public void ObtenerProgramadores() {
            IEnumerable<Empleado> programadores = from empleado in Empleados where empleado.Puesto == "Programador" select empleado;

            Console.WriteLine("Programadores registrados: ");
            foreach (Empleado programador in programadores) {
                Console.Write("\t");
                programador.PrintInfo();
            }
        }

        public void EmpleadosOrdenados() {
            IEnumerable<Empleado> empleados = from empleado in Empleados orderby empleado.Name ascending select empleado;

            Console.WriteLine("\nEmpleados ordenados: ");
            foreach (Empleado empleado in empleados) {
                Console.Write("\t");
                empleado.PrintInfo();
            }
        }

        public void EmpleadosGoogle() {
            IEnumerable<Empleado> googleros = 
                from empleado in Empleados join empresa in Empresas 
                on empleado.EmpresaId equals empresa.Id
                where empresa.Name == "Google"
                select empleado;

            Console.WriteLine("\nEmpleados de google: ");
            foreach (Empleado empleado in googleros) {
                Console.Write("\t");
                empleado.PrintInfo();
            }
        }

        public void UsoLet() {
            List<string> nombres = (
                from empleado in Empleados
                let nombre = empleado.Name // Declaramos una variable interna
                select nombre // Seleccionamos la variable interna para la coleccion
            ).ToList();

            Console.WriteLine("\nNombres de los empleados: ");
            nombres.ForEach(nombre => {
                Console.WriteLine("\t" + nombre);
            });
        }

        public void EmpleadosEmpresa(string? nombre = "") {
            IEnumerable<Empresa> empresa = 
                from empresa1 in Empresas 
                where empresa1.Name == nombre 
                select empresa1;
            
            if (empresa.Count() == 0) {
                Console.WriteLine("\nNo existe la empresa {0}", nombre);
                return;
            }

            IEnumerable<Empleado> empleados = 
                from empleado in Empleados join empresa1 in Empresas
                on empleado.EmpresaId equals empresa1.Id
                where empresa1.Name == empresa.ElementAt(0).Name
                select empleado;

            Console.WriteLine("\nEmpleados de la empresa {0}: ", empresa.ElementAt(0).Name);
            foreach (Empleado empleado in empleados) {
                Console.Write("\t");
                empleado.PrintInfo();
            }
        }
    }

    class Empresa {
        public int Id { get; set; }
        public string? Name { get; set; }

        public void PrintInfo() {
            Console.WriteLine("Empresa {0} con Id {1}", Name, Id);
        }
    }

    class Empleado {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Puesto { get; set; }
        public double Salary { get; set; }
        public int EmpresaId { get; set; }

        public void PrintInfo() {
            Console.WriteLine(
                "Empleado {0} con Id {1}, Cargo {2}, " +
                "Salario ${3} y pertenece a la empresa {4}", 
                Name, Id, Puesto, Salary, EmpresaId
            );
        }
    }
}