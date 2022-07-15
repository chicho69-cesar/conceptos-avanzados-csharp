/*Mutex: (Exclusion mutua) Este concepto es utilizado cuando tenemos procesos
asincronos en diferentes hilos, los cuales pueden ser paralelos o no,
entonces cuando tenemos un proceso que no puede ser ejecutado
al mismo tiempo por otros dos procesos en hilos paralelos al mismo 
tiempo, debemos de usar mutex para que cada uno tome su tiempo
de ejecutar el proceso en el servidor, es comun cuando el proceso
que se ejecuta regresa un servicio que debe ser unico para cada proceso*/

Mutex mut = new Mutex(); // Creamos el objeto mutex para proteger los procesos
var myCake = new Cake(100);

List<Person> people = new List<Person>() {
    new Person(myCake, "Cesar", mut),
    new Person(myCake, "Lucy", mut),
    new Person(myCake, "Hector", mut),
    new Person(myCake, "Thai", mut),
    new Person(myCake, "Adrian", mut)
};

foreach (Person person in people) {
    var thread = new Thread(new ThreadStart(person.Bite));
    thread.Start();
}

class Cake {
    private int _quantity { get; set; }

    public Cake(int quantity) {
        _quantity = quantity;
    }

    public void BiteMe() => _quantity--;

    public int GetQuantity() => _quantity;
}

class Person {
    private readonly Cake _cake;
    private readonly string _name;
    private readonly Mutex _mutex;

    public Person(Cake cake, string name, Mutex mutex) {
        _cake = cake;
        _name = name;
        _mutex = mutex;
    }

    public void Bite() {
        while (_cake.GetQuantity() > 0) {
            try {
                _mutex.WaitOne(); /*Protegemos el objeto de proceso y ningun
                otro hilo podra acceder a el hasta que el proceso sea liberado*/

                /*Esta validacion la hacemos porque cuando entra al while
                el proceso no esta protegido, por lo que pueden entrar 3
                procesos al mismo tiempo cuando solo tenemos como cantidad 1
                por lo que validamos nuevamente la cantidad*/
                if (_cake.GetQuantity() > 0) {
                    Console.WriteLine($"{_name} le muerde al pastel {_cake.GetQuantity()}");
                    _cake.BiteMe();
                    Console.WriteLine($"{_name} deja el pastel con {_cake.GetQuantity()}\n");

                    _mutex.ReleaseMutex(); // Liberamos el proceso
                }

            /*Agregamos esta excepcion ya que cuando el servicio se 
            termina si aun hay quienes entran aunque el servicio ya
            se haya terminado lanzara una excepcion*/
            } catch(AbandonedMutexException) {
                Console.WriteLine($"{_name} hiba a morderle y ya no pudo jajaja :v");
            }
        }
    }
}