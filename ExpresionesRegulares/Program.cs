/* Las expresiones regulares son secuencias de caracteres que funcionan como un 
 patron de busqueda dentro de una cadena de texto, esta busqueda puede incluir
cadenas de caracteres, letras, numeros, caracteres especiales, etc.
Las Regex como comunmente se llaman se pueden utitilizar en innumerables escenarios,
tales como: Validacion de formularios, busqueda en ficheros externos, busquedas en BBDD, 
comprobacion de entradas de texto de usuarios, etc.*/

using System.Text.RegularExpressions;

namespace ExpresionesRegulares {
    public class Program {
        static void Main(string[] args) {
            /*string texto = "Mi nombre es Cesar y mi numero de telefono es (+52)346-109-92-07 y mi codigo postal es 47216";

            string pattern1 = "[C]"; // Buscamos una C en el string
            Regex regex1 = new Regex(pattern1); // Creamos la regex

            MatchCollection match1 = regex1.Matches(texto);

            if (match1.Count > 0) Console.WriteLine("Hemos encontrado coincidencias de C");
            else Console.WriteLine("No se han encontrado coincidencias");

            string pattern2 = @"\d{3}-\d{3}-\d{2}-\d{2}"; // Buscamos un numero de telefono
            Regex regex2 = new Regex(pattern2);

            MatchCollection match2 = regex2.Matches(texto);
            Console.WriteLine(match2[0]);

            string patter3 = @"\+52";
            Regex regex3 = new Regex(patter3);

            MatchCollection match3 = regex3.Matches(texto);

            if (match3.Count > 0) Console.WriteLine("Si es de mexico");
            else Console.WriteLine("No es de mexico");*/

            EjercicioRegex.Run();
        }
    }
}