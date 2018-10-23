using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Warehouse1.Business;
using Warehouse1.Entities;
using Warehouse1.Web.Models;

namespace Warehouse1.Web.Controllers
{

    
    public class HomeController : Controller
    {
        private readonly OrderService _orderService;

        public HomeController(OrderService orderService)
        {
            _orderService = orderService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllUnprocessedOrders()
        {

           ViewBag.AllUnprocessedOrders = _orderService.GetAllUnprocessedOrders();

           return View();

        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            return Ok(_orderService.GetOrderById(id));
        }

        [HttpGet]
        public IActionResult GetOrdersByProductId(OrderModel data)
        {
            var dataEntity = new Order
            {
                Id = data.ProductId +1,
                CreatedAt = DateTimeOffset.Now.AddDays(-1),
                ProductId = data.ProductId,
                Description = $"Order with product Id {data.ProductId}"
            };

            ViewBag.Data = dataEntity;
         
            _orderService.GetOrdersByProductId(dataEntity.ProductId);

            return View();
        }

        [HttpPost("CloseOrder")]
        public IActionResult CloseOrder([FromForm]Order order)
        {
            _orderService.CloseOrder(order);
            return View();
        }

        [HttpGet]
        public IActionResult CreateOrder()
        {

            return View();

        }

        [HttpPost]
        public IActionResult CreateOrder(OrderModel data)
        {
           var dataEntity = new Order
            {
                Id = data.Id,
                CreatedAt = data.CreatedAt,
                ProductId = data.Id +10,
                Description = data.Description
            };

            ViewBag.Data = dataEntity;

            _orderService.CreateOrder(dataEntity);

            return View();

            
        }
    }
}
