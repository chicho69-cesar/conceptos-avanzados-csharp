using System.Text.Json;

namespace Peticiones {
    class Program {
        public static async Task Main() {
            string url = "http://jsonplaceholder.typicode.com/posts";
            HttpClient client = new HttpClient();

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode) {
                var data = await response.Content.ReadAsStringAsync();
                List<Post>? posts = JsonSerializer.Deserialize<List<Post>>(data);

                foreach (var post in posts) {
                    Console.WriteLine(
                        $"\tId: {post.id} \n" +
                        $"Titulo: {post.title} \n" +
                        $"Post: {post.body} \n"
                    );
                }
            }
        }
    }

    class Post {
        public int userId { get; set; }
        public int id { get; set; }
        public string? title { get; set; }
        public string? body { get; set; }
    }
}