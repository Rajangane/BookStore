using BusinessLayer.Interfaces;
using CommomLayer.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class FeedbackBL : IFeedbackBL
    {
        IFeedbackRL feedbackRL;
        public FeedbackBL(IFeedbackRL feedbackRL)
        {
            this.feedbackRL = feedbackRL;
        }

        public string AddFeedback(FeedbackModel feedback)
        {
            try
            {
                return this.feedbackRL.AddFeedback(feedback);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<FeedbackModel> RetrieveOrderDetails(int bookId)
        {
            try
            {
                return this.feedbackRL.RetrieveOrderDetails(bookId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
