using APPR6312POEPart1DAF.Models;
using Microsoft.EntityFrameworkCore;

namespace APPR6312POEPart1DAF.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<DonationItem> DonationsItems { get; set; }

        public DbSet<DonationMoney> DonationsMoney { get; set; }

        public DbSet<Disaster> Disasters { get; set; }

        public DbSet<Catagory> Catagories { get; set; }
    }
}
