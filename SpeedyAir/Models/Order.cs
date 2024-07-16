using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyAir.Models
{
    public class Order
    {
        public string? OrderId { get; set; }
        public string? Destination { get; set; }
        public int? FlightNumber { get; set; }
    }
}
