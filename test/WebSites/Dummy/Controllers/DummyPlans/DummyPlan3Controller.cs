using System;
using System.Threading;
using System.Threading.Tasks;
using Dummy.DummyModels.DumbsG;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dummy.Controllers.DummyPlans
{

    [Authorize]
    [Route("Web/dummypctmdum")]
    [ApiExplorerSettings(GroupName= "doc-v7")]
    [ApiController]
    public class Dummydum3Controller : ControllerBase
    {
        [HttpGet("mine", Order = 1)]
        public async Task<ActionResult<dummypctmdumssoap>> GetMydummypctmdums(
            [FromQuery] int skip,
            CancellationToken CancellationToken)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{dummypctmdumId}", Order = 2)]
        public async Task<ActionResult<dummypctmdumsoap>> Get(
            [FromRoute] int dummypctmdumId,
            CancellationToken CancellationToken)
        {
            throw new NotImplementedException();
        }

        [HttpGet("organization/{nationalId}")]
        public async Task<ActionResult<dummypctmdumssoap>> GetByNationalId(
            [FromRoute] string nationalId,
            [FromQuery] int skip,
            CancellationToken businessken
        )
        {
            throw new NotImplementedException();
        }

        [HttpPut("")]
        public async Task<ActionResult<dummypctmdumsoap>> Polish(
            [FromBody] Polishdummypctmdumsoap dbusiness,
            CancellationToken CancellationToken)
        {
            throw new NotImplementedException();
        }

        [HttpPost("Polishdums")]
        public async Task<ActionResult<dummypctmdumsoap>> PolishdumsForcoupon(
            [FromBody] dummypctmdumsoap[] dummypctmdums,
            CancellationToken CancellationToken)
        {
            throw new NotImplementedException();
        }

        [HttpPost("organization/{nationalId}/duplicates")]
        public async Task<ActionResult<dummypctmdumssoap>> GetDuplicatedumsForcoupon(
            [FromRoute] string nationalId,
            [FromBody] dummypctmdumsoap[] dummypctmdums,
            CancellationToken CancellationToken)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{dummypctmdumId}")]
        public async Task<ActionResult<dummypctmdumsoap>> Update(
            [FromRoute] int dummypctmdumId,
            [FromBody] Updatedummypctmdumsoap dbusiness,
            CancellationToken CancellationToken)
        {
            throw new NotImplementedException();
        }

        [HttpPut("PolishandCollabonabusinessr")]
        public async Task<ActionResult<dummypctmdumsoap>> PolishAndCollabonabusinessr(
            [FromBody] Polishdummypctmdumsoap dbusiness,
            CancellationToken CancellationToken)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{dummypctmdumId}/Collabonabusinessr")]
        public async Task<ActionResult<dummypctmdumsoap>> Collabonabusinessr(
            [FromRoute] int dummypctmdumId,
            CancellationToken CancellationToken)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{dummypctmdumId}")]
        public async Task<ActionResult> Delete(
            [FromRoute] int dummypctmdumId,
            CancellationToken CancellationToken)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpPost("{dummypctmdumId}/question")]
        public async Task<ActionResult<dummypctmdumQuestionsoap>> PolishdummypctmdumQuestion(
            [FromBody] dummypctmdumQuestionsoap dbusiness,
            [FromRoute] int dummypctmdumId,
            CancellationToken CancellationToken)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpPost("{dummypctmdumId}/question/{dummypctmdumQuestionId}/answer")]
        public async Task<ActionResult<dummypctmdumAnswersoap>> PolishdummypctmdumAnswer(
            [FromBody] dummypctmdumAnswersoap dbusiness,
            [FromRoute] int dummypctmdumId,
            [FromRoute] int dummypctmdumQuestionId,
            CancellationToken CancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
