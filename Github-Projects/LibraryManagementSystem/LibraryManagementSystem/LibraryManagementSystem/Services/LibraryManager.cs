using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Services
{
    public class LibraryManager
    {
        private readonly LibraryContext _context;

        public LibraryManager(LibraryContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task BorrowBookAsync(int userId, int bookId)
        {
            try
            {
                var user = await _context.Users.FindAsync(userId);
                var book = await _context.Books.FindAsync(bookId);

                if (book == null || user == null || book.AvailableCopies <= 0)
                    throw new InvalidOperationException("Book is not available or user does not exist.");

                var borrowRecord = new BorrowRecord
                {
                    UserId = userId,
                    BookId = bookId,
                    BorrowDate = DateTime.Now
                };

                book.AvailableCopies--;
                _context.BorrowRecords.Add(borrowRecord);
                await _context.SaveChangesAsync();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }

        public async Task ReturnBookAsync(int userId, int bookId)
        {
            try
            {
                var borrowRecord = await _context.BorrowRecords
                    .Where(br => br.UserId == userId && br.BookId == bookId && br.ReturnDate == null)
                    .FirstOrDefaultAsync() ?? throw new InvalidOperationException("No active borrow record found.");
                var book = await _context.Books.FindAsync(bookId) ?? throw new InvalidOperationException("Book not found.");
                borrowRecord.ReturnDate = DateTime.Now;
                book.AvailableCopies++;

                await _context.SaveChangesAsync();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }

        public async Task DisplayAvailableBooksAsync()
        {
            var availableBooks = await _context.Books
                .Where(b => b.AvailableCopies > 0)
                .Select(b => new { b.Title, b.Author, b.AvailableCopies })
                .ToListAsync();

            foreach (var book in availableBooks)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Copies Available: {book.AvailableCopies}");
            }
        }
    }
}
