/*Un clousure es una funcion la cual nos regresa otra funcion, la principal ventaja de
esto es que podemos definir un estado para cada instancia de la funcion, este estado
se define dentro de la funcion envolvente y es usada por la funcion que retornamos*/

var funcion1 = Functions.Hola(100); // Creamos nuestro clousure
var funcion2 = Functions.Hola(200);

funcion1();
funcion1();
funcion1();
funcion2();
funcion2();
funcion1();
funcion2();

public class Functions {
    /*Para crear un clousure en C# debemos de usar el tipo de retorno action, 
    para poder regresar la funcion, la cual se define como una lambda expression. 
    En C# los clousere solo pueden regresar funciones de tipo void, es decir, sin
    tipo de dato primitivo de retorno, a diferencia de por ejemplo JS*/

    public static Action Hola(int init) {
        int contador = init; // Estado inicial

        return () => {
            Console.WriteLine($"Hola -> {++contador}");
        };
    }
}