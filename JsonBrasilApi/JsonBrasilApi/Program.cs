using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace JsonBrasilApi
{  
    public class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://brasilapi.com.br/api/cnpj/v1/00000000000191"; // Exemplo CNPJ
            // Caminho para salvar dentro da pasta Data
            string projectDir = AppDomain.CurrentDomain.BaseDirectory;
            string dataDir = Path.Combine(projectDir, @"..\..\..\Data");
            string filePath = Path.Combine(dataDir, "dados.json");

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string json = await response.Content.ReadAsStringAsync();

                    // Desserializar JSON → Objeto C#
                    var empresa = JsonSerializer.Deserialize<Empresa>(json); 

                    Console.WriteLine("===== OBJETO DESSERIALIZADO =====");
                    Console.WriteLine($"Cep: {empresa.cep}");
                    Console.WriteLine($"CNPJ: {empresa.cnpj}");
                    Console.WriteLine($"Razão Social: {empresa.razao_social}");
                    Console.WriteLine($"Nome Fantasia: {empresa.nome_fantasia}");
                    Console.WriteLine($"Logradouro: {empresa.logradouro}");
                    Console.WriteLine($"Bairro: {empresa.bairro}");
                    Console.WriteLine($"Número: {empresa.numero}");
                    Console.WriteLine($"Município: {empresa.municipio}");
                    Console.WriteLine($"Complemento: {empresa.complemento}");
                    
                    // Serializar Objeto → JSON formatado
                    var options = new JsonSerializerOptions { WriteIndented = true };
                    string jsonFormatado = JsonSerializer.Serialize(empresa, options);

                    // Gravar em arquivo
                    await File.WriteAllTextAsync(filePath, jsonFormatado);

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

public class Empresa
{
    public string? cep { get; set; }
    public string? cnpj { get; set; }
    public string? razao_social { get; set; }
    public string? nome_fantasia { get; set; }
    public string? logradouro { get; set; }
    public string? bairro { get; set; }
    public string? numero { get; set; }
    public string? municipio { get; set; }
    public string? complemento { get; set; }
}
