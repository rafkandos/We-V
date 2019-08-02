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
    public class HistoryProductsController : ControllerBase
    {
        private readonly WevDbContext _context;

        public HistoryProductsController(WevDbContext context)
        {
            _context = context;
        }

        // GET: api/HistoryProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoryProduct>>> GetHistoryProduct()
        {
            return await _context.HistoryProduct.ToListAsync();
        }

        // GET: api/HistoryProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HistoryProduct>> GetHistoryProduct(int id)
        {
            var historyProduct = await _context.HistoryProduct.FindAsync(id);

            if (historyProduct == null)
            {
                return NotFound();
            }

            return historyProduct;
        }

        // PUT: api/HistoryProducts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistoryProduct(int id, HistoryProduct historyProduct)
        {
            if (id != historyProduct.hisproid)
            {
                return BadRequest();
            }

            _context.Entry(historyProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoryProductExists(id))
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

        // POST: api/HistoryProducts
        [HttpPost]
        //public async Task<ActionResult<HistoryProduct>> PostHistoryProduct(HistoryProduct historyProduct)
        public async Task<outputHisPro> PostHistoryProduct(HistoryProduct historyProduct)
        {
            _context.HistoryProduct.Add(historyProduct);
            await _context.SaveChangesAsync();
            outputHisPro output = new outputHisPro();
            var result = new HistoryProduct();

            try
            {
                if (historyProduct.hisproid != 0)
                {
                    result = historyProduct;

                    output.Result = "OK";
                    output.hispro = result;
                    output.Message = "Success";
                }
                else
                {
                    output.Result = "NG";
                    output.Message = " Failed";
                }
            }
            catch (Exception ex)
            {
                output.Result = "NG";
                output.Message = ex.ToString();
            }
            return output;
        }

        // DELETE: api/HistoryProducts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HistoryProduct>> DeleteHistoryProduct(int id)
        {
            var historyProduct = await _context.HistoryProduct.FindAsync(id);
            if (historyProduct == null)
            {
                return NotFound();
            }

            _context.HistoryProduct.Remove(historyProduct);
            await _context.SaveChangesAsync();

            return historyProduct;
        }

        private bool HistoryProductExists(int id)
        {
            return _context.HistoryProduct.Any(e => e.hisproid == id);
        }
    }
}
