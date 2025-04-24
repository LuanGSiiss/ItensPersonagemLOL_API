using System.ComponentModel.DataAnnotations;

namespace ItensPersonagemLOL_API.Model
{
    public class Atributo
    {
        [Key]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatório")]
        [StringLength(50
                     , MinimumLength = 2
                     , ErrorMessage = "Informe de 2 a 50 caracteres"
            )]
        public string Descricao { get; set; }

        //Pode assumir "Absoluto" ou "Porcentagem"
        [Required(ErrorMessage = "Apresentação é obrigatório")]
        [StringLength(12
                     , MinimumLength = 7
                     , ErrorMessage = "Informe de 7 a 12 caracteres"
            )]
        public string Apresentacao { get; set; }

        public ICollection<ItemAtributo> ItemAtributos { get; set; } = new List<ItemAtributo>();
    }
}
