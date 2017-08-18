using System.ComponentModel.DataAnnotations;

namespace Concessionaria.Dominio
{
    public class Login
    {
        [StringLength(12, MinimumLength = 6)]
        [Required(ErrorMessage = "Preencha um Usuário")]
        public string Logusuar { get; set; }

        [Required(ErrorMessage = "Preencha uma Senha")]
        public string Logsenha { get; set; }
    }
}
