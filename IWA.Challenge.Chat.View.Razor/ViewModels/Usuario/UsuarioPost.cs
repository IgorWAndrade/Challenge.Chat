using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IWA.Challenge.Chat.View.Razor.ViewModels.Usuario
{
    public class UsuarioPost
    {
        [ReadOnly(true)]
        public int Id { get; set; } = 0;

        [DisplayName("Adicionar Foto")]
        public string Foto { get; set; } = "";

        [DisplayName("Adicionar Nome")]
        public string Nome { get; set; } = "";

        [DisplayName("Adicionar Apelido")]
        public string Apelido { get; set; } = "";

        [DisplayName("Deseja logar como Anonimo?")]
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public bool Anonimo { get; set; } = false;

        public static void Preparar(UsuarioPost usuarioPost)
        {
            if (string.IsNullOrEmpty(usuarioPost.Foto))
            {
                usuarioPost.Foto = "";
            }

            if (string.IsNullOrEmpty(usuarioPost.Nome))
            {
                usuarioPost.Nome = "";
            }

            if (string.IsNullOrEmpty(usuarioPost.Apelido))
            {
                usuarioPost.Apelido = "";
            }
        }

    }
}
