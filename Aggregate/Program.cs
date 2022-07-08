List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

/*El metodo aggregate es practicamente lo mismo que el metodo reduce de 
JS, donde tenemos un valor inicial del acumulador el cual en este caso es 0.
Y tenemos un expresion lambda la cual nos indica que accion va a realizar
este metodo, metodo el cual recibe dos parametros, donde el primero 
corresponde al acumulador y el segundo al metodo que esta siendo iterado*/
int suma = numbers.Aggregate(0, (acumulador, elemento) => {
    return acumulador + elemento;
});

int sumaCorta = numbers.Aggregate(0, (acc, el) => acc + el);

Console.WriteLine($"La suma de los numeros es: {suma}");
Console.WriteLine($"La suma de los numeros es: {sumaCorta}");