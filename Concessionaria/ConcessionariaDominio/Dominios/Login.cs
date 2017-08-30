using System.ComponentModel.DataAnnotations;

namespace Concessionaria.Dominio
{
    public class Login
    {
        [StringLength(12, ErrorMessage = "Usuario deve conter no mínimo 6 e no máximo 12 letras", MinimumLength = 4)]
        [Required(ErrorMessage = "Preencha um Usuário")]
        public string Logusuar { get; set; }

        [StringLength(12, ErrorMessage = "A senha deve conter no mínimo 6 caracters e no máximo 12", MinimumLength = 6)]
        [Required(ErrorMessage = "Preencha uma Senha")]
        public string Logsenha { get; set; }
    }
}
