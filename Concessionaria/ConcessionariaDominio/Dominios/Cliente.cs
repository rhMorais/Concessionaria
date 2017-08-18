using System;
using System.ComponentModel.DataAnnotations;

namespace Concessionaria.Dominio
{
    public class Cliente
    {
        [Required(ErrorMessage = "Preencha o CPF do cliente")]
        public string Clicpf { get; set; }

        [Required(ErrorMessage = "Preencha o Nome do cliente")]
        public string Clinome{ get; set; }

        [Required(ErrorMessage = "Preencha o Endereço do cliente")]
        public string Cliender { get; set; }

        public string Clicidad { get; set; }

        [DataType(DataType.PhoneNumber)]        
        public string Clitelef { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? Clidatan { get; set; }

    }
}
