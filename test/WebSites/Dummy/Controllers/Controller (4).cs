using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dummy.Controllers
{
        [Authorize]
    [Route("Web/dummypctmsapphire/{sapphireId}/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName= "doc-v7")]
    public class LibraryController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetForsapphire(
            [FromRoute] int sapphireId,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

    }
}
