using System;
using System.Collections.Generic;
using System.Text;

namespace CommomLayer.Models
{
    public class BookModel
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string BookDescription { get; set; }
        public string BookImage { get; set; }
        public string Quantity { get; set; }
        public int Price { get; set; }
        public int DiscountPrice { get; set; }
        public int Rating { get; set; }
        public int RatingCount { get; set; }
    }
}
