using Emlakci.Entity;
using Microsoft.EntityFrameworkCore;

namespace Emlakci.WEBAPI.Models.Context
{
    public class EstateContext:DbContext
    {
        public EstateContext(DbContextOptions<EstateContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductDetails)
                .WithOne(pd => pd.Product)
                .HasForeignKey<ProductDetails>(pd => pd.ProductId);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<WhoWeAre> WhoWeAres { get; set; }
        public DbSet<Employment> Employments { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Mail> Mails { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<TodoList> TodoLists { get; set; }
    }
}
