using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIwebPET.Models
{
    public class Passageiro
    {
        [Key]
        [Column("IdPassagem")]
        public long? IdPassagem { get; set; }
       public string? Nome { get; set; }
       public string? Sobrenome { get; set; }
       public string? Sexo { get; set; }
       public string? TipoViagem { get; set; } //internacional ou não?
       public string? DestinoViagem { get; set; }
       public string? EmpresaParceira { get; set; }
       public string? HoraDecolagem { get; set; }
        public Passageiro(long? idPassagem) {
            IdPassagem = idPassagem;
        }
        [JsonConstructor]
       public Passageiro(long? idPassagem, string? nome, string? sobrenome, string? sexo, string? tipoViagem, string? destinoViagem, string? empresaParceira, string? horaDecolagem)
        {
            
            IdPassagem = idPassagem;
            Nome = nome;
            Sobrenome = sobrenome;
            Sexo = sexo;
            TipoViagem = tipoViagem;
            DestinoViagem = destinoViagem;
            EmpresaParceira = empresaParceira;
            HoraDecolagem = horaDecolagem;
        }
    }
}
