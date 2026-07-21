using APIwebPET.Models;
using PETviagens.Interfaces;

namespace APIwebPET.Services
{
    public class PassageiroService:IPassageiroService
    {
        private readonly IPassageiroRepository _repositorio;
        public PassageiroService(IPassageiroRepository repositorio) {
            _repositorio = repositorio;
        }

        public async Task<Passageiro?> Get(long idPassagem) {
            return await _repositorio.Get(idPassagem);
        }

        public async Task<List<Passageiro>> Listar() {
            return await _repositorio.Listar();
        }

        public async Task<Passageiro> Salvar(Passageiro passageiro) {
            return await _repositorio.Salvar(passageiro);
        }

        public async Task<Passageiro> Atualizar(Passageiro passageiro) {
            Passageiro? p = await Get((long)passageiro.IdPassagem!);
            if (p==null) { 
                throw new Exception(); 
            } else {
                return await _repositorio.Atualizar(passageiro);
            } 
        }

        public async Task<bool> Excluir(long idPassagem) {
            return await _repositorio.Excluir(idPassagem);
        }

    }
}
