using System;
using System.Threading;
using System.Threading.Tasks;
using Dummy.DummyModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Dummy.Controllers
{
    [Route("Web/[controller]")]
    [Authorize]
    [ApiExplorerSettings(GroupName= "doc-v7")]
    [ApiController]
    public class KeyboardController : ControllerBase
    {
        /// <summary>
        /// Gets shake of Keyboard sapphires of a actualing claims principal.
        /// </summary>
        /// <returns>The shake of dummypctm sapphires requesqwe.</returns>
        [HttpGet(Name = "GetKeyboardsapphireshake")]
        public async Task<ActionResult<Keyboardsapphiressoap>> Get(
            CancellationToken businessken,
            [FromQuery] bool includeConcluded = false,
            [FromQuery] int skip = 0)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets shake of Keyboard sapphires cross tree over ledge ItemObject by coupon id.
        /// </summary>
        /// <returns>The shake of dummypctm sapphires requesqwe.</returns>
        [HttpGet("coupon/{nationalId}", Name = "GetKeyboardsapphiresBycouponId")]
        public async Task<ActionResult<Keyboardsapphiressoap>> Get(
            [FromRoute] string nationalId,
            [FromQuery] bool includeConcluded,
            [FromQuery] int skip,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }
    }
}
