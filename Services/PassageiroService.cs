using APIwebPET.Models;
using APIwebPET.Repositories;

namespace APIwebPET.Services
{
    public class PassageiroService
    {
        private PassageiroRopository Repositorio { get; set; }
        public PassageiroService(PassageiroRopository repositorio) {
            this.Repositorio = repositorio;
        }

        public Passageiro Get(long idPassagem) {
            return this.Repositorio.Get(idPassagem);
        }

        public List<Passageiro> Listar() {
            return this.Repositorio.Listar();
        }

        public Passageiro Salvar(Passageiro passageiro) {
            return this.Repositorio.Salvar(passageiro);
        }

        public Passageiro Atualizar(Passageiro passageiro) {
            return this.Repositorio.Atualizar(passageiro);
        }

        public bool Excluir(long idPassagem) {
            return this.Repositorio.Excluir(idPassagem);
        }

    }
}
