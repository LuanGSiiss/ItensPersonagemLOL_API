using ItensPersonagemLOL_API.Data;
using ItensPersonagemLOL_API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ItensPersonagemLOL_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonagemItemController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public PersonagemItemController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public List<PersonagemItem> GetPersonagemItem()
        {
            var lista = _appDbContext.PersonagemItens
                .OrderBy(c => c.Codigo)
                .ToList();

            return lista;
        }

        [HttpPost]
        public IActionResult PostPersonagemItem([FromBody] PersonagemItem personagemItem)
        {
            //personagemcodigo itemcodigo
            var ultimoCodigo = _appDbContext.PersonagemItens
            .OrderByDescending(i => i.Codigo)
            .Select(i => i.Codigo)
            .FirstOrDefault();

            try
            {
                personagemItem.Codigo = ultimoCodigo + 1;
                _appDbContext.PersonagemItens.Add(personagemItem);
                _appDbContext.SaveChanges();

                return Ok("Personagem Item cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao incluir o Personagem Item. " + ex.Message);
            }
        }

        // Não vai ter put

        [HttpDelete("{codigo}")]
        public IActionResult DeletePersonagemItem([FromRoute] int codigo)
        {
            var personagemItemExiste = _appDbContext.PersonagemItens.Where(x => x.Codigo == codigo).FirstOrDefault();
            if (personagemItemExiste != null)
            {
                try
                {

                    _appDbContext.PersonagemItens.Remove(personagemItemExiste);
                    _appDbContext.SaveChanges();

                    return Ok("Personagem Item excluído com sucesso!");
                }
                catch (Exception ex)
                {
                    return BadRequest("Erro ao excluir o PersonagemItem. " + ex.Message);
                }
            }
            else
            {
                return NotFound("Personagem Item Atributo não encontrado!");
            }

        }
    }
}
