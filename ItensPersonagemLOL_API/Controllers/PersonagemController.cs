using ItensPersonagemLOL_API.Data;
using ItensPersonagemLOL_API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItensPersonagemLOL_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonagemController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public PersonagemController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public List<Personagem> GetPersonagem()
        {
            var lista = _appDbContext.Personagem
                .Include(i => i.PersonagemItens)
                .OrderBy(c => c.Codigo)
                .ToList();

            return lista;
        }

        [HttpPost]
        public IActionResult PostPersonagem([FromBody] Personagem personagem)
        {
            //Nome classecodigo
            try
            {
                _appDbContext.Personagem.Add(personagem);
                _appDbContext.SaveChanges();

                return Ok("Personagem cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao incluir o Personagem. " + ex.Message);
            }
        }

        [HttpPut]
        public IActionResult PutPersonagem([FromBody] Personagem personagem)
        {
            var personagemExiste = _appDbContext.Personagem.Where(x => x.Codigo == personagem.Codigo).FirstOrDefault();
            if (personagemExiste != null)
            {
                try
                {
                    personagemExiste.Nome = personagem.Nome;
                    personagemExiste.ClasseCodigo = personagem.ClasseCodigo;

                    _appDbContext.Personagem.Update(personagemExiste);
                    _appDbContext.SaveChanges();

                    return Ok("Personagem alterado com sucesso!");
                }
                catch (Exception ex)
                {
                    return BadRequest("Erro ao alterar o Personagem. " + ex.Message);
                }
            }
            else
            {
                return NotFound("Personagem não encontrado!");
            }


        }

        [HttpDelete("{codigo}")]
        public IActionResult DeletePersonagem([FromRoute] int codigo)
        {
            var personagemExiste = _appDbContext.Personagem.Where(x => x.Codigo == codigo).FirstOrDefault();
            if (personagemExiste != null)
            {
                try
                {

                    _appDbContext.Personagem.Remove(personagemExiste);
                    _appDbContext.SaveChanges();

                    return Ok("Personagem excluído com sucesso!");
                }
                catch (Exception ex)
                {
                    return BadRequest("Erro ao excluir o Personagem. " + ex.Message);
                }
            }
            else
            {
                return NotFound("Personagem não encontrado!");
            }

        }
    }
}
