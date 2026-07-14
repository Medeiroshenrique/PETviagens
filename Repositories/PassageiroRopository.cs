using APIwebPET.Models;
using Microsoft.EntityFrameworkCore;
using PETviagens.Interfaces;

namespace APIwebPET.Repositories
{
    public class PassageiroRopository: IPassageiroRepository
    {
        private readonly DataContext _dc;

        public PassageiroRopository(DataContext dc)
        {
            _dc = dc;
        }
        
        

        public async Task<Passageiro?> Get(long? idPassagem)
        {
            return await _dc.Set<Passageiro>().FirstOrDefaultAsync(p => p.IdPassagem == idPassagem);
        }

        public async Task<List<Passageiro>> Listar()
        {
            return await _dc.Set<Passageiro>().ToListAsync();

        }

        public async Task<Passageiro> Salvar(Passageiro p)
        {
            await _dc.Set<Passageiro>().AddAsync(p);
               await _dc.SaveChangesAsync();
                return p;
        }

        public async Task<Passageiro> Atualizar(Passageiro passageiro)
        {
            try
            {
                Passageiro? p = await Get(passageiro.IdPassagem);
                if (p==null) { 
                    throw new Exception(typeof(Passageiro).Name + " com a passagem informada não foi encontrado(a)!");
                }
                else
                {
                    p.Nome = passageiro.Nome;
                    p.Sobrenome = passageiro.Sobrenome;
                    p.Sexo = passageiro.Sexo;
                    p.TipoViagem = passageiro.TipoViagem;
                    p.DestinoViagem = passageiro.DestinoViagem;
                    p.EmpresaParceira = passageiro.EmpresaParceira;
                    p.HoraDecolagem = passageiro.HoraDecolagem;
                    p = _dc.Set<Passageiro>().Update(p).Entity;
                    await _dc.SaveChangesAsync();
                    return p;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<bool> Excluir(long idPassagem)
        {
            var excluido = await Get(idPassagem);
            if (excluido != null)
            {
                _dc.Set<Passageiro>().Remove(excluido);
                await _dc.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}