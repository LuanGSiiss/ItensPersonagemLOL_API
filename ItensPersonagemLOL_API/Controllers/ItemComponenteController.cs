using ItensPersonagemLOL_API.Data;
using ItensPersonagemLOL_API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ItensPersonagemLOL_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemComponenteController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public ItemComponenteController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public List<ItemComponente> GetItemComponente()
        {
            var lista = _appDbContext.ItemComponente
                .OrderBy(c => c.Codigo)
                .ToList();

            return lista;
        }

        [HttpPost]
        public IActionResult PostItemComponente([FromBody] ItemComponente itemComponente)
        {
            //itemcodigo componentecodigo
            var ultimoCodigo = _appDbContext.ItemComponente
            .OrderByDescending(i => i.Codigo)
            .Select(i => i.Codigo)
            .FirstOrDefault();


            try
            {
                itemComponente.Codigo = ultimoCodigo + 1;
                _appDbContext.ItemComponente.Add(itemComponente);
                _appDbContext.SaveChanges();

                return Ok("Item Componente cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao incluir o Item Componente. " + ex.Message);
            }
        }
        //Não havera post

        [HttpDelete("{codigo}")]
        public IActionResult DeleteItemComponente([FromRoute] int codigo)
        {
            var itemComponenteExiste = _appDbContext.ItemComponente.Where(x => x.Codigo == codigo).FirstOrDefault();
            if (itemComponenteExiste != null)
            {
                try
                {

                    _appDbContext.ItemComponente.Remove(itemComponenteExiste);
                    _appDbContext.SaveChanges();

                    return Ok("Item Componente excluído com sucesso!");
                }
                catch (Exception ex)
                {
                    return BadRequest("Erro ao excluir o Item Componente. " + ex.Message);
                }
            }
            else
            {
                return NotFound("Item Componente não encontrado!");
            }

        }
    }
}
