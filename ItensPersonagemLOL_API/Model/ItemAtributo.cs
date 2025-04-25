using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ItensPersonagemLOL_API.Model
{
    public class ItemAtributo
    {
        [Key]
        public int Codigo { get; set; }
        
        public int ItemCodigo { get; set; }
        
        [JsonIgnore]
        public Item? Item { get; set; }

        public int AtributoCodigo { get; set; }

        [JsonIgnore]
        public Atributo? Atributo { get; set; }

        public int Valor { get; set; }
    }
}
