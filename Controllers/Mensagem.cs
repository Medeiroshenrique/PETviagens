namespace APIwebPET.Controllers
{
    public class Mensagem
    {
        public int Codigo { get; set; }
        public string? Texto { get; set; }

        public Mensagem(int codigo, string? texto)
        {
            this.Codigo = codigo;
            this.Texto = texto;
        }
    }
}