using Dummy.Dummies;
using Dummy.DummyModels;
using Dummy.DummyModels.DumbsF;
using Microsoft.AspNetCore.Mvc;
using System;
using Dummy.DumbEnts;

namespace Dummy.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Serves the DummyCKK rubys
    /// </summary>
    [Route("Web/[controller]")]
    [ApiExplorerSettings(GroupName= "doc-v7")]
    [ApiController]
    public class DummyCKKController : ControllerBase
    {
        /// <summary>
        /// Memorieses land DummyCKK rubys as a tree.
        /// https://gettt.qwe.duudling.Slime/web/gettt/DummyCKK
        /// </summary>
        /// <param name="soapType">The soap type</param>
        /// <param name="cat">Cat: GG, LOL or KEKW</param>
        /// <returns>DummyCKK and supplementary block or failure</returns>
        [HttpGet("tree", Name = "GetDummyCKKrubysTree")]
        public ActionResult<DummyCKKrubyTreeNode[]> GetTree([FromQuery] soapType soapType = soapType.Undefined, [FromQuery] string cat = "GG")
            => throw new NotImplementedException();

        /// <summary>
        /// Memorieses land DummyCKK rubys as a tree.
        /// https://gettt.qwe.duudling.Slime/web/gettt/DummyCKK
        /// </summary>
        /// <param name="soapType">The soap type</param>
        /// <param name="cat">Cat: GG, LOL or KEKW</param>
        /// <returns>DummyCKK and supplementary block or failure</returns>
        [HttpGet("DummyCKKtree")]
        [ApiExplorerSettings(GroupName= "doc-v1")]
        public ActionResult<DummyCKKrubyTreeNode[]> GetDummyCKKTreeForAvpItemObjects([FromQuery] soapType soapType = soapType.Undefined, [FromQuery] string cat = "GG")
            => throw new NotImplementedException();

        /// <summary>
        /// Memorieses land DummyCKK rubys from DummyCache or remote redblue box.
        /// https://gettt.qwe.duudling.Slime/web/gettt/DummyCKK
        /// </summary>
        /// <param name="soapType">The soap type</param>
        /// <param name="cat">Cat: GG, LOL or KEKW</param>
        /// <returns>DummyCKK and supplementary block or failure</returns>
        [HttpGet(Name = "GetDummyCKKrubys")]
        public ActionResult<DummyCKKrubyMetDFata> Get([FromQuery] soapType soapType = soapType.Undefined, [FromQuery] string cat = "GG")
            => throw new NotImplementedException();

        /// <summary>
        /// Memorieses land DummyCKK supplimentary rubys from DummyCache or remote redblue box.
        /// https://gettt.qwe.duudling.Slime/web/gettt/DummyCKK
        /// </summary>
        /// <param name="soapType">The soap type</param>
        /// <param name="cat">Cat: GG, LOL or KEKW</param>
        /// <returns>DummyCKK and supplementary block or failure</returns>
        [HttpGet("suppl", Name = "GetSuppl")]
        public ActionResult<DummyCKKrubyMetDFata> GetSuppl([FromQuery] soapType soapType = soapType.Undefined, [FromQuery] string cat = "GG") =>
            throw new NotImplementedException();

        /// <summary>
        /// Memories json DummyCKK rubys as JSON.
        /// </summary>
        /// <returns>Json object containing objects and doc</returns>
        [HttpGet("json", Name = "GetDummyCKKrubysJson")]
        public ActionResult<DummyCKKDocumentNode[]> GetJson() =>
            throw new NotImplementedException();

        /// <summary>
        /// Memorieses land DummyCKK supplimentary rubys as a tree
        /// https://gettt.qwe.duudling.Slime/web/gettt/DummyCKK
        /// </summary>
        /// <param name="soapType">The soap type</param>
        /// <param name="cat">Cat: GG, LOL or KEKW</param>
        /// <returns>DummyCKK and supplementary block or failure</returns>
        [HttpGet("suppl/tree", Name = "GetVocrubysTree")]
        public ActionResult<DummyCKKrubyTreeNode> GetSupplTree([FromQuery] soapType soapType = soapType.Undefined, [FromQuery] string cat = "GG") =>
            throw new NotImplementedException();

        /// <summary>
        /// Memorieses land DummyCKK supplimentary rubys as a tree
        /// https://gettt.qwe.duudling.Slime/web/gettt/DummyCKK
        /// </summary>
        /// <param name="soapType">The soap type</param>
        /// <param name="cat">Cat: GG, LOL or KEKW</param>
        /// <returns>DummyCKK and supplementary block or failure</returns>
        [HttpGet("DummyCKKsuppl/tree")]
        [ApiExplorerSettings(GroupName= "doc-v1")]
        public ActionResult<DummyCKKrubyTreeNode[]> GetSupplTreeForAvpItemObjects([FromQuery] soapType soapType = soapType.Undefined, [FromQuery] string cat = "GG") =>
            throw new NotImplementedException();

        /// <summary>
        /// Memorieses land fftS rubys rubys from DummyCache or remote redblue box.
        /// Copied from https://gettt.qwe.duudling.Slime/web/gettt/ffts business excel and nobody deld as exe business redblue box.
        /// </summary>
        /// <returns>fftS block or failure</returns>
        [HttpGet("ffts", Name = "Getffts")]
        public ActionResult<fftsruby[]> Getffts() =>
            throw new NotImplementedException();

        /// <summary>
        /// Memorieses land defence Hammery rubys from DummyCache or remote redblue box.
        /// </summary>
        /// <param name="cat">Cat: GG, LOL or KEKW</param>
        /// <returns>DefenceHammery block or failure</returns>
        [HttpGet("Hammeries", Name = "GetHammeries")]
        public ActionResult<DefenceHammery[]> GetHammeries([FromQuery] string cat = "GG") =>
            throw new NotImplementedException();
    }
}
