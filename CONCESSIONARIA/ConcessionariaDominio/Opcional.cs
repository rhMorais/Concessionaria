using System.ComponentModel.DataAnnotations;

namespace ConcessionariaDominio
{
    public class Opcional
    {
        public int Opcid { get; set; }

        [Required(ErrorMessage = "Preencha a descricao")]
        public string Opcdescr { get; set; }
    }
}
