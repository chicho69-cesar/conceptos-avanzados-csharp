using System.Text.RegularExpressions;

namespace ExpresionesRegulares {
    public class EjercicioRegex {
        public static void Run() {
            string texto = "Mi nombre es Cesar y mi numero de telefono es (+52)346-109-92-07 y mi codigo postal es 47216";

            string pattern = @"\+52|\+34"; // Buscamos telefonos de mexico o españa
            Regex regex = new Regex(pattern);
            Match match = regex.Match(texto);

            if (match.Success) Console.WriteLine("Si hay telefonos de mexico o de españa");
            else Console.WriteLine("No hay telefonos de mexico ni de españa");

            string email = "cesarvillalobosolmos.01@gmail.com";
            
            // Regex profesional para validar email
            regex = new Regex("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$");
            match = regex.Match(email);

            if (match.Success) Console.WriteLine("Email correcto");
            else Console.WriteLine("Email incorrecto");
        }
    }
}