using APIwebPET.Models;
using System.Linq;

namespace APIwebPET.Repositories
{
    public class PassageiroRopository
    {
        protected readonly DataContext DC;

        public PassageiroRopository()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json")).Build();
            DC = new DataContext(configuration);
        }
        public Passageiro? Get(long? idPassagem)
        {
            return this.DC.Set<Passageiro>().Where(p => p.IdPassagem.Equals(idPassagem)).FirstOrDefault();
        }
        public List<Passageiro> Listar()
        {
            return this.DC.Set<Passageiro>().ToList();
            
        }
        public Passageiro Salvar(Passageiro p)
        {
            
                this.DC.Set<Passageiro>().Add(p);
                this.DC.SaveChanges();
                return p;
            
        }
        public Passageiro Atualizar(Passageiro passageiro)
        {
            try
            {
                Passageiro? p = Get(passageiro.IdPassagem);
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
                    p = this.DC.Set<Passageiro>().Update(p).Entity;
                    this.DC.SaveChanges();
                    return p;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public bool Excluir(long idPassagem)
        {
            Passageiro excluido = this.Get(idPassagem);
            if (excluido != null)
            {
                this.DC.Set<Passageiro>().Remove(excluido);
                this.DC.SaveChanges();
                return true;
            }
            return false;
        }
    }
}