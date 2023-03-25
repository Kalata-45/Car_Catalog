using Microsoft.EntityFrameworkCore;
using Cars_Catalog_Projekt.Data.Entities;

namespace Cars_Catalog_Projekt.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Vechicle> Vechicles { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
    }
}
