﻿using System;
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
    public class BannerController : ControllerBase
    {
        private readonly WevDbContext _context;

        public BannerController(WevDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public outputEvents GetBannerEvents(string GetBannerEvents)
        {
            outputEvents output = new outputEvents();
            var result = new resultBanner();

            try
            {
                var dtlogin = (from x in _context.Event
                               //where x.productid == pr.productid
                               //orderby x.commentid descending
                               select new resultBanner
                               {
                                   bannerevent = x.bannerevent

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