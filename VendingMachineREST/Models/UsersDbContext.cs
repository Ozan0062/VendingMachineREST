using Microsoft.EntityFrameworkCore;

namespace VendingMachineREST.Models
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
    }
}
