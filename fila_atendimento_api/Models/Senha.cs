namespace fila_atendimento_api.Models
{
    public class Senha
    {
        public int cd_senha { get; set; }
        public int cd_prioridade { get; set; }
        public int cd_servico { get; set; }
        public string? sigla { get; set; }
        public DateTime dt_senha { get; set; }
    }
}
