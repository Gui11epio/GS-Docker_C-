using System.ComponentModel.DataAnnotations;

namespace GeoAlertaC.Application.DTOs.Request
{
    public class EnderecoRequest
    {
        [Required(ErrorMessage = "O bairro é obrigatório")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O bairro deve ter entre 2 e 50 caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "A cidade é obrigatória")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "A cidade deve ter entre 2 e 50 caracteres")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O ID do usuário é obrigatório")]
        public long UsuarioId { get; set; }
    }
}
