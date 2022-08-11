/*En programación utilizamos yield para evitar tener que crear 
colecciones de datos temporales. 
Eso sí, cuando utilizamos yield return debemos devolver un 
IEnumerable<T> ya que necesitamos utilizar la interfaz IEnumerator

Lo que el operador yield realiza es pausar la ejecución de la iteración 
y devolver el valor al método que realiza la llamada para que este 
continúe con su ejecución y cuando termine volverá al siguiente punto 
del iterador (el que está en el método con yield return) similar a lo que
hace un Select en una consulta LINQ*/

namespace Yield {
    class Program {
        static void Main() {
            //Ejercicio1.Run();
            Ejercicio2.Run();
        }
    }
}