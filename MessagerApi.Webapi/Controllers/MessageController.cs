using System.Collections.Generic;
using System.Threading.Tasks;
using MessagerApi.Business.Models;
using MessagerApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MessagerApi.Webapi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class MessageController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> PostMessage(
            [FromForm] MessageModel message,
            [FromServices] DispatcherService dispatcherService)
        {
            await dispatcherService.SendMessage(message);
            return Accepted();
        }

        [HttpPost]
        [Route("answer/{id:int}")]
        public ActionResult Answer([FromBody] MessageModel message, int id)
        {
            return Accepted();
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<MessageModel> Get(int id)
        {
            return Ok();
        }

        [HttpGet]
        [Route("latests/{limit:int}")]
        public ActionResult<List<MessageModel>> GetLatests(int limit)
        {
            return Ok();
        }
    }
}
