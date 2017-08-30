using System.ComponentModel.DataAnnotations;

namespace Concessionaria.Dominio
{
    public class Opcional
    {        
        public int Opcid { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Preencha a descrição")]
        public string Opcdescr { get; set; }
    }
}
