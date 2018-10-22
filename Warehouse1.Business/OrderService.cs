using System;
using System.Collections.Generic;
using Warehouse1.Data;
using Warehouse1.Entities;

namespace Warehouse1.Business
{
    public class OrderService
    {
        private readonly IOrderRepo _orderRepo;

        public OrderService(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public Order GetOrderById(int id)
        {

            return _orderRepo.GetOrderById(id);
        }


        public Order GetOrdersByProductId(int productId)
        {
            return _orderRepo.GetOrdersByProductId(productId);
        }

        public List<Order> GetAllUnprocessedOrders()
        {
            return _orderRepo.GetAllUnprocessedOrders();
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

            currentOrder.ClosedAt = order.ClosedAt ?? DateTimeOffset.Now;

            _orderRepo.UpdateOrder(currentOrder);

            return currentOrder;
        }
        public Order CreateOrder(Order data)
        {
            return _orderRepo.CreateOrder(data);
;
        }
    }


}
