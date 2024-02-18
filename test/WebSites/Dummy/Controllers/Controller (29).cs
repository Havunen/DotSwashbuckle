using System;
using System.Threading;
using System.Threading.Tasks;
using Dummy.DummyModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dummy.Controllers
{
    [Route("Web/[controller]")]
    [ApiController]
    [AllowAnonymous]
    [ApiExplorerSettings(GroupName= "doc-v8")]
    public class EventController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> PostEvent(
            [FromBody] Eventsoap soap,
            CancellationToken CancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
