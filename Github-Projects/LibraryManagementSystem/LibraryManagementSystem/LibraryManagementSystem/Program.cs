using LibraryManagementSystem.Data;
using LibraryManagementSystem.Services;
using LibraryManagementSystem.Threads;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem
{
    class Program
    {
        static async Task Main(string[] args)
        {
                var serviceProvider = new ServiceCollection()
                .AddDbContext<LibraryContext>(options =>
                    options.UseSqlServer("Server=localhost;Database=LibraryDB;Integrated Security=True;TrustServerCertificate=True;")) // Your connection string
                .AddScoped<LibraryManager>()
                .AddScoped<MultiThreadingLibrary>()
                .BuildServiceProvider();

        
            var libraryManager = serviceProvider.GetService<LibraryManager>();
            var multiThreadingLibrary = serviceProvider.GetService<MultiThreadingLibrary>();

            // Display available books
            await libraryManager.DisplayAvailableBooksAsync();

            // Borrow a book
            await libraryManager.BorrowBookAsync(userId: 1, bookId: 1);

            // Return a book
            await libraryManager.ReturnBookAsync(userId: 1, bookId: 1);

            //Concurrent borrowing and returning using multi-threading
            await multiThreadingLibrary.BorrowBooksConcurrentlyAsync(2, 2);
            await multiThreadingLibrary.ReturnBooksConcurrentlyAsync(2, 2);
        }
    }
}
