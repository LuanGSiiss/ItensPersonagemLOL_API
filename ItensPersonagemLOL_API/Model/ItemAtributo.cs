namespace ItensPersonagemLOL_API.Model
{
    public class ItemAtributo
    {
        public int ItemCodigo { get; set; }
        public Item Item { get; set; }

        public int AtributoCodigo { get; set; }
        public Atributo Atributo { get; set; }

        public int Valor { get; set; }
    }
}
