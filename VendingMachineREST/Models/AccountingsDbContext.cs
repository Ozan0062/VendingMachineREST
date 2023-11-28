using Microsoft.EntityFrameworkCore;

namespace VendingMachineREST.Models
{
    public class AccountingsDbContext : DbContext
    {
        public AccountingsDbContext(DbContextOptions<AccountingsDbContext> options) : base(options) { }

        public DbSet<Accounting> Accounting { get; set; }
    }
}
