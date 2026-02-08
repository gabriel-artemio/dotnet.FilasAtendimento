namespace fila_atendimento_api.Models
{
    public class Servico
    {
        public int cd_servico { get; set; }
        public string? nm_servico { get; set; }
        public string? sigla { get; set; }
        public bool ativo { get; set; }
    }
}
