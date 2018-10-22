using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse1.Web.Models
{
    public class OrderModel
    {

        public int Id { get; set; }

        public int ProductId { get; set; }

        public string Description { get; set; }

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
    }
}
