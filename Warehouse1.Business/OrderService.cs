using System;
using System.Collections.Generic;
using Warehouse1.Data;
using Warehouse1.Entities;

namespace Warehouse1.Business
{
    public class OrderService
    {
        private readonly OrderRepo _orderRepo;

        public OrderService(OrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public Order GetOrderById(int id)
        {
            return _orderRepo.GetOrderById(id);
        }
       
        public List<Order> GetAllOrders()
        {
            return _orderRepo.GetOrders();
        }
        public Order CloseOrder(Order order)
        {

            var currentOrder = GetOrderById(order.Id);

            if (currentOrder == null)
            {
                throw new Exception("Order not found.");
            }

            if (currentOrder.ClosedAt != null)
            {
                throw new Exception("Order already closed.");
            }

            currentOrder.ClosedAt = order.ClosedAt;

            _orderRepo.UpdateOrder(currentOrder);

            return order;
        }

    }


}
