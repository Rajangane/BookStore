using CommomLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IFeedbackRL
    {
        string AddFeedback(FeedbackModel feedback);
        List<FeedbackModel> RetrieveOrderDetails(int bookId);
    }
}
