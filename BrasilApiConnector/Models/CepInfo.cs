using System.ComponentModel.DataAnnotations;

namespace BrasilApiConnector.Models
{
    public class CepInfo
    {
        [Key]
        public int Id { get; set; }
        public string Cep { get; set; } = default!;
        public string? State { get; set; }
        public string? City { get; set; }
        public string? Neighborhood { get; set; }
        public string? Street { get; set; }
        public string? Service { get; set; }
        public DateTime FetchedAt { get; set; }
    }
}
