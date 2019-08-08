using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wevi.Models;

namespace wevi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly WevDbContext _context;

        public ProductsController(WevDbContext context)
        {
            _context = context;
        }

        // GET: api/Products
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        //{
        //    return await _context.Product.ToListAsync();
        //}
        [HttpGet]
        public async Task<outputProducts> GetProduct()
        {
            //await _context.User.ToListAsync();

            outputProducts output = new outputProducts();

            try
            {
                output.Result = "OK";
                output.products = await _context.Product.ToListAsync();
                output.Message = "Success";
            }
            catch (Exception ex)
            {
                output.Result = "NG";
                output.Message = ex.ToString();
            }
            return output;

        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Product>> GetProduct(int id)
        //{
        //    var product = await _context.Product.FindAsync(id);

        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return product;
        //}
        public async Task<outputProducts> GetProducts(int id)
        {
            outputProducts output = new outputProducts();

            try
            {
                var prod = await _context.Product.FindAsync(id);

                if (prod != null)
                {
                    output.Result = "OK";
                    output.products = prod;
                    output.Message = "Success";
                }
                else
                {
                    output.Result = "NG";
                    output.Message = "Failure";
                }
            }
            catch (Exception ex)
            {
                output.Result = "NG";
                output.Message = ex.ToString();
            }
            return output;
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.productid)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.productid }, product);
        }

        //[HttpPost]
        //public async Task<outputScanQr> PostProduct(Product product, paramScanQr pr)
        //{
        //    _context.Product.Add(product);
        //    await _context.SaveChangesAsync();

        //    outputScanQr output = new outputScanQr();
        //    var result = new Product();

        //    try
        //    {
        //        var dtlogin = (from x in _context.HistoryProduct.Where(ahha => ahha.productid == pr.productid)
        //                       join prd in _context.Product on x.productid equals prd.productid
        //                       //where x.productid == pr.productid
        //                       //orderby x.commentid descending
        //                       select new Product
        //                       {
        //                           productid = prd.productid,
        //                           productname = prd.productname,
        //                           productdetail = prd.productdetail,
        //                           productcode = prd.productcode,
        //                           bannerproduct = prd.bannerproduct,
        //                           linkstring = prd.linkstring,


        //                       }).ToList();

        //        if (dtlogin != null)
        //        {
        //            //result = dtlogin;

        //            output.Result = "OK";
        //            output.products = dtlogin;
        //            output.Message = "Success";
        //        }
        //        else
        //        {
        //            output.Result = "NG";
        //            output.Message = "GagalBosque";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        output.Result = "NG";
        //        output.Message = ex.ToString();
        //    }

        //    return output;
        //}

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.productid == id);
        }
    }
}
