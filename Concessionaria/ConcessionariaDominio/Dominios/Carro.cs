using System.ComponentModel.DataAnnotations;

namespace Concessionaria.Dominio
{
    public class Carro
    {
        [Required(ErrorMessage = "Preencha a placa do carro")]
        public string Carplaca { get; set; }

        [Required(ErrorMessage = "Preencha o modelo do carro")]
        public string Carmodel { get; set; }

        [Required(ErrorMessage = "Preencha a marca do carro")]

        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "[Sem informacao]")]
        public string Carmarca { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "[Sem informacao]")]
        public string Cartipo { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "[Sem informacao]")]
        public string Carcombu { get; set; }

        [Required(ErrorMessage = "Preencha a cor do carro")]
        public string Carcor { get; set; }
        
        [Required(ErrorMessage = "Preencha o ano do carro")]
        public string Carano { get; set; }

        public int Carstatus { get; set; }
    }
}
