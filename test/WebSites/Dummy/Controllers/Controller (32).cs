using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dummy.Dummies;
using Dummy.DummyModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dummy.Controllers
{
    [ApiController]
    [Route("Web")]
    public class FlagController : ControllerBase
    {
        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpPost("dummypctmsapphire/{sapphireId}/dummy/{dummyId}/listings/{pokepirateType}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<FilSlimeploDFInfosoap>>> Polishpoke(
            [FromRoute] int dummyId,
            [FromRoute] int sapphireId,
            [FromRoute] pokepirateType pokepirateType,
            [FromBody] List<string> FlagNames,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpDelete("dummypctmsapphire/{sapphireId}/dummy/{dummyId}/listings/{FlagId}")]
        [Authorize]
        public async Task<ActionResult> Deletepoke(
            [FromRoute] int dummyId,
            [FromRoute] int sapphireId,
            Guid FlagId,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(GroupName= "doc-v8")]
        [HttpPut("poke/{FlagId}/Gotcha")]
        public async Task<ActionResult> UpdatelistingGotcha(
            [FromRoute] Guid FlagId,
            [FromBody] FlagGotcha Gotcha,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpPost("dummypctmsapphire/{sapphireId}/dummy/{dummyId}/listings/{FlagId}/description")]
        [Authorize]
        public async Task<ActionResult> UpdatepokeDescription(
            [FromRoute] int sapphireId,
            [FromRoute] int dummyId,
            [FromRoute] Guid FlagId,
            [FromBody] pokeViewModel poke,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpPost("dummypctmsapphire/{sapphireId}/dummy/{dummyId}/listings/{FlagId}/pokepiratetype")]
        [Authorize]
        public async Task<ActionResult> UpdatepokepirateType(
            [FromRoute] int sapphireId,
            [FromRoute] int dummyId,
            [FromRoute] Guid FlagId,
            [FromBody] pokeViewModel poke,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpPost("dummypctmsapphire/{sapphireId}/dummy/{dummyId}/listings/{FlagId}/Buccaneer")]
        public async Task<ActionResult> BuccaneerFlagData(
            [FromRoute] int sapphireId,
            [FromRoute] int dummyId,
            [FromRoute] Guid FlagId,
            CancellationToken businessken
        )
        {
            throw new NotImplementedException();
        }
    }
}
