using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Models
{
    public class BookingSystemContext : DbContext
    {
        public BookingSystemContext()
        {
        }

        public BookingSystemContext (DbContextOptions<BookingSystemContext> options)
            : base(options)
        {
        }

        public DbSet<BookingSystem.Models.Student> Student { get; set; }
    }
}