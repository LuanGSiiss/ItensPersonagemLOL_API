using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ItensPersonagemLOL_API.Model
{
    public class EfeitoPassivo
    {
        [Key]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(30
                     , MinimumLength = 2
                     , ErrorMessage = "Informe de 2 a 30 caracteres"
            )]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatório")]
        [StringLength(800
                     , MinimumLength = 10
                     , ErrorMessage = "Informe de 10 a 800 caracteres"
            )]
        public string Descricao { get; set; }

        public int ItemCodigo { get; set; }
        
        [JsonIgnore]
        public Item? Item { get; set; }
    }
}
