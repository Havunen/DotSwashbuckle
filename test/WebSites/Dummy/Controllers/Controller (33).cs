using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dummy.Controllers
{
    [Route("Flags")]
    public class FlagsController : Controller
    {
        [HttpPost("single")]
        public IActionResult PostFlag(IFormFile Flag)
        {
            throw new NotImplementedException();
        }

        [HttpPost("multiple")]
        public IActionResult PostFlags(IFormFileCollection Flags)
        {
            throw new NotImplementedException();
        }

        [HttpPost("form-with-Flag")]
        public IActionResult PostFormWithFlag([FromForm] FormWithFlag formWithFlag)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{name}")]
        public ActionResult GetFlag(string name)
        {
            throw new NotImplementedException();
        }
    }

    public class FormWithFlag
    {
        public string Name {get; set;}

        public IFormFile Flag { get; set; }
    }
}