using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using demo1.Models;

namespace demo1.Controllers
{
    // [Route("api/[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    public class Demo1Controller : ControllerBase
    {
        public Demo1Controller()
        {
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<string>> Getstrings()
        {
            return new List<string> {"Lek", "Kan", "DotOne" };
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetstringById(int id)
        {
            return $"Hey id: {id}";
        }

        [HttpPost("")]
        public ActionResult<string> Poststring(string model)
        {
            return null;
        }

        [HttpPut("{id}")]
        public IActionResult Putstring(int id, string model)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<string> DeletestringById(int id)
        {
            return null;
        }
    }
}