using System;
using System.Collections.Generic;
using SpeedyAir.Models;
using SpeedyAir.Services;
using SpeedyAir.Constants;
namespace SpeedyAir
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                OrderManager orderManager = new OrderManager();
                // Load flights using FlightDetails
                FlightDetails.LoadFlights(orderManager);

                // Print flight schedule
                Console.WriteLine("Flight Schedule:");
                orderManager.PrintFlightSchedule();

                // Load orders from JSON file
                string ordersJsonPath = "Orders/orders.json";
                orderManager.LoadOrders(ordersJsonPath);

                // Schedule orders
                orderManager.ScheduleOrders();

                // Print order itineraries
                Console.WriteLine("\nOrder Itineraries:");
                orderManager.PrintOrderItineraries();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: Something went wrong while running the application. Please try again or contact support if the problem persists.");
                Console.WriteLine($"Details: {ex.Message}");
            }
        }
    }
}
