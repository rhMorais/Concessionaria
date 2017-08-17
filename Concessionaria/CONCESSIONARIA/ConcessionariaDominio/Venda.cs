using System;
using System.ComponentModel.DataAnnotations;

namespace ConcessionariaDominio
{
    public class Venda
    {
        [Required(ErrorMessage = "Preencha um cliente")]
        public Cliente Cliente { get; set; }

        [Required(ErrorMessage = "Preencha um Carro")]
        public Carro Carro { get; set; }

        public decimal? Venvalor { get; set; }

        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime? Vendatav { get; set; }
    }
}
