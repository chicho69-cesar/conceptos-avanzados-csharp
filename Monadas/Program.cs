/*----- MONADAS CON STRUCTS -----*/
Console.WriteLine("PIPES");

// Funcion de primer orden
Func<decimal, decimal> Iva = (decimal amount) 
    => amount + (amount * 0.16M);

// Funcion sin tipo de dato
var Discount = (decimal amount) 
    => amount - (amount * 0.1M);

var Surcharge = (decimal amount) 
    => amount + (amount * 0.2M);

var AnnualPartialities = (decimal amount) 
    => amount / 12;

/*Cuando tenemos la llamada a muchas funciones, una dentro de otra
es recomendable usar un Pipe, para evitar el encadenamiento masivo
de funciones*/
Console.WriteLine(AnnualPartialities(Discount(Iva(Surcharge(100)))));

decimal amount = 100;
Console.WriteLine(amount.Pipe());
Console.WriteLine(amount.PipeGeneric());

Console.WriteLine("\n\n\nMONADA CON STRUCT");

decimal quantity = 100;

decimal total = quantity
    .Monada<decimal, decimal>(Surcharge) // Podemos declarar los tipos
    .Monada(Iva) // O inferirlos
    .Monada(Discount)
    .Monada(AnnualPartialities);

Console.WriteLine(total);



/*----- MONADAS CON CLASES -----*/
Console.WriteLine("\n\n\nMONADA CON CLASES");

var ReverseString = (string s) => {
    var charArray = s.ToCharArray();
    Array.Reverse(charArray);
    return new string(charArray);
};

Func<string, string> Upper = (string s) => s.ToUpper();

string name = "Cesar";

/*Podemos usar nuestro Pipe pasandole una funcion anonima
o podemos definir la funcion aparte y pasarsela*/
string result1 = name
    .PipeClass((string s) => {
        var charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    })
    .PipeClass((string s) => s.ToUpper());

string result2 = name
    .PipeClass(ReverseString)
    .PipeClass(Upper);

Console.WriteLine(result1);
Console.WriteLine(result2);

var beers = new List<string>() {
    "Corona", "Erdinger", "Victoria", 
    "Colimita", "Amstel", "Indio"
};

var resultList = beers
    .PipeClass((List<string> list) => {
        return list
            .Select(el => el.ToUpper())
            .ToList();
    })
    .PipeClass((List<string> list) => {
        return list
            .OrderBy(el => el)
            .ToList();
    });

Console.WriteLine("\nResultado: ");
foreach (var beer in resultList) {
    Console.WriteLine(beer);
}



/*----- CLASE PARA DEFINIR LOS PIPES -----*/
public static class Methods {
    /*Creamos un metodo, el cual va a estar definido y accesible
    por todas las variables que usen la struct Decimal, esta gracias
    al parametro this decimal*/
    public static decimal Pipe(this decimal v) {
        return v;
    }

    // Metodo Pipe que funciona con cualquier struct
    public static TIn PipeGeneric<TIn>(this TIn v) where TIn : struct {
        return v;
    }

    /*Creamos nuestra funcion para encadenar funciones y de esta manera
    generar la monada, en esta funcion un valor de una struct va a invocar
    este metodo, y le va a pasar una funcion, donde tendremos un valor
    de entrada (TIn) y uno de salida (TOut), en donde ambos son struct*/
    public static TOut Monada<TIn, TOut>(this TIn value, Func<TIn, TOut> fnOut)
        where TIn : struct
        where TOut : struct 
    {
        return fnOut(value);
    }

    /*Creamos nuestro Pipe que funciona con clases, en donde puede
    que el valor que llega como parametro sea null, en ese caso podemos
    regresar null o simplemente lanzar una exception con throw new Exception*/
    public static TOut PipeClass<TIn, TOut>(this TIn value, Func<TIn, TOut> fnOut) 
        where TIn : class
        where TOut : class
    {
        if (value is null)
            return null;

        return fnOut(value);
    }
}