using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionariaDominio
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
