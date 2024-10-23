using LibraryManagementSystem.Services;
using System;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Threads
{
    public class MultiThreadingLibrary
    {
        private readonly LibraryManager _libraryManager;

        // Constructor accepting LibraryManager via Dependency Injection
        public MultiThreadingLibrary(LibraryManager libraryManager)
        {
            _libraryManager = libraryManager ?? throw new ArgumentNullException(nameof(libraryManager));
        }

        public async Task BorrowBooksConcurrentlyAsync(int userId, int bookId)
        {
            // Start the borrow book task
            await Task.Run(async () => await _libraryManager.BorrowBookAsync(userId, bookId));
        }

        public async Task ReturnBooksConcurrentlyAsync(int userId, int bookId)
        {
            // Start the return book task
            await Task.Run(async () => await _libraryManager.ReturnBookAsync(userId, bookId));
        }

        public async Task DisplayAvailableBooksAsync()
        {
            await _libraryManager.DisplayAvailableBooksAsync();
        }
    }
}
