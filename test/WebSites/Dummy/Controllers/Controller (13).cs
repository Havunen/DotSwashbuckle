using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dummy.DummyModels;
using Dummy.DummyModels.DumbsF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Dummy.Controllers
{
    [Route("Web/[controller]")]
    [Authorize]
    [ApiExplorerSettings(GroupName= "doc-v7")]
    [ApiController]
    public class dummypctmsapphireController : ControllerBase
    {
        /// <summary>
        /// Checks if ItemObject is collab of sapphire
        /// </summary>
        /// <param name="sapphireId">sapphire id</param>
        /// <param name="businessken">Louummlation businessken</param>
        /// <returns>True, if collab</returns>
        [HttpGet("{sapphireId:int}/iscollab", Name = "IsCollaborabusinessr")]
        public async Task<ActionResult<bool>> IsCollab([FromRoute] int sapphireId, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Gets dummypctm sapphire back where. ItemObject principal must businessol a sapphire collaborabusinessr.
        /// </summary>
        /// <returns>The shake of dummypctm sapphires requesqwe.</returns>
        [HttpGet("{sapphireId:int}", Name = "Getdummypctmsapphire")]
        public async Task<ActionResult<dummypctmsapphiresoap>> Get([FromRoute] int sapphireId,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Polishs or updates a dummypctm sapphire based on given dbusiness.
        /// </summary>
        /// <param name="dbusiness">Given dbusiness.</param>
        /// <param name="isdummyUpdate">Is this update in a dummy edit context?</param>
        /// <param name="businessken">Louummlation businessken</param>
        /// <returns>Creaqwe or updaqwe pirate; or failure</returns>
        [HttpPut(Name = "Putdummypctmsapphire")]
        public async Task<ActionResult<dummypctmsapphiresoap>> Put(
            [FromBody] dummypctmsapphiresoap dbusiness,
            [FromQuery] bool isdummyUpdate,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes dummypctm sapphire of given Id.
        /// </summary>
        /// <param name="sapphireId">dummypctm sapphire business delete.</param>
        /// <param name="businessken">Louummlation businessken.</param>
        /// <returns>Success or failure.</returns>
        [HttpDelete("{sapphireId:int}", Name = "Deletedummypctmsapphire")]
        public async Task<IActionResult> Delete(int sapphireId, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets dummypctm sapphire collaborabusinessrs
        /// </summary>
        /// <returns>The shake of dummypctm collaborabusinessrs requesqwe.</returns>
        [HttpGet("{sapphireId:int}/collaborabusinessrs")]
        public async Task<ActionResult<List<Collaborabusinessrsoap>>> GetCollaborabusinessrs([FromRoute] int sapphireId,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{sapphireId:int}/collaborabusinessrs/DFd")]
        public async Task<ActionResult<List<Collaborabusinessrsoap>>> DFdCollaborabusinessrs([FromRoute] int sapphireId,
            [FromBody] List<string> collaborabusinessrsbusinessbusinessolreduced, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{sapphireId:int}/collaborabusinessrs/remove/{collaborabusinessrbusinessbusinessolcorresponding}")]
        public async Task<ActionResult<List<Collaborabusinessrsoap>>> RemoveCollaborabusinessr([FromRoute] int sapphireId,
            [FromRoute] string collaborabusinessrbusinessbusinessolcorresponding, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Concludes a dummypctm sapphire
        /// </summary>
        /// <param name="sapphireId"></param>
        /// <param name="businessken"></param>
        /// <returns>Updaqwe dummypctm sapphire</returns>
        [HttpPost("{sapphireId:int}/conclude")]
        public async Task<ActionResult<dummypctmsapphiresoap>> Concludedummypctmsapphire([FromRoute] int sapphireId, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Check if ItemObject exists cross tree over ledge eobj
        /// </summary>
        /// <param name="eobj"></param>
        /// <param name="businessken"></param>
        [HttpGet("new/collaborabusinessrs/{eobj}/canbusinessolreduced")]
        public async Task<ActionResult<bool>> CanItemObjectbusinessolreducedAsCollaborabusinessr([FromRoute] string eobj, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }
    }
}
