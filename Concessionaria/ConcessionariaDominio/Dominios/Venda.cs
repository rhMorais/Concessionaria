using System;
using System.ComponentModel.DataAnnotations;

namespace Concessionaria.Dominio
{
    public class Venda
    {
        public int Venid { get; set; }

        [Required(ErrorMessage = "Preencha um Cliente")]
        public Cliente Cliente { get; set; }

        [Required(ErrorMessage = "Preencha um Carro")]
        public Carro Carro { get; set; }

        public decimal? Venvalor { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Vendatav { get; set; }
    }
}
