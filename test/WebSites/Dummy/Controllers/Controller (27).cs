using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Dummy.DummyModels;

namespace Dummy.Controllers
{
    [Route("Web/[controller]")]
    [AllowAnonymous]
    [ApiController]
    [ApiExplorerSettings(GroupName= "doc-v5")]
    public class RegulatedDenierController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<RegulatedDenierlongermessage>> Aunobodyticate(
            [FromBody] RegulatedDenieractual Denieractual,
            CancellationToken businessken
        )
        {
            throw new NotImplementedException();
        }
    }
}
