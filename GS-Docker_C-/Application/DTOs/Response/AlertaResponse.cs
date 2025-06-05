namespace GeoAlertaC.Application.DTOs.Response
{
    public class AlertaResponse
    {
        public string NivelRisco { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int Probabilidade { get; set; }
    }
}
