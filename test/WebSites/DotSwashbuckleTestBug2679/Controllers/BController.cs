using System.Net;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace SwashbuckleTestBug2679.Controllers {

    [ApiVersion(1.0)]
    [Authorize]
    [Route("api/v{version:ApiVersion}/b")]
    public class BController : ODataController {

        [HttpGet]
        [ProducesResponseType(typeof(IQueryable<DtoB>), 200)]
        [ProducesResponseType((Int32)HttpStatusCode.NotFound)]
        [ProducesResponseType((Int32)HttpStatusCode.BadRequest)]
        [ProducesResponseType((Int32)HttpStatusCode.InternalServerError)]
        public Task<ActionResult<IQueryable<DtoB>>> Gets() {
             
            ActionResult<IQueryable<DtoB>> result = Ok(new List<DtoB>());
            return Task.FromResult(result);
        }

        [HttpGet("{key}")]
        [ProducesResponseType(typeof(DtoB), 200)]
        [ProducesResponseType((Int32)HttpStatusCode.NotFound)]
        [ProducesResponseType((Int32)HttpStatusCode.BadRequest)]
        [ProducesResponseType((Int32)HttpStatusCode.InternalServerError)]
        public Task<ActionResult<DtoB>> Get(Int64 key) {
            ActionResult<DtoB> result = Ok(new DtoB());
            return Task.FromResult(result);
        }
    }
}