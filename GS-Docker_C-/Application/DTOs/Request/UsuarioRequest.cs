using System.ComponentModel.DataAnnotations;

namespace GeoAlertaC.Application.DTOs.Request
{
    public class UsuarioRequest
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 20 caracteres")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório")]
        [RegularExpression(
                @"^\(?(11|12|13|14|15|16|17|18|19|" + 
                @"21|22|24|27|28|" +
                @"31|32|33|34|35|37|38|" +
                @"41|42|43|44|45|46|" +
                @"47|48|49|" +
                @"51|53|54|55|" +
                @"61|" +
                @"62|64|" +
                @"63|" +
                @"65|66|" +
                @"67|" +
                @"68|" +
                @"69|" +
                @"71|73|74|75|77|" +
                @"79|" +
                @"81|87|" +
                @"82|" +
                @"83|" +
                @"84|" +
                @"85|88|" +
                @"86|89|" +
                @"91|93|94|" +
                @"92|97|" +
                @"95|" +
                @"96|" +
                @"98|99)" +
                @"\)?[\s-]?9?\d{4}[-\s]?\d{4}$",
                ErrorMessage = "Telefone inválido. Use um DDD válido e o formato (11) 91234-5678")]
        public string Telefone { get; set; }
    }
}
