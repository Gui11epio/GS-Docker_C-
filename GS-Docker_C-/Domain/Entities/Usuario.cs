using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace GeoAlertaC.Domain.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string UserName { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string Senha { get; set; }

        [MaxLength(20)]
        public string Telefone { get; set; }

        // Relacionamento com Endereco 1..1
        public Endereco Endereco { get; set; }

        // / Relacionamento com Alertas 1..N
        public ICollection<Alertas> Alertas { get; set; } = new List<Alertas>();
    }
}
