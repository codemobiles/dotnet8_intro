using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo1.Database;
using demo1.Models;
using Microsoft.AspNetCore.Mvc;
//using demo1.Models;

namespace demo1.Controllers
{

    public class Product {
        public string? Name { get; set; }
        public double Price { get; set; } = 0;
        public int Stock { get; set; } = 0;
    }


    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public DatabaseContext DbContext { get;set; }


        public ProductController(DatabaseContext dbContext)
        {
            this.DbContext = dbContext;
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

        [HttpGet("products/search")]
        public IActionResult SearchProducts([FromQuery] string keyword)
        {
            return Ok($"search product keyword: {keyword}");
        }
        
        [HttpGet("products/search/{id}/{type}")]
        public IActionResult SearchProductsWith(int id, string type, [FromQuery] string keyword)
        {
            return Ok($"product {id}, {type}, {keyword}");
        }

        //// public ActionResult<IEnumerable<string>> GetALL()
        [HttpGet("products/all")]
        public IActionResult GetALL()
        {
            return Ok(new string[] {"product1","product2","product3"});
        }


        [HttpPost("add")]
        public IActionResult AddProduct([FromBody] Product newProduct)
        {
            return Ok($"Input: {newProduct.Name}, {newProduct.Price}, {newProduct.Stock}, ");
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteModelById(int id)
        {
            return Ok($"Delete: {id}");
        }

        [HttpPut("{id}")]
        public IActionResult PutTModel(int id, [FromBody] Product newProduct)
        {
            
            return Ok($"Update: {id}, {newProduct.Name}, {newProduct.Stock}, {newProduct.Price}");
        }


        [HttpGet("product-db")]
        public IActionResult GetProductFromDB()
        {
            var result = this.DbContext.Products.ToList();
            return Ok(result);
        }

        [HttpPost("insert-product")]
        public IActionResult InsertProduct([FromForm] demo1.Models.Product newProduct)
        {
             this.DbContext.Add(newProduct);
             this.DbContext.SaveChanges();
             return Ok("insert successfully");
        }
        
        
        // [HttpPost("insert-product")]
        // public IActionResult InsertProduct([FromForm] demo1.Models.Product newProduct)
        // {
        //     this.DbContext.Add(newProduct);
        //     this.DbContext.SaveChanges();
        //     return Ok("insert successfully");
        // }
        

        // [HttpDelete("delete-product/{id}")]
        // public IActionResult DeleteProduct(int id)
        // {
        //     var product = this.DbContext.Products.Find(id);                        
        //     this.DbContext.Products.Remove(product!);
        //     this.DbContext.SaveChanges();
        //     return Ok("delete successfully");
        // }

        // [HttpPut("update-product/{id}")]
        // public IActionResult PutTModel(int id, [FromForm] demo1.Models.Product updateProduct)
        // {
            
        //     var product = this.DbContext.Products.Find(id)!;
        //     product.Name = updateProduct.Name;
        //     product.Price = updateProduct.Price;                        
        //     product.Stock = updateProduct.Stock;                        
        //     this.DbContext.Products.Update(product);
        //     this.DbContext.SaveChanges();
        //     return Ok("update successfully");
        // }
    }
}