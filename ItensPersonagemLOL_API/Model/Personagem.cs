using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItensPersonagemLOL_API.Model
{
    public class Personagem
    {
        [Key]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(30
             , MinimumLength = 2
             , ErrorMessage = "Informe de 2 a 30 caracteres"
        )]
        public string Nome { get; set; }

        [ForeignKey("Classe")]
        public int ClasseCodigo { get; set; }
        public Classe Classe { get; set; }

        public ICollection<PersonagemItem> PersonagemItens { get; set; }
    }
}
