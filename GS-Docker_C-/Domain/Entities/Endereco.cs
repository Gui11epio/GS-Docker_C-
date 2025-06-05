using System.ComponentModel.DataAnnotations;

namespace GeoAlertaC.Domain.Entities
{
    public class Endereco
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Bairro { get; set; }

        [MaxLength(50)]
        public string Cidade { get; set; }

        // Relacionamento com Usuario 1..1
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
