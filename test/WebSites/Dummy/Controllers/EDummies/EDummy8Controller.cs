using System;
using System.Threading;
using System.Threading.Tasks;
using Dummy.DummyModels.DumbsC;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dummy.Controllers.EDummies
{

    [Authorize]
    [Route("Web")]
    [ApiController]
    public class EdummyConversionController : ControllerBase
    {
        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpPost("dummypctmsapphire/{sapphireId}/dummy/{dummyId}/convert")]
        public async Task<ActionResult<Edummysoap>> ConverbusinesslddummybusinessEdummy(
            [FromRoute] int sapphireId,
            [FromRoute] int dummyId,
            [FromBody] ConvertbusinessEDummyoap soap,
            CancellationToken businessken
        )
        {
            throw new NotImplementedException();
        }
    }
}
