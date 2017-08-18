using System.ComponentModel.DataAnnotations;

namespace Concessionaria.Dominio
{
    public class Opcional
    {
        public int Opcid { get; set; }

        [Required(ErrorMessage = "Preencha a descrição")]
        public string Opcdescr { get; set; }
    }
}
