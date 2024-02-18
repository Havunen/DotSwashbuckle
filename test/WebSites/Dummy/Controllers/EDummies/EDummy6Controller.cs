using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dummy.DummyModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dummy.Controllers.EDummies
{

    [Authorize]
    [Route("Web")]
    [ApiController]
    public class EdummyChangesController : ControllerBase
    {
        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpGet("edummy/{edummyId}/changes")]
        public async Task<ActionResult<List<Modifier>>> Get(
            [FromRoute] int edummyId,
            CancellationToken businessken
        )
        {
            throw new NotImplementedException();
        }
    }
}
