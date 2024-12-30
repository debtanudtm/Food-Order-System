using Microsoft.EntityFrameworkCore;

namespace Food_Order_System.Models
{
    public class ProjectContext :DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) { }
        public DbSet<Owner> TblOwner { get; set; }
        public DbSet<Category> TblCategory { get; set; }
        public DbSet<Item> TblItem { get; set; }
        public DbSet<User> TblUser { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>().HasData(
                new Owner { Email = "dtm2024@gmail.com", Password = "12345" });

            modelBuilder.Entity<Category>().HasData(
                new Category { Category_ID = 1, Category_Name = "Veg" },
                new Category { Category_ID = 2, Category_Name = "Non-Veg" });

        }
    }
}

