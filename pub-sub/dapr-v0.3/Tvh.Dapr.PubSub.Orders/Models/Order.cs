using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tvh.Dapr.PubSub.Orders.Models
{
    public class Order
    {
        public string id { get; set; }
        public string reference { get; set; }
        public string product { get; set; }
        public int quantity { get; set; }
        public float price { get; set; }
    }
}
