using fila_atendimento_api.BLL;
using fila_atendimento_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fila_atendimento_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private readonly ServicoBLL bll;
        public ServicoController(IConfiguration configuration)
        {
            bll = new ServicoBLL(configuration);
        }

        [HttpGet]
        public List<Servico>? GetAll()
        {
            return bll.GetAll();
        }

        [HttpGet("{id}")]
        public Servico? GetById(string id)
        {
            int _id = 0;
            Servico? servico = null;
            if (int.TryParse(id, out _id))
            {
                servico = bll.GetById(_id);
            }
            return servico;
        }

        
        [HttpPost]
        public dynamic Insert([FromBody] RegistroPonto registroPonto)
        {
            if (registroPonto != null)
            {
                try
                {
                    bll.Insert(registroPonto);
                    return StatusCode(200);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest("Não foram informados dados");
            }
        }
    }
}
