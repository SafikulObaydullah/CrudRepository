using Microsoft.EntityFrameworkCore;

namespace DirdGroupTest.Models
{
   public class ApplicationDbContext:DbContext
   {
      public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
      {

      }
      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         base.OnModelCreating(modelBuilder);
         //new StudentMap(modelBuilder.Entity<Student>());
      }
      public DbSet<EmployeeBasicInfo> Employees { get; set; }
   }
}
