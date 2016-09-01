using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HappyHourBeerList.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Bar> Bars { get; set; }
        public DbSet<Beer> Beers { get; set; }
        public DbSet<Brewer> Brewers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Create a 1 to 1 relationship between Bar and Address since a bar can only have one address and
            //an address can only have one bar. Same for Brewer and Address. Also made Address foreign keys nullable since one Address record will either be associated with EITHER
            //A Brewer OR a Bar but not both.
            base.OnModelCreating(modelBuilder);

            //Set up many-to-many relationship between Bars and Beers since a Bar can have many beers and
            //a beer can be served at many bars.
            modelBuilder.Entity<Bar>()
                .HasMany(b => b.Beers)
                .WithMany(b => b.Bars)
                .Map(m => m.ToTable("BarsBeers"));
                //.WillCascadeOnDelete(false));

            modelBuilder.Entity<Bar>().Property(p => p.GooglePlaceId).IsRequired();
            modelBuilder.Entity<Beer>().Property(p => p.Brewer).IsRequired();
            modelBuilder.Entity<Beer>().Property(p => p.Name).IsRequired();

        }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


    }
}