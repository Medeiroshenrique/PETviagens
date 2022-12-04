using APIwebPET.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIwebPET.Models;


namespace APIwebPET.Controllers
{
    [Route("api/passageiros")]
    [ApiController]
    public class PassageiroController : ControllerBase
    {
        private PassageiroService servico;
        public PassageiroController() : base()
        {
            this.servico = new PassageiroService(new Repositories.PassageiroRopository());
        }

        [HttpGet("idpassagem")]
        public IActionResult Get(long idPassagem)
        {
            if (idPassagem < 1 || idPassagem > 5)
            {
                return this.Ok(new Mensagem(403, "Passageiro não encontrado"));
            }
            else { return this.Ok(servico.Get(idPassagem)); }
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return this.Ok(servico.Listar());
        }


        [HttpPost]
        public IActionResult Salvar(Passageiro passageiro)
        {
            return this.Ok(servico.Salvar(passageiro));
        }

        [HttpPut]
        public IActionResult Atualizar(Passageiro passageiro) {
            return this.Ok(servico.Atualizar(passageiro));
        }
        [HttpDelete("{idpassagem}")]
        public IActionResult Excluir(long idPassagem) {
            if (servico.Excluir(idPassagem))
            {
                return this.Ok(new Mensagem(200, typeof(Passageiro).Name + "essa passagem foi excluída do sistema."));
            }
            else
            {
                return this.Ok(new Mensagem(403, typeof(Passageiro).Name + " não está mais no sistema, a viagem pode ter sido apagada ou cancelada"));
            }
        }
    }
}
