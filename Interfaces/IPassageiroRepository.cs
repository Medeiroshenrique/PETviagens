using APIwebPET.Models;

namespace PETviagens.Interfaces;

public interface IPassageiroRepository
{
    Task<Passageiro?> Get(long? idPassagem);
    Task<List<Passageiro>> Listar();
    Task<Passageiro> Salvar(Passageiro p);
    Task<Passageiro> Atualizar(Passageiro passageiro);
    Task<bool> Excluir(long idPassagem);

    
}