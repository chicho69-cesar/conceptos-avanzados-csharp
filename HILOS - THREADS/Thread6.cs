/*Cuando usamos hilos los cuales intentan hacer uso de un mismo recurso, 
por ejemplo de un archivo, de una conexion, etc. Nos manda una excepcion
ya que no se puede acceder al mismo recursos desde dos hilos distintos,
ya que esto ocasionaria coliciones con el contenido del mismo*/

using System.Text;

namespace Threads {
    public class Thread6 {
        public static void Run() {
            string fileName = "result.txt";

            /*Creamos un file stream, el cual nos va a permitir añadir elementos al archivo
            y tendremos acceso a lectura y escritura sobre el*/
            var fs = new FileStream(fileName, FileMode.Append, FileAccess.Write);

            /*Creamos un proceso el cual se va a ejecutar 100 veces,
            teniando acceso a el solo 10 hilos por cada ciclo de ejecucion
            del callback que pasamos como 4to parametro, el cual recibe
            un parametro que es el indentificador del hilo que ejecuta el proceso*/
            Parallel.For(1, 100, new ParallelOptions {
                MaxDegreeOfParallelism = 10
            }, i => {
                Write(i, fs);
            });
        }

        // Metodo que va a compartir recursos entre los hilos
        static void Write(int id, FileStream fs) {
            /*Ejecutamos esta peticion a un servicio externo, el cual se ejecutara
            mientras el servicio este libre, una vez que no lo este la funcion lock se
            ejecutara y estas instrucciones se pondran en espera mientras el servicio se
            libera*/
            HttpClient client = new();
            var response = client.GetAsync("https://jsonplaceholder.typicode.com/todos/" + id).Result;
            var content = response.Content.ReadAsStringAsync().Result + Environment.NewLine;

            /*La funcion lock lo que hace es que bloquea el recurso cuando un hilo
            lo esta usando, asi cuando otro hilo llegue no lo dejara usar el recurso 
            hasta que este sea liberado por el hilo que lo este usando*/
            lock(fs) {
                // Convertimos el archivo a un array de bytes con codificacion utf-8
                byte[] bContent = new UTF8Encoding(true).GetBytes(content + Environment.NewLine);
                // Escribimos el contenido en el archivo desde la posicion 0 hasta el tamaño del contenido
                fs.Write(bContent, 0, bContent.Length);
                // Cerramos el buffer de escritura
                fs.Flush();
            }
        }
    }
}