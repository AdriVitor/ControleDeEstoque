using System.ComponentModel.DataAnnotations;
using ControleDeEstoque.Data;
using ControleDeEstoque.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoque.Controllers{
    [ApiController]
    public class ProductController : ControllerBase{
        private AppDbContext _appDbContext;

        public ProductController(AppDbContext appDbContext){
            _appDbContext = appDbContext;
        }

        [HttpPost("product/create")]
        public async Task<ActionResult<Product>> PostProduct([FromBody] Product product){
            try{
                await _appDbContext.ProductModel.AddAsync(product);
                await _appDbContext.SaveChangesAsync();
                return Ok(product);
            }
            catch{
                return NoContent();
            }
        }

        [HttpGet("all-products")]
        public async Task<ActionResult<List<Product>>> GetAllProducts(){
            try{
                var product = await _appDbContext.ProductModel.ToListAsync();
                return Ok(product);
            }
            catch{
                return NoContent();
            }
        }

        [HttpPut("product/update/{productId:int}")]
        public async Task<ActionResult<Product>> PutProduct(
            [FromRoute] int productId,
            [FromBody] Product productUpdate
        ){
            try{
                var product = await _appDbContext.ProductModel.FirstOrDefaultAsync(x=>x.Id == productId);
                if(product == null){
                    return NotFound(new{message = "produto não encontrado"});
                }

                product.Name = productUpdate.Name;
                product.Price = productUpdate.Price;
                product.Quantity = productUpdate.Quantity;

                _appDbContext.ProductModel.Update(product);
                await _appDbContext.SaveChangesAsync();
                return Ok();
            }
            catch{
                return NoContent();
            }
        }

        [HttpDelete("product/delete/{productId:int}")]
        public async Task<ActionResult> DeleteProduct(
            [FromRoute] int productId
        ){
            try{
                var item = await _appDbContext.ProductModel.FirstOrDefaultAsync(x=>x.Id == productId);
                if(item == null){
                    return NotFound(new{message = "produto não encontrado"});
                }

                _appDbContext.Remove(item);
                _appDbContext.SaveChanges();
                return Ok();
            }
            catch{
                return NoContent();
            }
        } 
    }
}