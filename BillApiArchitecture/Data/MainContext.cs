

using Microsoft.EntityFrameworkCore;


namespace BillApiArchitecture.Data
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {

        }

        public DbSet<Owner>? Owners { get; set; }
        public DbSet<Property>? Properties { get; set; }


    }
}
