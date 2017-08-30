using System;
using System.ComponentModel.DataAnnotations;

namespace Concessionaria.Dominio
{
    public class Venda
    {
        public int Venid { get; set; }

        [Required(ErrorMessage = "Obrigatório escolher um cliente")]
        public Cliente Cliente { get; set; }

        [Required(ErrorMessage = "Obrigatório escolher um carro")]
        public Carro Carro { get; set; }

        [Required(ErrorMessage = "Informe o valor da negociação")]
        public decimal? Venvalor { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? Vendatav { get; set; }
    }
}
