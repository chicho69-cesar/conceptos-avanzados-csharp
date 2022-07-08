namespace Interfaces {
    public class Interfaces {
        public static void Run() {
            Aviso aviso1 = new Aviso();
            aviso1.MostrarAviso();

            Aviso aviso2 = new Aviso("ITA", "Te informamos que has sido seleccionado como alumno de excelencia", "02/06/2022");
            aviso2.MostrarAviso();
        }
    }

    interface IAviso {
        void MostrarAviso();
        string GetMensaje();
    }

    class Aviso : IAviso {
        public string remitente;
        public string mensaje;
        public string fecha;

        public Aviso() {
            this.remitente = "DGT";
            this.fecha = "09/05/2022";
            this.mensaje = $"Avisamos ({this.remitente}) que a partir de {this.fecha} " +
                $"ya no pasaran las rutas por arriba del puente";
        }

        public Aviso(string remitente, string mensaje, string fecha) {
            this.remitente = remitente;
            this.mensaje = mensaje;
            this.fecha = fecha;
        }

        public void MostrarAviso() {
            Console.WriteLine(GetMensaje());
        }

        public string GetMensaje() => this.mensaje;
    }
}