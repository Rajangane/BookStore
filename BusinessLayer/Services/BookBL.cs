using BusinessLayer.Interfaces;
using CommomLayer.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class BookBL : IBookBL
    {
        IBookRL bookRL;
        public BookBL(IBookRL bookRL)
        {
            this.bookRL = bookRL;
        }



        public string AddBook(BookModel book)
        {
            try
            {
                return this.bookRL.AddBook(book);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public string UpdateBookDetails(BookModel update)
        {
            try
            {
                return this.bookRL.UpdateBookDetails(update);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public string DeleteBook(int bookId)
        {
            try
            {
                return this.bookRL.DeleteBook(bookId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public object RetrieveBookDetails(int bookId)
        {
            try
            {
                return this.bookRL.RetrieveBookDetails(bookId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<BookModel> GetAllBooks()
        {
            try
            {
                return this.bookRL.GetAllBooks();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}