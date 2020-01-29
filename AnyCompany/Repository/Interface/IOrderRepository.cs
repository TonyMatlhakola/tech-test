using AnyCompany.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Repository.Interface
{
   public interface IOrderRepository
    {
        void SaveOrder(Order order);
        Customer FetchCustomer(int customerId);
        DataSet LoadAllCustomerAndOrders(DataSet dataset);

    }
}
