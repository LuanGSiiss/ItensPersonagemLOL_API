using ItensPersonagemLOL_API.Data;
using ItensPersonagemLOL_API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace ItensPersonagemLOL_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public ItemController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public List<Item> GetItem()
        {
            var lista = _appDbContext.Item
                .Include(i => i.Classe)
                .Include(i => i.EfeitosPassivo)
                .Include(i => i.ItemAtributos)
                .Include(i => i.Componentes)
                .Include(i => i.UsadoEm)
                .OrderBy(c => c.Codigo)
                .ToList();

            return lista;
        }

        [HttpPost]
        public IActionResult PostItem([FromBody] Item item)
        {
            //Nome Preco EfeitoAtivo ClasseCodigo
            try
            {
                _appDbContext.Item.Add(item);
                _appDbContext.SaveChanges();

                return Ok("Item cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao incluir o Item. " + ex.Message);
            }
        }

        [HttpPut]
        public IActionResult PutItem([FromBody] Item item)
        {
            var ItemExiste = _appDbContext.Item.Where(x => x.Codigo == item.Codigo).FirstOrDefault();
            if (ItemExiste != null)
            {
                try
                {
                    ItemExiste.Nome = item.Nome;
                    ItemExiste.Preco = item.Preco;
                    if (ItemExiste.EfeitoAtivo != null)
                    {
                        ItemExiste.EfeitoAtivo = item.EfeitoAtivo;
                    }
                    
                    ItemExiste.ClasseCodigo = item.ClasseCodigo;

                    _appDbContext.Item.Update(ItemExiste);
                    _appDbContext.SaveChanges();

                    return Ok("Item alterado com sucesso!");
                }
                catch (Exception ex)
                {
                    return BadRequest("Erro ao alterar o Item. " + ex.Message);
                }
            }
            else
            {
                return NotFound("Item não encontrado!");
            }


        }

        [HttpDelete("{codigo}")]
        public IActionResult DeleteItem([FromRoute] int codigo)
        {
            var itemExiste = _appDbContext.Item.Where(x => x.Codigo == codigo).FirstOrDefault();
            if (itemExiste != null)
            {
                try
                {

                    _appDbContext.Item.Remove(itemExiste);
                    _appDbContext.SaveChanges();

                    return Ok("Item excluído com sucesso!");
                }
                catch (Exception ex)
                {
                    return BadRequest("Erro ao excluir o Item. " + ex.Message);
                }
            }
            else
            {
                return NotFound("Item não encontrado!");
            }

        }
    }
}
