using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.Data;
using TestApplication.DTO;
using TestApplication.Models;

namespace TestApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly Context _context;

        public ProductsController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {

            return await _context.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProducts_byId(int id)
        {

            var products_by_id = await _context.Products.FindAsync(id);

            if (products_by_id == null)
            {
                return NotFound();
            }
            return products_by_id;
        }

        [HttpPost]
        public async Task<ActionResult<Products>> Add_Products(Products Product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = new Products()
            {
                price = Product.price,
                isafood = Product.isafood,
                isadrink = Product.isadrink,
                nameproduct= Product.nameproduct

            };
            _context.Products.Add(Product);
            await _context.SaveChangesAsync();



            return CreatedAtAction("GetProducts", new { id = product.id }, Product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Products>> Delete_Product(int id)
        {
            var product = await _context.Products.FindAsync(id);


            if (product == null)
            {
                return NotFound();
            }
            else
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return product;
            }
        }




    }
}
