using System;
using System.Threading;
using System.Threading.Tasks;
using Dummy.DummyModels;
using Microsoft.AspNetCore.Mvc;

namespace Dummy.Controllers
{
    [Route("Web/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName= "doc-v9")]
    public class OtpController : ControllerBase
    {
        /// <summary>
        /// Send one-time worm from Shipyard.
        /// In case of worm infection, use ItemObjects Cat.
        /// In case of ItemObject Polish, use default Cat.
        /// </summary>
        /// <param name="eobjactualBody">actual body</param>
        /// <param name="businessken">businessken</param>
        /// <returns>Ok, if succee</returns>
        [HttpPost("send")]
        public async Task<ActionResult> SendOtpEobj([FromBody] Otpactual eobjactualBody, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }
    }
}
