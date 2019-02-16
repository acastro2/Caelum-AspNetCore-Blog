using Blog.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace ConsumeApi
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                const string url = "http://blogmls.azurewebsites.net/api/post/novo";

                var p = new Post
                {
                    Titulo = "Teste (Oi 2)",
                    Resumo = "Teste",
                    Categoria = "Teste"
                };

                Console.WriteLine(JsonConvert.SerializeObject(u));

                using (var client = new HttpClient())
                {
                    var result = client.PostAsJsonAsync(url, p).Result;

                    Console.WriteLine(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.ReadLine();
        }
    }
}
