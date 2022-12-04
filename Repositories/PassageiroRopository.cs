using APIwebPET.Models;
using System.Linq;

namespace APIwebPET.Repositories
{
    public class PassageiroRopository
    {
        private DataContext DC;

        public PassageiroRopository()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json")).Build();
            DC = new DataContext(configuration);
        }
        public Passageiro? Get(long idPassagem)
        {
            return this.DC.Set<Passageiro>().Where(p => p.Equals(idPassagem)).FirstOrDefault();
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
            Passageiro p = Get((long)passageiro.IdPassagem);
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
        public bool Excluir(long idPassagem)
        {
            Passageiro excluido = this.DC.Set<Passageiro>().SingleOrDefault(x => x.IdPassagem == idPassagem);
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