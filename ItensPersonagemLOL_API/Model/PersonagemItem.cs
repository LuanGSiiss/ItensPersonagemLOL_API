using System.ComponentModel.DataAnnotations;

namespace ItensPersonagemLOL_API.Model
{
    public class PersonagemItem
    {
        [Key]
        public int Codigo { get; set; }

        public int PersonagemCodigo { get; set; }
        public Personagem? Personagem { get; set; }

        public int ItemCodigo { get; set; }
        public Item? Item { get; set; }
    }
}
