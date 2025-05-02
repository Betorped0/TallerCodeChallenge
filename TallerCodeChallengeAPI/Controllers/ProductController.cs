using Microsoft.AspNetCore.Mvc;
using TallerCodeChallengeAPI.Models;
using TallerCodeChallengeAPI.Business;


namespace TallerCodeChallengeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        public Handler _hand = new Handler();
        public static List<Product> Products = new List<Product>();
        private static int incrementalId = 1;

        [HttpGet("get-all")]
        public ActionResult<IEnumerable<Product>> GetAllProdcuts()
        {
            var result =  _hand.GetAll(Products);
            return result.Any()? Ok(result): NotFound("No products available, try adding a single one or dummy bulk add");
        }

        [HttpGet("get-byid/{id}")]
        public  ActionResult<Product> GetPrductById(int id)
        {
            var result = _hand.GetById(id, Products);
            
            return result != null? Ok(result) : NotFound();
        }

        [HttpPost("add-product")]
        public ActionResult<int> AddProduct([FromBody] Product product)
        {
            
            var result = _hand.CreateNewProduct(product, incrementalId, Products);
            if (result > 0)
            {
                incrementalId++;
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("update-product")]
        public ActionResult ModifyProduct(Product product, int id)
        {
            var result = _hand.UpdateProduct(product, id, Products);
            return result ? Ok(result) : NotFound();
        }

        [HttpDelete("delete-product/{id}")]
        public  ActionResult DeleteProduct(int id)
        {
            var result = _hand.DeleteProductById(id, Products);

            return result? Ok(result) : NotFound(result);
        }

        [HttpPost("bulk-add-dummy")]
        public ActionResult<Product> AddProductDummyProducts()
        {
            var result = _hand.DummyBulkAdd(Products, incrementalId);
            return Ok(result);
        }
    }

}

