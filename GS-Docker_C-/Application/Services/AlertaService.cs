using GeoAlertaC.Application.DTOs.Request;
using GeoAlertaC.Application.DTOs.Response;
using GeoAlertaC.Domain.Entities;
using GeoAlertaC.Domain.Enums;
using GeoAlertaC.Infrastructure.Context;

namespace GeoAlertaC.Application.Services
{
    public class AlertaService
    {
        private readonly AppDBContext _context;

        public AlertaService(AppDBContext context)
        {
            _context = context;
        }

        public AlertaResponse CalcularAlerta(DadosClimaticosRequest dados)
        {
            double score = 0;

            // Pesos ajustáveis para cada variável climática
            score += dados.Chuva * 0.3;                           // mais chuva, mais risco
            score += dados.Umidade * 0.2;                         // alta umidade contribui
            score += dados.Vento * 0.1;                           // ventos fortes são agravantes
            score += dados.Nuvens * 0.05;                         // nuvens têm influência menor
            score += (1100 - dados.Pressao) * 0.1;                // menor pressão = maior risco
            score += Math.Max(0, (20 - dados.Temperatura)) * 0.1; // temperaturas baixas = mais risco

            // Normalização e limitação
            double riscoFinal = Math.Clamp(score, 0, 100);

            var (nivel, descricao, probabilidade) = CalcularNivel(riscoFinal);

            var usuario = _context.Usuarios.Find((int)dados.UsuarioId);
            if (usuario == null) throw new Exception("Usuário não encontrado.");

            var endereco = _context.Enderecos.Find((int)dados.EnderecoId);
            if (endereco == null) throw new Exception("Endereço não encontrado.");

            var alerta = new Alertas
            {
                NivelRisco = nivel,
                Descricao = descricao,
                Probabilidade = probabilidade,
                DataHora = DateTime.Now,
                Usuario = usuario,
                Endereco = endereco
            };

            _context.Alertas.Add(alerta);
            _context.SaveChanges();

            return new AlertaResponse
            {
                NivelRisco = nivel.ToString(),
                Descricao = descricao,
                Probabilidade = probabilidade
            };
        }

        private (NivelRisco nivel, string descricao, int probabilidade) CalcularNivel(double score)
        {
            if (score < 15)
                return (NivelRisco.MUITO_BAIXO, "Sem riscos. Condições estáveis.", 5);
            else if (score < 30)
                return (NivelRisco.BAIXO, "Chuvas leves. Nenhum risco visível.", 15);
            else if (score < 45)
                return (NivelRisco.MODERADO, "Condições que merecem atenção.", 40);
            else if (score < 60)
                return (NivelRisco.ALTO, "Risco relevante de deslizamento.", 70);
            else
                return (NivelRisco.CRITICO, "Risco crítico. Ações imediatas recomendadas.", 90);
        }
    }
}
