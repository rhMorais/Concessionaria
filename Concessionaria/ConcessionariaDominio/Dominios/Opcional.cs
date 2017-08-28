using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Concessionaria.Dominio
{
    public class Opcional
    {
        [ReadOnly(true)]
        public int Opcid { get; set; }


        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Preencha a descrição")]
        public string Opcdescr { get; set; }
    }
}
