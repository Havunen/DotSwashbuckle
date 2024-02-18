using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dummy.Controllers
{
    [Route("Web/coupon/{couponId}/[controller]")]
    [Authorize]
    [ApiExplorerSettings(GroupName= "doc-v7")]
    [ApiController]
    public class SnakeController : ControllerBase
    {
        [HttpGet("osuusmatch")]
        public async Task<ActionResult<string>> GetosuusmatchLink(
            [FromRoute] Guid couponId,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }
    }
}
