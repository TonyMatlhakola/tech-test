using AnyCompany.Entities;
using AnyCompany.Repository;
using AnyCompany.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;

namespace AnyCompany.Services

{
    public class OrderService: IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public bool PlaceOrder(Order order, int customerId)
        {
            try
            {
                var customer = _orderRepository.FetchCustomer(customerId);

                if (order.Amount == 0)
                    return false;

                if (customer.Country == "UK")
                    order.VAT = 0.2d;
                else
                    order.VAT = 0;

                _orderRepository.SaveOrder(order);

            }
            catch (Exception ex)
            {
               throw ex;
            }
         
            return true;
        }

        public DataSet LoadAllCustomersAndOrders( DataSet dataSet)
        {
            var responseData = _orderRepository.LoadAllCustomerAndOrders(dataSet);

            return responseData;
                
        }


    }
}
