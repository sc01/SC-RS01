using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Sign.Models.Business
{
    public class RealStateDatabase : IdentityDbContext<ApplicationUser>
    {
        public RealStateDatabase(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<AttachmentForApartment> AttachmentForApartments { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Contract> Contracts { get; set; }

        public DbSet<Building> Buildings { get; set; }

    }
}
