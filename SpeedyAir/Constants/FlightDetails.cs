using SpeedyAir.Models;
using SpeedyAir.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyAir.Constants
{
    public static class FlightDetails
    {
        public static void LoadFlights(OrderManager orderManager)
        {
            // Day 1 flights
            orderManager.AddFlight(new Flight { FlightNumber = 1, DepartureCity = "YUL", ArrivalCity = "YYZ", Day = 1 });
            orderManager.AddFlight(new Flight { FlightNumber = 2, DepartureCity = "YUL", ArrivalCity = "YYC", Day = 1 });
            orderManager.AddFlight(new Flight { FlightNumber = 3, DepartureCity = "YUL", ArrivalCity = "YVR", Day = 1 });

            // Day 2 flights
            orderManager.AddFlight(new Flight { FlightNumber = 4, DepartureCity = "YUL", ArrivalCity = "YYZ", Day = 2 });
            orderManager.AddFlight(new Flight { FlightNumber = 5, DepartureCity = "YUL", ArrivalCity = "YYC", Day = 2 });
            orderManager.AddFlight(new Flight { FlightNumber = 6, DepartureCity = "YUL", ArrivalCity = "YVR", Day = 2 });
        }
    }
}
