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
        public async Task<outputScanQr> PostHistoryProduct(paramScanQr pr)
        {
            //_context.HistoryProduct.Add(historyProduct);
            //await _context.SaveChangesAsync();

            outputScanQr output = new outputScanQr();
            var result = new resultScanQr();

            try
            {
                HistoryProduct dtPrd = new HistoryProduct();
                dtPrd.hisproid = pr.hisproid;
                dtPrd.productid = pr.productid;
                dtPrd.userid = pr.userid;
                dtPrd.scantime = pr.scantime;

                _context.HistoryProduct.Add(dtPrd);
                _context.SaveChanges();

                var dtlogin = (from x in _context.HistoryProduct.Where(ahha => ahha.productid == pr.productid)
                               join prd in _context.Product on x.productid equals prd.productid
                               //where x.productid == pr.productid
                               //orderby x.commentid descending
                               select new Product
                               {
                                   productid = prd.productid,
                                   productname = prd.productname,
                                   productdetail = prd.productdetail,
                                   productcode = prd.productcode,
                                   bannerproduct = prd.bannerproduct,
                                   linkstring = prd.linkstring

                               }).ToList();

                if (dtlogin != null)
                {
                    //result = dtlogin;

                    output.Result = "OK";
                    output.products = dtlogin;
                    output.Message = "Success";
                }
                else
                {
                    output.Result = "NG";
                    output.Message = "GagalBosque";
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
