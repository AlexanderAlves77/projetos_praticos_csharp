using JcmSoft.Domain.Entities.Enums;

namespace JcmSoft.Domain.Entities
{
    public class Projeto
    {
        public int ProjetoId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal Orcamento { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime DataFim { get; set; }

        public StatusProjeto Status {  get; set; }
        public ICollection<FuncionarioProjeto> FuncionariosProjetos { get; set; } = new List<FuncionarioProjeto>();

        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
    }
}
