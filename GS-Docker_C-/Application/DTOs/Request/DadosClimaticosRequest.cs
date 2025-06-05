using System.ComponentModel.DataAnnotations;

namespace GeoAlertaC.Application.DTOs.Request
{
    public class DadosClimaticosRequest
    {
        [Range(0, 500, ErrorMessage = "A chuva deve estar entre 0 e 500")]
        public double Chuva { get; set; }

        [Range(0, 100, ErrorMessage = "A umidade deve estar entre 0 e 100")]
        public double Umidade { get; set; }

        [Range(-50, 60, ErrorMessage = "A temperatura deve estar entre -50 e 60")]
        public double Temperatura { get; set; }

        [Range(0, 150, ErrorMessage = "O vento deve estar entre 0 e 150")]
        public double Vento { get; set; }

        [Range(0, 100, ErrorMessage = "A cobertura de nuvens deve estar entre 0 e 100")]
        public double Nuvens { get; set; }

        [Range(800, 1100, ErrorMessage = "A pressão deve estar entre 800 e 1100")]
        public double Pressao { get; set; }

        [Required(ErrorMessage = "O ID do usuário é obrigatório")]
        public long UsuarioId { get; set; }

        [Required(ErrorMessage = "O ID do endereço é obrigatório")]
        public long EnderecoId { get; set; }
    }
}
