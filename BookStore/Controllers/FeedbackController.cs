using BusinessLayer.Interfaces;
using CommomLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class FeedbackController : Controller
    {
        IFeedbackBL feedbackBL;
        public FeedbackController(IFeedbackBL feedbackBL)
        {
            this.feedbackBL = feedbackBL;
        }
        [HttpPost]
        [Route("addFeedbacks")]
        public IActionResult AddFeedback([FromBody] FeedbackModel feedback)
        {
            try
            {
                string result = this.feedbackBL.AddFeedback(feedback);
                if (result.Equals("Feedback added successfully"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("getFeedbacks")]
        public IActionResult RetrieveOrderDetails(int bookId)
        {
            try
            {
                var result = this.feedbackBL.RetrieveOrderDetails(bookId);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Retrival successful", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Retrival unsuccessful" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

    }
}
