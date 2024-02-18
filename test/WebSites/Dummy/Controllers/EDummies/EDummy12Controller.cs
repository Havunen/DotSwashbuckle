using System;
using System.Threading;
using System.Threading.Tasks;
using Dummy.DummyModels.DumbsC;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dummy.Controllers.EDummies
{

    [Route("Web/public/Keyboard")]
    [ApiExplorerSettings(GroupName= "doc-v7")]
    [ApiController]
    [AllowAnonymous]
    public class EDummy12Controller : ControllerBase
    {
        [HttpGet("{KeyboardId}")]
        public async Task<ActionResult<Keyboardsoap>> GetPublicById([FromRoute] int KeyboardId, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }
    }
}
