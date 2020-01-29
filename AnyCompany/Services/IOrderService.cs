using AnyCompany.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Services
{
    public interface IOrderService
    {
        bool PlaceOrder(Order order, int customerId);
        DataSet LoadAllCustomersAndOrders(DataSet dataSet);
    }
}
