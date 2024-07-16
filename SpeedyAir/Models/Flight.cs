using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyAir.Models
{
    public class Flight
    {
        public int FlightNumber { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public int Day { get; set; }
        public int Capacity { get; set; } = 20; // Each plane has a capacity of 20 boxes

        public int AvailableCapacity { get; set; }

        public Flight()
        {
            AvailableCapacity = Capacity;
        }
    }
}
