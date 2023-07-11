using jQuery.Models;
using Microsoft.EntityFrameworkCore;

namespace jQuery.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }
        public DbSet<Author> Authors { get; set; }
    }
}
