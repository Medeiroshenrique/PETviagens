using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIwebPET.Models;

namespace PETviagens.Interfaces
{
    public interface IPassageiroService
    {
        Task<Passageiro?> Get(long idPassagem);
        Task<List<Passageiro>> Listar();
        Task<Passageiro> Salvar(Passageiro passageiro);
        Task<Passageiro> Atualizar(Passageiro passageiro);
        Task<bool> Excluir(long idPassagem);
    }
}