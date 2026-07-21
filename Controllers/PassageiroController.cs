using APIwebPET.Services;
using Microsoft.AspNetCore.Mvc;
using APIwebPET.Models;
using PETviagens.Interfaces;


namespace APIwebPET.Controllers
{
    [Route("api/passageiros")]
    [ApiController]
    public class PassageiroController : ControllerBase
    {
        private readonly IPassageiroService _service;
        public PassageiroController(IPassageiroService service) 
        {
            _service = service;
        }

        [HttpGet("{idpassagem}")]
        public async Task<IActionResult> Get(long idPassagem)
        {
            if (idPassagem < 1)
            {
                return this.Ok(new Mensagem(404, "Passageiro não encontrado"));
            }
            else { return Ok(await _service.Get(idPassagem)); }
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            return this.Ok(await _service.Listar());
        }


        [HttpPost]
        public async Task<IActionResult> Salvar(Passageiro passageiro)
        {
            passageiro.IdPassagem = null;
            return this.Ok(await _service.Salvar(passageiro));
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(Passageiro passageiro)
        {
            return Ok(await _service.Atualizar(passageiro));
        }
        [HttpDelete("{idpassagem}")]
        public async Task<IActionResult> Excluir(long idPassagem)
        {
            if (await _service.Excluir(idPassagem))
            {
                return Ok(new Mensagem(200, typeof(Passageiro).Name + " foi excluído do sistema."));
            }
            else
            {
                return Ok(new Mensagem(404, typeof(Passageiro).Name + " não está mais no sistema, a viagem pode ter sido apagada ou cancelada"));
            }
        }
    }
}
