namespace APIwebPET.Models
{
    public class Passageiro
    {
       public long IdPassagem { get; set; }
       public string Nome { get; set; }
       public string Sobrenome { get; set; }
       public string Sexo { get; set; }
       public string TipoViagem { get; set; } //internacional ou não?
       public string DestinoViagem { get; set; }
       public string EmpresaParceira { get; set; }
       public string HoraDecolagem { get; set; }

       

    }
}
