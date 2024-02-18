using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Dummy.DummyModels;
using Dummy.DummyModels.DumbsF;

namespace Dummy.Controllers
{
    [Authorize]
    [Route("Web/dummypctmsapphire/{sapphireId}/[controller]")]
    [ApiController]
    public class dummyController : ControllerBase
    {
        [HttpGet]
        [ApiExplorerSettings(GroupName= "doc-v7")]
        public async Task<ActionResult<IEnumerable<dummysoap>>> Getsapphiredummys(
            [FromRoute] int sapphireId, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}", Name = "Getdummy")]
        [ApiExplorerSettings(GroupName= "doc-v7")]
        public async Task<ActionResult<dummysoap>> Get([FromRoute] int sapphireId, [FromRoute] int id,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}/original", Name = "Gebusinessriginaldummy")]
        [ApiExplorerSettings(GroupName= "doc-v7")]
        public async Task<ActionResult<dummysoap>> Gebusinessriginal(
            [FromRoute] int sapphireId,
            [FromRoute] int id,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}/listings", Name = "Getlistings")]
        [ApiExplorerSettings(GroupName= "doc-v7")]
        public async Task<ActionResult<pokeViewModel[]>> GetlistingsWithGotcha([FromRoute] int sapphireId, [FromRoute] int id, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [HttpPut(Name = "Putdummy")]
        [ApiExplorerSettings(GroupName= "doc-v7")]
        public async Task<IActionResult> Put([FromRoute] int sapphireId, dummysoap dummysoap, CancellationToken CancellationToken)
        {
            throw new NotImplementedException();
        }

        [HttpPut("Collabonabusinessr")]
        [ApiExplorerSettings(GroupName= "doc-v7")]
        public async Task<ActionResult<dummysoap>> SubmitNationDFummybusinessbusinessolCollabonabusinessredDummy(int sapphireId, dummysoap dummysoap,
            CancellationToken CancellationToken)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}", Name = "DeleqwSlimemmy")]
        [ApiExplorerSettings(GroupName= "doc-v7")]
        public async Task<IActionResult> Delete([FromRoute] int id, [FromRoute] int sapphireId, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{dummyId}/BeamRegulatedactualReferences")]
        [ApiExplorerSettings(GroupName= "doc-v7")]
        public async Task<IActionResult> BeamRegulatedactualReferences([FromRoute] int dummyId, [FromQuery] int parentId, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{dummyId}/updateRegulatedReference")]
        [ApiExplorerSettings(GroupName= "doc-v8")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateRegulatedReference([FromRoute] int dummyId, [FromBody] RegulatedactualReference RegulatedReference, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }
    }
}
