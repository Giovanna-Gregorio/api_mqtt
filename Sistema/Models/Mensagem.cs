using System.ComponentModel.DataAnnotations;

namespace Sistema.Data
{
    public class Mensagem
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public string Texto { get; set; }
    }
}
