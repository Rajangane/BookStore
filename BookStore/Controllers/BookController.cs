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
    public class BookController : Controller
    {
        IBookBL bookBL;
        public BookController(IBookBL bookBL)
        {
            this.bookBL = bookBL;
        }
     
        [HttpPost]
        [Route("addBooks")]
        public IActionResult AddBook([FromBody] BookModel book)
        {
            try
            {
                string result = this.bookBL.AddBook(book);
                if (result.Equals("Book Added succssfully"))
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

        [HttpPut]
        [Route("updateBook")]
        public IActionResult UpdateBookDetails([FromBody] BookModel update)
        {
            try
            {
                string result = this.bookBL.UpdateBookDetails(update);
                if (result.Equals("Details Updated Successfully"))
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

        [HttpDelete]
        [Route("deleteBook")]
        public IActionResult DeleteBook(int bookId)
        {
            try
            {
                string result = this.bookBL.DeleteBook(bookId);
                if (result.Equals("Book details deleted successfully"))
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
        [Route("RetriveSpecificBookByID")]
        public IActionResult RetrieveBookDetails(int bookId)
        {
            try
            {
                object result = this.bookBL.RetrieveBookDetails(bookId);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<object>() { Status = true, Message = "Retrieval of book details succssful", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Bookid doesnt exists" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("getAllBooks")]
        public IActionResult GetAllBooks()
        {
            try
            {
                var result = this.bookBL.GetAllBooks();
                if (result != null)
                {
                    return this.Ok(new ResponseModel<object>() { Status = true, Message = "Retrieval all book details succssful", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "No book exists" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
    }
}