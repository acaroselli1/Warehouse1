using System;
using System.Collections.Generic;
using System.Data;
using Warehouse1.Entities;
using static Warehouse1.Data.OrderRepo;

namespace Warehouse1.Data
{
    public interface IOrderRepo
    {
        Order GetOrderById(int id);
        List<Order> GetAllUnprocessedOrders();
        void UpdateOrder(Order order);
        Order CreateOrder(Order data);
        Order GetOrdersByProductId(int productId);
    }

    //communicates with the Database
    public class OrderRepo : IOrderRepo
    {
        private readonly IDbConnection _db;

        public OrderRepo(IDbConnection db)
        {
            this._db = db;
        }

        public void UpdateOrder(Order order)
        {
            // Insert SQL here

            Console.WriteLine("Order updated");
        }

        public Order GetOrderById (int id)
        {
            //Do not do this obviously
            return new Order
            {
                Id = id,
                CreatedAt = DateTimeOffset.Now.AddDays(-1),
                ProductId = id + 10,
                Description=$"Id#: {id}",
            };
        }

        public Order GetOrdersByProductId(int productId)
        {
            //Do not do this obviously
            return new Order
            {
                Id = productId/10,
                CreatedAt = DateTimeOffset.Now.AddDays(-1),
                ProductId = productId,
                Description = $"Product Id#: {productId}",
            };
        } 

        public List<Order> GetAllUnprocessedOrders()
        {
            return new List<Order>
            {
                GetOrderById(1),
                GetOrderById(2),
                GetOrderById(3)
            };
        }
        public Order CreateOrder(Order data)
        {
            return new Order
            {
                CreatedAt = DateTimeOffset.Now,
                ProductId = data.ProductId,
                Id = data.Id,
                Description = $"Id#: {data.Id}"
            };

        }
    }
}
