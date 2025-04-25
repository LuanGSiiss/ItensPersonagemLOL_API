using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ItensPersonagemLOL_API.Model
{
    public class ItemComponente
    {
        [Key]
        public int Codigo { get; set; }

        public int ItemCodigo { get; set; }

        [JsonIgnore]
        public Item? Item { get; set; }

        public int ComponenteCodigo { get; set; }

        [JsonIgnore]
        public Item? Componente { get; set; }
    }
}
