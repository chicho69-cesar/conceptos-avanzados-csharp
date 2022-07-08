/*LINQ es un lenguaje integrado de consultas en el ambiente de .Net, este se usa
para guardar y consultar datos de diferentes origenes de datos.
LINQ principalmente tiene acceso a datos que provienen de: 
    Colecciones de objetos
    XML
    SQL BBDD
    Entidades
    Recordset
    Otras estructuras de datos
Este lenguaje nos permite tener una uniformidad en lenguajes de consulta, nos permite
tener una gran reduccion de codigo, codigo mas legible, etc.
La API de LINQ esta conformada principalmente por las clases Enumerable y Queryable,
las cuales implementan las interfaces IEnumerable y IQueryable respectivamente.*/

namespace LINQ {
    public class LINQ1 {
        public static void Run() {
            int[] numeros = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            /*Como podemos observar el lenguaje de consultas LINQ es sumamente parecido
            a SQL, como podemos ver la lista pares almacenara los numeros del arreglo
            numeros que cumplan con la condicion de que sean numeros pares*/
            IEnumerable<int> pares = from numero in numeros where numero % 2 == 0 select numero;

            Console.WriteLine("Numeros pares filtrados");
            foreach (int numero in pares) {
                Console.Write(numero + " - ");
            }
        }
    }
}