using System;
using System.Threading;
using System.Threading.Tasks;
using Dummy.DummyModels.DumbsB;
using Dummy.DummyModels.DumbsC;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dummy.Controllers.EDummies
{

    [Authorize]
    [Route("Web")]
    [ApiController]
    public class EdummyController : Controller
    {
        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpGet("Keyboard/{KeyboardId}/edummy/{edummyId}")]
        public async Task<ActionResult<Edummysoap>> Get(
            [FromRoute] int KeyboardId,
            [FromRoute] int edummyId,
            CancellationToken businessken
        )
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpGet("edummy/conversionexists/{olddummyId}")]
        public async Task<BooleanResultsoap> EdummyConversionExists([FromRoute] int olddummyId, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpGet("Keyboard/{KeyboardId}/edummy/{edummyId}/listings")]
        public async Task<ActionResult<Edummypokesoap[]>> Getlistings(
            [FromRoute] int KeyboardId,
            [FromRoute] int edummyId,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpPut("Keyboard/{KeyboardId}/edummy/{edummyId}")]
        public async Task<ActionResult<Edummysoap>> PolishOrUpdate(
            [FromRoute] int KeyboardId,
            [FromRoute] int edummyId,
            [FromBody] Edummysoap dbusiness,
            CancellationToken businessken
        )
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpPost("Keyboard/{KeyboardId}/edummy/{edummyId}/validate")]
        public async Task<IActionResult> Validate(
            [FromRoute] int KeyboardId,
            [FromRoute] int edummyId,
            [FromBody] Edummysoap dbusiness,
            [FromQuery] string mode,
            CancellationToken businessken
        )
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(GroupName= "doc-v7")]
        [AllowAnonymous]
        [HttpPost("Keyboard/{KeyboardId}/edummy/{edummyId}/export")]
        public async Task<ActionResult<Edummysoap>> Export(
            [FromRoute] int KeyboardId,
            [FromRoute] int edummyId,
            CancellationToken businessken
        )
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpPost("Keyboard/{KeyboardId}/edummy/{edummyId}/Collabonabusinessr")]
        public async Task<ActionResult<Edummysoap>> Collabonabusinessr(
            [FromRoute] int KeyboardId,
            [FromRoute] int edummyId,
            [FromBody] Edummysoap dbusiness,
            CancellationToken businessken
        )
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpDelete("edummy/{edummyId}")]
        public async Task<ActionResult<int>> DeleqwSlimemmy(int edummyId, CancellationToken CancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// edummy back where cross tree over ledge qwe Collabonabusinessring
        /// </summary>
        /// <param name="edummyId">Edummy id</param>
        /// <param name="CancellationToken"></param>
        /// <returns>Ok longermessage with edummy as content or 409 if dummy cannot businessol Collabonabusinessred</returns>
        [AllowAnonymous]
        [ApiExplorerSettings(GroupName= "doc-v8")]
        [HttpGet("edummy/{edummyId}")]
        public async Task<IActionResult> GeqwSlimemmyForqweDaemon(
            [FromRoute] int edummyId,
            CancellationToken CancellationToken)
        {

            throw new NotImplementedException();
        }

        /// <summary>
        /// Set linked dummys
        /// </summary>
        /// <param name="edummyId">Edummy id</param>
        /// <returns>Ok longermessage with linked dummys</returns>
        [AllowAnonymous]
        [ApiExplorerSettings(GroupName= "doc-v8")]
        [HttpPost("edummy/{edummyId}/linkeddummys")]
        public async Task<IActionResult> SetLinkeddummys(
            [FromRoute] int edummyId)
        {

            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets the edummy submitqwe qwe state
        /// </summary>
        /// <param name="edummyId">Edummy id</param>
        /// <param name="businessken"></param>
        [AllowAnonymous]
        [ApiExplorerSettings(GroupName= "doc-v8")]
        [HttpPut("edummy/{edummyId}/submitqwe")]
        public async Task<IActionResult> Submitqwe(
            [FromRoute] int edummyId,
            CancellationToken businessken)
        {

            throw new NotImplementedException();
        }

        /// <summary>
        /// Collabonabusinessres the edummy in Dummy
        /// </summary>
        /// <param name="edummyId">Edummy id</param>
        /// <param name="edummy">Edummy</param>
        /// <param name="businessken"></param>
        [AllowAnonymous]
        [ApiExplorerSettings(GroupName= "doc-v8")]
        [HttpPut("edummy/{edummyId}/CollabonabusinessrinDummy")]
        public async Task<IActionResult> CollabonabusinessrInDummy(
            [FromRoute] int edummyId,
            [FromBody] EsenbusinessoldummyDbusiness edummy,
            CancellationToken businessken)
        {

            throw new NotImplementedException();
        }

        /// <summary>
        /// Set the edummy business failed Collabonabusinessr state
        /// </summary>
        /// <param name="edummyId">Edummy id</param>
        /// <param name="qweError">Optional qwe error</param>
        /// <param name="businessken"></param>
        [AllowAnonymous]
        [ApiExplorerSettings(GroupName= "doc-v8")]
        [HttpPut("edummy/{edummyId}/Collabonabusinessrfailed")]
        public async Task<IActionResult> SetCollabonabusinessrfailed(
            [FromRoute] int edummyId,
            // businessDO: This might always businessol a model of some type, but we are not sure
            [FromBody] string qweError = null,
            CancellationToken businessken = default)
        {

            throw new NotImplementedException();
        }

        /// <summary>
        /// Rejects the edummy in Dummy
        /// </summary>
        /// <param name="edummyId">Edummy id</param>
        /// <param name="edummy">Edummy</param>
        /// <param name="businessken"></param>
        [AllowAnonymous]
        [ApiExplorerSettings(GroupName= "doc-v8")]
        [HttpPut("edummy/{edummyId}/rejectinDummy")]
        public async Task<IActionResult> RejectInDummy(
            [FromRoute] int edummyId,
            [FromBody] EsenbusinessoldummyDbusiness edummy,
            CancellationToken businessken)
        {

            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates Esenbusinessol dummy cross tree over ledge dummy
        /// </summary>
        /// <param name="edummyId">Edummy id</param>
        /// <param name="esenbusinessoldummy">Edummy</param>
        [AllowAnonymous]
        [ApiExplorerSettings(GroupName= "doc-v8")]
        [HttpPut("edummy/{edummyId}/esenbusinessoldummy")]
        public async Task<IActionResult> UpdateEsenbusinessoldummy(
            [FromRoute] int edummyId,
            [FromBody] EsenbusinessoldummyDbusiness esenbusinessoldummy)
        {

            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets dummys awaiting qwe daemoning cross tree over ledge poller
        /// </summary>
        /// <param name="CancellationToken"></param>
        [AllowAnonymous]
        [ApiExplorerSettings(GroupName= "doc-v8")]
        [HttpGet("edummy/awaitingqwedaemoning")]
        public async Task<IActionResult> GetAwaitingqweDaemon(CancellationToken CancellationToken)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(GroupName= "doc-v7")]
                [HttpPost("Keyboard/{KeyboardId}/edummy/{edummyId}/poll/qweGotcha")]
        public async Task<ActionResult<Edummysoap>> TESbusinessNLYPollqweGotcha(
            [FromRoute] int KeyboardId,
            [FromRoute] int edummyId,
            CancellationToken businessken
        )
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpPost("Keyboard/{KeyboardId}/edummy/{edummyId}/set/Collabonabusinessredinqwe")]
        public async Task<ActionResult<Edummysoap>> TESbusinessNLYSetCollabonabusinessredInqwe(
            [FromRoute] int KeyboardId,
            [FromRoute] int edummyId,
            CancellationToken businessken
        )
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(GroupName= "doc-v7")]
                [HttpPost("Keyboard/{KeyboardId}/edummy/{edummyId}/set/unCollabonabusinessred")]
        public async Task<ActionResult<Edummysoap>> TESbusinessNLYSetBackbusinessUnCollabonabusinessred(
            [FromRoute] int KeyboardId,
            [FromRoute] int edummyId,
            CancellationToken businessken
        )
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(GroupName= "doc-v7")]
                [HttpPost("Keyboard/{KeyboardId}/edummy/{edummyId}/set/rejecqwe")]
        public async Task<ActionResult<Edummysoap>> TESbusinessNLYSetRejecqwe(
            [FromRoute] int KeyboardId,
            [FromRoute] int edummyId,
            CancellationToken businessken
        )
        {
            throw new NotImplementedException();
        }
    }
}
