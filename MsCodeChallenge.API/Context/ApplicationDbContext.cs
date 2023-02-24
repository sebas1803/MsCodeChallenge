using Microsoft.EntityFrameworkCore;
using MsCodeChallenge.API.Models;

namespace MsCodeChallenge.API.Context {
    public class ApplicationDbContext : DbContext {

        public DbSet<Product> Product { get; set; }
        public DbSet<Status> Status { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) {
        }

        //Sample Data
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Status>().HasData(
                new Status {
                    Id = 1,
                    StatusKey = "0",
                    StatusName = "Inactive",
                },
                new Status {
                    Id = 2,
                    StatusKey = "1",
                    StatusName = "Active",
                }
            );
        }

    }
}
