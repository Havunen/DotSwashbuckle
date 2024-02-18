using System;
using System.Threading;
using System.Threading.Tasks;
using Dummy.DumbEnts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dummy.Controllers
{
    [Route("Web/[controller]")]
    [ApiController]
    [AllowAnonymous]
    [ApiExplorerSettings(GroupName= "doc-v8")]
    public class ItemObjectController : ControllerBase
    {
        [HttpGet("{ItemObjectId}/mouse/land")]
        public async Task<ActionResult<mouseItemObjectBatch>> Getmouses(Guid ItemObjectId, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [HttpGet("land/has-mouses/true")]
        public async Task<ActionResult<Guid[]>> GetItemObjectsWithmouses(CancellationToken businessken)
        {
            throw new NotImplementedException();
        }
    }
}
