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
    public class GetCommentController : ControllerBase
    {
        private readonly WevDbContext _context;

        public GetCommentController(WevDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public outputGetCommentById GetCommentById(string GetCommentById, paramGetCommentById pr)
        {
            outputGetCommentById output = new outputGetCommentById();
            var result = new resultGetCommentById();

            try
            {
                var dtlogin = (from x in _context.Comment.Where(ahha => ahha.productid == pr.productid)
                               join nama in _context.User on x.userid equals nama.userid
                               //where x.productid == pr.productid
                               orderby x.commentid descending
                               select new resultGetCommentById
                               {
                                   fullname = nama.fullname,
                                   comment = x.comment,
                                   commentdate = x.commentdate

                               }).ToList();

                if (dtlogin != null)
                {
                    //result = dtlogin;

                    output.Result = "OK";
                    output.comments = dtlogin;
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