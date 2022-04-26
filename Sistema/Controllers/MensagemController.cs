using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using System.Threading;
using Microsoft.AspNetCore.SignalR;
using Sistema.Hubteste;
using Sistema.Data;

namespace Sistema.Controllers
{
    [ApiController]
    [Route("v1/MensagemBroker")]
    public class MensagemBrokerController : ControllerBase
    {
        private readonly IHubContext<MyHub> hubContext;
        // List<MensagemBroker> ListaMensagem = new List<MensagemBroker>();

        public MensagemBrokerController(IHubContext<MyHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        [HttpGet]
        [Route("")]

        public async Task<ActionResult<List<Mensagem>>> Get([FromServices] DataContext context)
        {
            Thread.Sleep(1000);
            var mensagens = await context.Mensagem.ToListAsync();
            return mensagens;
        }

        [HttpPost]
        [Route("")]

        public async Task<ActionResult<Mensagem>> Post([FromServices] DataContext context, [FromBody] Mensagem model)
        {
            if (ModelState.IsValid)
            {
                context.Mensagem.Add(model);
                await hubContext.Clients.All.SendAsync("post", model);
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