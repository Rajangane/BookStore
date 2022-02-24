using CommomLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IBookBL
    {


        string AddBook(BookModel book);
        string UpdateBookDetails(BookModel update);
        string DeleteBook(int bookId);
        object RetrieveBookDetails(int bookId);
        List<BookModel> GetAllBooks();
    }
}
