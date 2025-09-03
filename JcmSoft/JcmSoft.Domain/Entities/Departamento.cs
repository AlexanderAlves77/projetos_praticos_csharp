using System.Data;

namespace JcmSoft.Domain.Entities
{
    public class Departamento
    {
        public int DepartamentoId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; }

        public ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
    }
}
