/*Aqui vienen muchisimos ejemplos de serializacion y de deserializacion: 
https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-how-to?pivots=dotnet-6-0*/

using System.Text.Json;

namespace Serializacion {
    class Program {
        static void Main(string[] args) {
            Beer beer = new Beer() {
                Name = "Corona",
                Price = 20.0
            };

            string beerString = JsonSerializer.Serialize(beer);
            Console.WriteLine(beerString);
            Console.WriteLine(beerString.GetType());
            Console.WriteLine(beer.GetType());

            Console.WriteLine();

            var beerJson = JsonSerializer.Deserialize<Beer>(beerString);
            Console.WriteLine(beerJson);
            Console.WriteLine(beerJson.GetType());
            Console.WriteLine(beerJson.Name);
        }
    }

    class Beer {
        public string? Name { get; set; }
        public double Price { get; set; }
    }
}