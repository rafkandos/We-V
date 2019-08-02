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
    public class HisEvtController : ControllerBase
    {
        private readonly WevDbContext _context;

        public HisEvtController(WevDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public outputHistoryEvent GetHisEvt(string GetHisEvt, paramHistoryEvent pr)
        {
            outputHistoryEvent output = new outputHistoryEvent();
            var result = new resultHistoryEvent();

            try
            {
                var dtlogin = (from x in _context.HistoryEvent.Where(ahha => ahha.userid == pr.userid)
                               join evt in _context.Event on x.eventid equals evt.eventid
                               //where x.productid == pr.productid
                               //orderby x.commentid descending
                               select new resultHistoryEvent
                               {
                                   eventname = evt.eventname,
                                   place = evt.place,
                                   eventdate = evt.eventdate

                               }).ToList();

                if (dtlogin != null)
                {
                    //result = dtlogin;

                    output.Result = "OK";
                    output.events = dtlogin;
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