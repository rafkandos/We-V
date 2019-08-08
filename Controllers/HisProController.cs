using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using wevi.Models;

namespace wevi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HisProController : ControllerBase
    {
        private readonly WevDbContext _context;

        public HisProController(WevDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public outputHisProd GetHisProd(string GetHisProd, paramHisProd pr)
        {
            outputHisProd output = new outputHisProd();
            var result = new resultHisProd();

            try
            {
                var dtlogin = (from x in _context.HistoryProduct.Where(ahha => ahha.userid == pr.userid)
                               join prd in _context.Product on x.productid equals prd.productid
                               //where x.productid == pr.productid
                               //orderby x.commentid descending
                               select new resultHisProd
                               {
                                   productname = prd.productname,
                                   scantime = x.scantime

                               }).ToList();

                if (dtlogin != null)
                {
                    //result = dtlogin;

                    output.Result = "OK";
                    output.hisprod = dtlogin;
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

    }
}