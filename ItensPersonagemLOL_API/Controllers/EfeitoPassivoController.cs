using ItensPersonagemLOL_API.Data;
using ItensPersonagemLOL_API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItensPersonagemLOL_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EfeitoPassivoController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public EfeitoPassivoController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public List<EfeitoPassivo> GetEfeitosPassivo()
        {
            var lista = _appDbContext.EfeitosPassivo
                
                .OrderBy(c => c.Codigo)
                .ToList();

            return lista;
        }

        [HttpPost]
        public IActionResult PostEfeitosPassivo([FromBody] EfeitoPassivo efeitoPassivo)
        {
            //nome descricao itemcodigo
            try
            {
                _appDbContext.EfeitosPassivo.Add(efeitoPassivo);
                _appDbContext.SaveChanges();

                return Ok("Efeito Passivo cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao incluir o Efeito Passivo. " + ex.Message);
            }
        }

        [HttpPut]
        public IActionResult PutEfeitosPassivo([FromBody] EfeitoPassivo efeitoPassivo)
        {
            var efeitoPassivoExiste = _appDbContext.EfeitosPassivo.Where(x => x.Codigo == efeitoPassivo.Codigo).FirstOrDefault();
            if (efeitoPassivoExiste != null)
            {
                try
                {
                    efeitoPassivoExiste.Nome = efeitoPassivo.Nome;
                    efeitoPassivoExiste.Descricao = efeitoPassivo.Descricao;
                    efeitoPassivoExiste.ItemCodigo = efeitoPassivo.ItemCodigo;
                    
                    _appDbContext.EfeitosPassivo.Update(efeitoPassivoExiste);
                    _appDbContext.SaveChanges();

                    return Ok("Efeito Passivo alterado com sucesso!");
                }
                catch (Exception ex)
                {
                    return BadRequest("Erro ao alterar o Efeito Passivo. " + ex.Message);
                }
            }
            else
            {
                return NotFound("Efeito Passivo não encontrado!");
            }


        }

        [HttpDelete("{codigo}")]
        public IActionResult DeleteEfeitosPassivo([FromRoute] int codigo)
        {
            var efeitoPassivoExiste = _appDbContext.EfeitosPassivo.Where(x => x.Codigo == codigo).FirstOrDefault();
            if (efeitoPassivoExiste != null)
            {
                try
                {

                    _appDbContext.EfeitosPassivo.Remove(efeitoPassivoExiste);
                    _appDbContext.SaveChanges();

                    return Ok("Efeito Passivo excluído com sucesso!");
                }
                catch (Exception ex)
                {
                    return BadRequest("Erro ao excluir o Efeito Passivo. " + ex.Message);
                }
            }
            else
            {
                return NotFound("Efeito Passivo não encontrado!");
            }

        }
    }
}
