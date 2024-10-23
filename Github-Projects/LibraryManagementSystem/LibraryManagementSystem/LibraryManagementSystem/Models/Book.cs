namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public int AvailableCopies { get; set; }
    }
}
