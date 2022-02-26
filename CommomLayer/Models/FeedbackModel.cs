using System;
using System.Collections.Generic;
using System.Text;

namespace CommomLayer.Models
{
    public class FeedbackModel
    {
		public int FeedbackId { get; set; }
		public int UserId { get; set; }
		public int BookId { get; set; }
		public string Comments { get; set; }
		public int Ratings { get; set; }
		public RegisterModel User { get; set; }
	}
}
