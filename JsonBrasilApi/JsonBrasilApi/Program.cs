using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;

namespace JsonBrasilApi
{  
    public class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://brasilapi.com.br/api/cnpj/v1/00000000000191"; // Exemplo CNPJ
            string filePath = "dados.json";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string json = await response.Content.ReadAsStringAsync();

                    Console.WriteLine("===== RESPOSTA DA API =====");
                    Console.WriteLine(json);

                    // Gravar em arquivo
                    await File.WriteAllTextAsync(filePath, json);

                    Console.WriteLine($"\nArquivo salvo em: {Path.GetFullPath(filePath)}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao consultar API: " + ex.Message);
                }
            }

            Console.ReadLine();
        }
    }

}
