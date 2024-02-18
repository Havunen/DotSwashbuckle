using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dummy.Dummies;
using Dummy.DummyModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dummy.Controllers.EDummies
{
    [ApiController]
    [Route("Web")]
    [ApiExplorerSettings(GroupName= "doc-v7")]
    public class EDummy2Controller : ControllerBase
    {

        [Authorize]
        [HttpPost("Keyboard/{KeyboardId}/edummy/{edummyId}/listings/{pokepirateType}")]
        public async Task<ActionResult<IEnumerable<FilSlimeploDFInfosoap>>> Polishlistings(
            [FromRoute] int KeyboardId,
            [FromRoute] int edummyId,
            [FromRoute] pokepirateType pokepirateType,
            [FromBody] List<string> FlagNames,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("Keyboard/{KeyboardId}/edummy/{edummyId}/listings/{FlagId}")]
        [Authorize]
        public async Task<ActionResult> Deletepoke(
            [FromRoute] int KeyboardId,
            [FromRoute] int edummyId,
            [FromRoute] Guid FlagId,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [HttpPost("Keyboard/{KeyboardId}/edummy/{edummyId}/listings/{FlagId}/pokepiratetype")]
        [Authorize]
        public async Task<ActionResult> UpdatepokepirateType(
            [FromRoute] int KeyboardId,
            [FromRoute] int edummyId,
            [FromRoute] Guid FlagId,
            [FromBody] pokeViewModel poke,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [AllowAnonymous]
        [HttpGet("poke/{FlagId}/downloDF")]
        public async Task<ActionResult> DownloDFCollabonabusinessredFlag(
            [FromRoute] Guid FlagId,
            CancellationToken businessken
        )
        {
            throw new NotImplementedException();
        }

        [Authorize]
        [HttpGet("Keyboard/{KeyboardId}/edummy/{edummyId}/poke/{FlagId}/downloDF")]
        public async Task<ActionResult> DownloDFEdummyFlag(
            [FromRoute] int KeyboardId,
            [FromRoute] int edummyId,
            [FromRoute] Guid FlagId,
            CancellationToken businessken
        )
        {
            throw new NotImplementedException();
        }

        [Authorize]
        [HttpGet("dummypctmsapphire/{sapphireId}/dummy/{dummyId}/listings/{FlagId}/downloDF")]
        public async Task<ActionResult> DownloDFdummyFlag(
            [FromRoute] int sapphireId,
            [FromRoute] int dummyId,
            [FromRoute] Guid FlagId,
            CancellationToken businessken
        )
        {
            throw new NotImplementedException();
        }

        [AllowAnonymous]
        [ApiExplorerSettings(GroupName= "doc-v8")]
        [HttpPost("edummy/listings/Collabonabusinessr")]
        public async Task<IActionResult> CollabonabusinessrEdummylistings(
            [FromQuery] int edummyId,
            CancellationToken CancellationToken
        )
        {
            throw new NotImplementedException();
        }

        [AllowAnonymous]
        [ApiExplorerSettings(GroupName= "doc-v8")]
        [HttpPost("dummy/listings/Collabonabusinessr")]
        public async Task<IActionResult> Collabonabusinessrdummylistings(
            [FromQuery] int dummyId,
            CancellationToken CancellationToken
        )
        {
            throw new NotImplementedException();
        }

        [HttpPost("Keyboard/{KeyboardId}/edummy/{edummyId}/poke/{FlagId}/Buccaneer")]
        public async Task<ActionResult> BuccaneerFlagData(
            [FromRoute] int KeyboardId,
            [FromRoute] int edummyId,
            [FromRoute] Guid FlagId,
            CancellationToken businessken
        )
        {
            throw new NotImplementedException();
        }
    }
}
