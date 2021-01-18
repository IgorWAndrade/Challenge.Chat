namespace IWA.Challenge.Chat.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public string Foto { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public bool Anonimo { get; set; }

        public Usuario()
        {

        }

        public Usuario(string foto, string nome, string apelido, bool anonimo)
        {
            this.Foto = foto;
            this.Nome = nome;
            this.Apelido = apelido;
            this.Anonimo = anonimo;
        }
    }
}
