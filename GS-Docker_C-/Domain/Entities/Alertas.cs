using System.ComponentModel.DataAnnotations;
using GeoAlertaC.Domain.Enums;

namespace GeoAlertaC.Domain.Entities
{
    public class Alertas
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public NivelRisco NivelRisco { get; set; }
        public int Probabilidade { get; set; }

        [MaxLength(255)]
        public string Descricao { get; set; }

        // Relacionamento com Usuario N..1
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        // Relacionamento com Endereco N..1
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
    }
}
