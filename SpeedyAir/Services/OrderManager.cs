using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

using SpeedyAir.Models;
namespace SpeedyAir.Services
{
    public class OrderManager
    {
        private List<Flight> flights;
        private List<Order> orders;

        public OrderManager()
        {
            flights = new List<Flight>();
            orders = new List<Order>();
        }

        public void AddFlight(Flight flight)
        {
            flights.Add(flight);
        }

        public void LoadOrders(string ordersJsonPath)
        {
            try
            {
                if (!File.Exists(ordersJsonPath))
                {
                    Console.WriteLine($"Error: The orders file '{ordersJsonPath}' does not exist. Please check the file path and try again.");
                    return;
                }
                var jsonData = File.ReadAllText(ordersJsonPath);
                var orderDictionary = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(jsonData);

                foreach (var order in orderDictionary)
                {
                    orders.Add(new Order { OrderId = order.Key, Destination = order.Value["destination"] });
                }
            }
            catch (JsonException)
            {
                Console.WriteLine("Error: Unable to parse the orders file. Please ensure it is in the correct format and try again.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Unable to load the orders. Please try again or contact support if the problem persists.");
                Console.WriteLine($"Details: {ex.Message}");
            }
        }

        public void ScheduleOrders()
        {
            try
            {
                foreach (var order in orders)
                {
                    var flight = flights.Find(f => f.ArrivalCity == order.Destination && f.AvailableCapacity > 0);

                    if (flight != null)
                    {
                        flight.AvailableCapacity--;
                        order.FlightNumber = flight.FlightNumber;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Unable to schedule orders. Please try again or contact support if the problem persists.");
                Console.WriteLine($"Details: {ex.Message}");
            }
        }

        public void PrintFlightSchedule()
        {
            try
            {
                foreach (var flight in flights)
                {
                    Console.WriteLine($"Flight: {flight.FlightNumber}, departure: {flight.DepartureCity}, arrival: {flight.ArrivalCity}, day: {flight.Day}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Unable to list print flight schedules. Please try again or contact support if the problem persists.");
                Console.WriteLine($"Details: {ex.Message}");
            }
        }

        public void PrintOrderItineraries()
        {
            try
            {
                foreach (var order in orders)
                {
                    if (order.FlightNumber.HasValue)
                    {
                        var assignedFlight = order.FlightNumber != null ? order.FlightNumber.ToString() : "not scheduled";
                        Console.WriteLine($"Order: {order.OrderId}, FlightNumber: {assignedFlight}, Departure: YUL, Arrival: {order.Destination}, Day: {(assignedFlight != "not scheduled" ? flights.Find(f => f.FlightNumber == order.FlightNumber).Day.ToString() : "N/A")}");
                    }
                    else
                    {
                        Console.WriteLine($"Order: {order.OrderId}, FlightNumber: not scheduled");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Unable to list print order itineraries. Please try again or contact support if the problem persists.");
                Console.WriteLine($"Details: {ex.Message}");
            }
        }
    }
}