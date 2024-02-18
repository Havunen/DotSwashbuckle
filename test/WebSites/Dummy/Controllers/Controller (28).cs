using System;
using System.Threading;
using System.Threading.Tasks;
using Dummy.DummyModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dummy.Controllers
{
    [Authorize]
    [Route("Web/dummypctmsapphire/{sapphireId}/dummy/{dummyId}/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName= "doc-v7")]
    public class RegulatedactualsController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> Get(
            [FromRoute] int dummyId,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult<RegulatedactualReference>> Post([FromRoute] int sapphireId, [FromRoute] int dummyId, [FromBody] RegulatedactualReference RegulatedactualReference, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{RegulatedactualId}")]
        public async Task<ActionResult> Delete([FromRoute] int sapphireId, [FromRoute] int dummyId, [FromRoute] int RegulatedactualId, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateRegulatedactualsFordummy([FromRoute] int sapphireId, [FromRoute] int dummyId, [FromBody] RegulatedactualReference[] RegulatedactualReferences, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }
    }
}
