using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using demo1.Models;

namespace demo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductController()
        {
        }


        [HttpGet("")]
        public IActionResult GetAnotherRoot()
        {
            return Ok("Hey");
        }

        [HttpGet("products")]
        public IActionResult GetProducts()
        {
            return Ok("some products");
        }

        [HttpGet("products/{id}")]
        public IActionResult GetProductId(int id)
        {
            return Ok($"product {id}");
        }

        [HttpGet("products/{id}/{type}")]
        public IActionResult GetProductIdAndType(int id, string type)
        {
            return Ok($"product {id}, {type}");
        }
        
        
    }
}