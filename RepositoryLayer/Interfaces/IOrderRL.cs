using CommomLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IOrderRL
    {
        string AddOrder(OrderModel order);
        List<OrderModel> RetrieveOrderDetails(int userId);
    }
}
