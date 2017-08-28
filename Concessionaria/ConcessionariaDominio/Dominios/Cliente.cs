using System;
using System.ComponentModel.DataAnnotations;

namespace Concessionaria.Dominio
{
    public class Cliente
    {   
        [StringLength(14, ErrorMessage = "O CPF deve conter 11 numeros")]    
        [Required(ErrorMessage = "O campo CPF é obrigatório")]
        public string Clicpf { get; set; }

        [Required(ErrorMessage = "O Nome do cliente é obrigatório")]
        public string Clinome{ get; set; }

        [Required(ErrorMessage = "O Endereço do cliente é obrigatório")]
        public string Cliender { get; set; }

        public string Clicidad { get; set; }

        [StringLength (14, ErrorMessage = "Caso preencha o telefone ele deverá conter 10 ou 11 numeros", MinimumLength = 13)]
        [DataType(DataType.PhoneNumber)]        
        public string Clitelef { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? Clidatan { get; set; }

    }
}
