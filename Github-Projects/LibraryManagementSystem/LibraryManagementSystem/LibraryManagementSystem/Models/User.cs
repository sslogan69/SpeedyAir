
namespace LibraryManagementSystem.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public virtual ICollection<BorrowRecord>? BorrowRecords { get; set; }
    }
}
