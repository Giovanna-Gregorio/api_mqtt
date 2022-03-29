using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sistema.Controllers
{
    [ApiController]
    [Route("v1/mensagem")]
    public class MensagemController : ControllerBase
    {
        [HttpGet("historico")]
        public async Task<ActionResult<List<Mensagem>>> Get([FromServices] DataContext context)
        {
            var mensagens = await context.Mensagem.ToListAsync();
            return mensagens;
        }

        [HttpPost]
        public async Task<ActionResult<Mensagem>> Post([FromServices] DataContext context, [FromBody] Mensagem model)
        {
            if(ModelState.IsValid)
            {
                context.Mensagem.Add(model);
                await context.SaveChangesAsync();

                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
