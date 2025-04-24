using ItensPersonagemLOL_API.Data;
using ItensPersonagemLOL_API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ItensPersonagemLOL_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClasseController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public ClasseController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public List<Classe> GetClasse()
        {
            var lista = _appDbContext.Classe.OrderBy(c => c.Codigo).ToList();

            return lista;
        }

        [HttpPost]
        public IActionResult PostClasse([FromBody] Classe classe)
        {
            try
            {
                _appDbContext.Classe.Add(classe);
                _appDbContext.SaveChanges();

                return Ok("Classe cadastrada com sucesso");
            } catch (Exception ex)
            {
                return BadRequest("Erro ao incluir Classe. " + ex.Message);
            }
        }

        [HttpPut]
        public IActionResult PutClasse([FromBody] Classe classe)
        {
            var classeExiste = _appDbContext.Classe.Where(x => x.Codigo == classe.Codigo).FirstOrDefault();
            if (classeExiste != null)
            {
                try
                {
                    classeExiste.Descricao = classe.Descricao;
                    _appDbContext.Classe.Update(classeExiste);
                    _appDbContext.SaveChanges();

                    return Ok("Classe alterada com sucesso!");
                }
                catch (Exception ex)
                {
                    return BadRequest("Erro ao alterar a Classe. " + ex.Message);
                }
            }
            else
            {
                return NotFound("Classe não encontrado!");
            }


        }

        [HttpDelete("{codigo}")]
        public IActionResult DeleteClasse([FromRoute] int codigo)
        {
            var classeExiste = _appDbContext.Classe.Where(x => x.Codigo == codigo).FirstOrDefault();
            if (classeExiste != null)
            {
                try
                {
                    
                    _appDbContext.Classe.Remove(classeExiste);
                    _appDbContext.SaveChanges();

                    return Ok("Classe excluída com sucesso!");
                }
                catch (Exception ex)
                {
                    return BadRequest("Erro ao excluir a Classe. " + ex.Message);
                }
            }
            else
            {
                return NotFound("Classe não encontrado!");
            }


        }
    }
}
