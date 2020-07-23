using System.Collections.Generic;
using System.Linq;
using AnimalShelterBlazorWA.Server.Data;
using AnimalShelterBlazorWA.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelterBlazorWA.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _context.Products.ToArray();
        }


        [HttpGet("{Id}")]
        public Product Get(int id)
        {
            return _context.Products.SingleOrDefault(a => a.Id == id);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(a => a.Id == id);

            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Product product)
        {
            var productInStore = _context.Products.SingleOrDefault(a => a.Id == product.Id);

            if (productInStore != null)
            {
                productInStore.Name = product.Name;
                productInStore.Price = product.Price;
                productInStore.VatPercentage = product.VatPercentage;
                productInStore.ProductImageUrl = product.ProductImageUrl;

                _context.SaveChanges();
            }
            else
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPost]
        public ActionResult<Product> Add(Product newProduct)
        {
            var addedProduct = _context.Products.Add(newProduct);
            _context.SaveChanges();

            return Ok(addedProduct.Entity);
        }


    }
}
