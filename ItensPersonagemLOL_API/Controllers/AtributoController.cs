using ItensPersonagemLOL_API.Data;
using ItensPersonagemLOL_API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ItensPersonagemLOL_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtributoController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public AtributoController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public List<Atributo> GetAtributo()
        {
            var lista = _appDbContext.Atributo.OrderBy(c => c.Codigo).ToList();

            return lista;
        }

        [HttpPost]
        public IActionResult PostAtributo([FromBody] Atributo atributo)
        {
            //Pode assumir "Absoluto" ou "Porcentagem"
            if (atributo.Apresentacao != "Absoluto" && atributo.Apresentacao != "Porcentagem")
            {
                return BadRequest("Campo 'Apresentação' pode assumir somente \"Absoluto\" ou \"Porcentagem\"");
            } else
            {
                try
                {
                    _appDbContext.Atributo.Add(atributo);
                    _appDbContext.SaveChanges();

                    return Ok("Atributo cadastrado com sucesso");
                }
                catch (Exception ex)
                {
                    return BadRequest("Erro ao incluir Atributo. " + ex.Message);
                }
            }
                
        }

        [HttpPut]
        public IActionResult PutAtributo([FromBody] Atributo atributo)
        {
            var atributoExiste = _appDbContext.Atributo.Where(x => x.Codigo == atributo.Codigo).FirstOrDefault();
            if (atributoExiste != null)
            {
                try
                {
                    atributoExiste.Descricao = atributo.Descricao;
                    atributoExiste.Apresentacao = atributo.Apresentacao;
                    if (atributo.Apresentacao != "Absoluto" && atributo.Apresentacao != "Porcentagem")
                    {
                        return BadRequest("Campo 'Apresentação' pode assumir somente \"Absoluto\" ou \"Porcentagem\"");
                    }
                    
                    _appDbContext.Atributo.Update(atributoExiste);
                    _appDbContext.SaveChanges();

                    return Ok("Atributo alterado com sucesso!");
                }
                catch (Exception ex)
                {
                    return BadRequest("Erro ao alterar o Atributo. " + ex.Message);
                }
            }
            else
            {
                return NotFound("Atributo não encontrado!");
            }


        }

        [HttpDelete("{codigo}")]
        public IActionResult DeleteAtributo([FromRoute] int codigo)
        {
            var atributoExiste = _appDbContext.Atributo.Where(x => x.Codigo == codigo).FirstOrDefault();
            if (atributoExiste != null)
            {
                try
                {

                    _appDbContext.Atributo.Remove(atributoExiste);
                    _appDbContext.SaveChanges();

                    return Ok("Atributo excluído com sucesso!");
                }
                catch (Exception ex)
                {
                    return BadRequest("Erro ao excluir o Atributo. " + ex.Message);
                }
            }
            else
            {
                return NotFound("Atributo não encontrado!");
            }


        }
    }
}
