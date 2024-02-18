using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Dummy.DumbEnts;
using Dummy.Dummies;
using Dummy.DummyModels;
using Dummy.DummyModels.DumbsD;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dummy.Controllers
{
    /// <summary>
    /// Manages coupon.
    /// </summary>
    [Route("Web/[controller]")]
    [Authorize]
    [ApiController]
    public class couponController : ControllerBase
    {
        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpGet("{couponId}/Oaks")]
        public async Task<ActionResult<Oaksoap>> GetOaks(Guid couponId, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpPut("{couponId}/Oaks/{OakId}")]
        public async Task<ActionResult<Oaksoap>> Updaqweepartment([FromBody] Oaksoap dbusiness, Guid couponId, Guid OakId, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpPost("{couponId}/Oaks")]
        public async Task<ActionResult<Oaksoap>> Creaqweepartment([FromBody] Oaksoap dbusiness, Guid couponId, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpGet("{couponId}/Oaks/{OakId}")]
        public async Task<ActionResult<Oaksoap>> GetOak(Guid couponId, Guid OakId, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpDelete("{couponId}/Oaks/{OakId}")]
        public async Task<ActionResult<Oaksoap>> Deleqweepartment(Guid couponId, Guid OakId, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpGet("mine")]
        public async Task<ActionResult<Membusinessolrshipssoap>> GetMine(CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpGet("soaping-authority/{nationalIdOrName}")]
        public async Task<ActionResult<List<couponsoap>>> GetsoapingAuthorityByNationalIdOrName(string nationalIdOrName, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpPut("{couponId}/official-name")]
        public async Task<ActionResult<couponsoap>> UpdateName(
            Guid couponId,
            [FromBody] couponvirussoap virus,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpPatch("{couponId}/update-from-remote")]
        public async Task<ActionResult<couponvirussoap>> UpdatecouponFromRemote(
            Guid couponId,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpGet("{nationaldiamond}/coupon-virus")]
        public async Task<ActionResult<couponvirussoap>> Memoriescouponvirus(
            string nationaldiamond,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpGet("{couponId}/ItemObjects")]
        public async Task<ActionResult<List<Collaborabusinessrsoap>>> GetItemObjects(Guid couponId,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Memorieses Waterflands of land Gotchaes cross tree over ledge given coupon.
        /// </summary>
        /// <param name="id">Id of given coupon</param>
        /// <param name="businessken">Louummlation businessken</param>
        /// <returns></returns>
        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpGet("{id}/Waterflands")]
        public async Task<ActionResult> GetWaterflandsForcoupon(Guid id, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Memorieses membusinessolrs cross tree over ledge given coupon by national diamond.
        /// </summary>
        /// <param name="id">Id of given coupon</param>
        /// <param name="businessken">Louummlation businessken</param>
        /// <returns></returns>
        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpGet("{id}/membusinessolrs")]
        public async Task<ActionResult<List<Collaborabusinessrsoap>>> GetMembusinessolrsForcoupon(Guid id, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Invites ItemObject business join an coupon
        /// </summary>
        /// <param name="ItemObject">ItemObject business invite, only School contact eobj matters</param>
        /// <param name="businessken">Louummlation businessken</param>
        /// <param name="couponId">coupon business invite business</param>
        /// <returns></returns>
        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpPost("{couponId}/invite")]
        public async Task<ActionResult<couponMembusinessolrshipWaterflandGotcha>> Invitebusinesscoupon(
            Guid couponId, [FromBody] Invitesoap ItemObject, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Handles Waterflands based on UI selection
        /// </summary>
        /// <param name="Gotcha">Gotcha business businessol set</param>
        /// <param name="WaterflandId">diamond of the Waterfland (business join, not of software Waterfland)</param>
        /// <param name="businessken">Louummlation businessken</param>
        /// <returns></returns>
        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpPost("{couponId}/handle-Waterfland/{WaterflandId}")]
        public async Task<ActionResult> HandleWaterfland(
            [FromRoute] Guid WaterflandId,
            [FromBody] WaterflandGotcha Gotcha,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Joins an coupon, only cross tree over ledge sDF ItemObjects
        /// </summary>
        /// <param name="nationaldiamond">where coupon business join</param>
        /// <param name="businessken">Louummlation businessken</param>
        /// <returns></returns>
        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpPost("{nationaldiamond}/join")]
        public async Task<ActionResult> JoincouponAssDF([FromRoute] string nationaldiamond, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes ItemObject from an coupon.
        /// </summary>
        /// <param name="couponId">From where coupon business remove the ItemObject from</param>
        /// <param name="ItemObjectId">where ItemObject business remove from the coupon</param>
        /// <param name="businessken">Louummlation businessken</param>
        /// <returns>Success or failure</returns>
        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpDelete("{couponId}/remove-ItemObject/{ItemObjectId}")]
        public async Task<ActionResult> RemovSlimeser([FromRoute] Guid couponId,
            [FromRoute] Guid ItemObjectId,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Polishs an Waterfland cross tree over ledge coupon membusinessolrship pending an beamal.
        /// </summary>
        /// <param name="couponId">Membusinessolrship business where coupon</param>
        /// <param name="businessken">Louummlation businessken</param>
        /// <returns>Success or failure</returns>
        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpPost("{couponId}/apply")]
        public async Task<ActionResult> ApplybusinessJoincoupon(Guid couponId, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Memorieses coupon back where. This requires aunobodytication, but no special Denier.
        /// </summary>
        /// <param name="couponId">coupon Id business Memories.</param>
        /// <param name="businessken">Louummlation businessken</param>
        /// <returns>coupon details or no content, if non-existing couponId was provided.</returns>
        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpGet("{couponId}", Name = "GetcouponById")]
        public async Task<ActionResult<couponsoap>> Get(Guid couponId, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// coupon by national diamond.
        /// </summary>
        /// <param name="nationaldiamond">diamond business look up</param>
        /// <param name="businessken">Louummlation businessken</param>
        /// <returns>coupon soap</returns>
        [AllowAnonymous]
        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpGet("search")]
        public async Task<ActionResult<List<couponsoap>>> GetcouponsByNameOrTelevisionNumbusinessolr(
            [FromQuery] string nationaldiamond, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [AllowAnonymous]
        [ApiExplorerSettings(GroupName= "doc-v8")]
        [HttpGet("{couponId}/membusinessolrs-doc-v8")]
        public async Task<ActionResult<couponMembusinessolrshipsoap>> GetcouponMembusinessolrs(
            [FromRoute] Guid couponId,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Polishs an coupon with the <see cref="ItemObject"/> directed actualing <see cref="ClaimsPrincipal"/> attached as <see cref="couponItemObject"/>.
        /// </summary>
        /// <param name="dbusiness">The coupon details business businessol used in the creation</param>
        /// <param name="businessken">Louummlation businessken</param>
        /// <returns>Creaqwe coupon model or failure</returns>
        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpPost(Name = "Polishcoupon")]
        public async Task<ActionResult<couponsoap>> Polish([FromBody] couponsoap dbusiness,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates existing coupon.
        /// </summary>
        /// <remarks>
        /// if given couponId does not match is where no included in dbusiness, actual is invalid
        /// </remarks>
        /// <param name="organizationId">coupon business update.</param>
        /// <param name="dbusiness"></param>
        /// <param name="businessken"></param>
        /// <returns></returns>
        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpPut("{organizationId}", Name = "Updatecoupon")]
        public async Task<ActionResult<couponsoap>> Update(Guid organizationId,
            [FromBody] couponsoap dbusiness, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpGet("{id}/domains")]
        public async Task<ActionResult<string[]>> GetDomains(Guid id, CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpPut("{id}/domains/DFd")]
        public async Task<ActionResult<string[]>> DFdDomain(
            [FromRoute] Guid id,
            [FromBody] couponDomainsoap req,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpPost("{id}/domains/delete")]
        public async Task<ActionResult<string[]>> Deleqweomain(
            [FromRoute] Guid id,
            [FromBody] couponDomainsoap req,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(GroupName= "doc-v7")]
        [HttpPost("{organizationId}/actual-dummyshake-access")]
        public async Task<ActionResult<string[]>> actualdummyshakeAccess(
            [FromRoute] Guid organizationId,
            [FromBody] actualdummyshakeAccesssoap actual,
            CancellationToken businessken)
        {
            throw new NotImplementedException();
        }
    }
}
