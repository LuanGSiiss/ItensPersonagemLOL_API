using ItensPersonagemLOL_API.Data;
using ItensPersonagemLOL_API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ItensPersonagemLOL_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemAtributoController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public ItemAtributoController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public List<ItemAtributo> GetItemAtributo()
        {
            var lista = _appDbContext.ItemAtributos
                .OrderBy(c => c.ItemCodigo)
                .ToList();

            return lista;
        }

        [HttpPost]
        public IActionResult PostItemAtributo([FromBody] ItemAtributo itemAtributo)
        {
            //itemcodigo atributocodigo valor
            var ultimoCodigo = _appDbContext.ItemAtributos
            .OrderByDescending(i => i.Codigo)
            .Select(i => i.Codigo)
            .FirstOrDefault();

            
            try
            {
                itemAtributo.Codigo = ultimoCodigo + 1;
                _appDbContext.ItemAtributos.Add(itemAtributo);
                _appDbContext.SaveChanges();

                return Ok("Item Atributo cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao incluir o Item Atributo. " + ex.Message);
            }
        }

        [HttpPut]
        public IActionResult PutItemAtributo([FromBody] ItemAtributo itemAtributo)
        {
            var itemAtributoExiste = _appDbContext.ItemAtributos.Where(x => x.Codigo == itemAtributo.Codigo).FirstOrDefault();
            if (itemAtributoExiste != null)
            {
                try
                {
                    itemAtributoExiste.Valor = itemAtributo.Valor;

                    _appDbContext.ItemAtributos.Update(itemAtributoExiste);
                    _appDbContext.SaveChanges();

                    return Ok("Item Atributo alterado com sucesso!");
                }
                catch (Exception ex)
                {
                    return BadRequest("Erro ao alterar o Item Atributo. " + ex.Message);
                }
            }
            else
            {
                return NotFound("Item Atributo não encontrado!");
            }


        }

        [HttpDelete("{codigo}")]
        public IActionResult DeleteItemAtributo([FromRoute] int codigo)
        {
            var itemAtributoExiste = _appDbContext.ItemAtributos.Where(x => x.Codigo == codigo).FirstOrDefault();
            if (itemAtributoExiste != null)
            {
                try
                {

                    _appDbContext.ItemAtributos.Remove(itemAtributoExiste);
                    _appDbContext.SaveChanges();

                    return Ok("Item Atributo excluído com sucesso!");
                }
                catch (Exception ex)
                {
                    return BadRequest("Erro ao excluir o Item Atributo. " + ex.Message);
                }
            }
            else
            {
                return NotFound("Item Atributo não encontrado!");
            }

        }
    }
}
