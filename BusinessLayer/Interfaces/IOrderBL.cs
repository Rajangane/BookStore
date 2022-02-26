using CommomLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IOrderBL
    {
        string AddOrder(OrderModel order);
        List<OrderModel> RetrieveOrderDetails(int userId);
    }
}
