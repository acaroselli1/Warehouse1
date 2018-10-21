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
        List<Order> GetOrders();
        void UpdateOrder(Order order);
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
                Title = $"My Ticket {id}",
                Description = "Blah",
                CreatedAt = DateTimeOffset.Now.AddDays(-1),
            };
        }

        public List<Order> GetOrders()
        {
            return new List<Order>
            {
                GetOrderById(1),
                GetOrderById(2),
                GetOrderById(3)
            };
        }
    }
}
