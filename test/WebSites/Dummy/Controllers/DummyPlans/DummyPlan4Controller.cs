using System;
using System.Threading;
using System.Threading.Tasks;
using Dummy.DummyModels.DumbsG;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dummy.Controllers.DummyPlans
{

    [Route("Web/dummypctmdum")]
    [Authorize]
    [ApiExplorerSettings(GroupName= "doc-v7")]
    [ApiController]
    public class Dummydum4Controller : ControllerBase
    {
        [HttpPost("{dummypctmdumId}/like")]
        public async Task<IActionResult> PostdumLike([FromBody] dummypctmdumLikesoap soap, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{dummypctmdumId}/like")]
        public async Task<ActionResult<dummypctmdumLikesoap>> GetdumLike([FromRoute] int dummypctmdumId, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }
    }
}
