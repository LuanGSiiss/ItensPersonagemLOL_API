namespace ItensPersonagemLOL_API.Model
{
    public class PersonagemItem
    {
        public int PersonagemCodigo { get; set; }
        public Personagem Personagem { get; set; }

        public int ItemCodigo { get; set; }
        public Item Item { get; set; }
    }
}
