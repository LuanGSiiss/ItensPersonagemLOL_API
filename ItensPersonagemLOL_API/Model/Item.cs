using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItensPersonagemLOL_API.Model
{
    public class Item
    {
        [Key]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100
                     , MinimumLength = 2
                     , ErrorMessage = "Informe de 2 a 100 caracteres"
            )]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preço é obrigatório")]
        [Range(0, int.MaxValue, ErrorMessage = "Preço não pode ser negativo")]
        public int Preco { get; set; }

        public string? EfeitoAtivo { get; set; }

        [ForeignKey("Classe")]
        public int ClasseCodigo { get; set; }
        public Classe? Classe { get; set; }

        public ICollection<EfeitoPassivo> EfeitosPassivo { get; set; } = new List<EfeitoPassivo>();
        public ICollection<ItemAtributo> ItemAtributos { get; set; } = new List<ItemAtributo>();
        public ICollection<PersonagemItem> PersonagemItens { get; set; } = new List<PersonagemItem>();
        public ICollection<ItemComponente> Componentes { get; set; } = new List<ItemComponente>();
        public ICollection<ItemComponente> UsadoEm { get; set; } = new List<ItemComponente>();
    }
}
