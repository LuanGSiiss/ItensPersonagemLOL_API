using System.ComponentModel.DataAnnotations;

namespace ItensPersonagemLOL_API.Model
{
    public class Classe
    {
        [Key]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatório")]
        [StringLength(20
                     , MinimumLength = 2
                     , ErrorMessage = "Informe de 2 a 20 caracteres"
            )]
        public string Descricao { get; set; }

    }
}
