using Microsoft.EntityFrameworkCore;

namespace HourCalcMVC.Models
{
    public class CalcDbContext : DbContext
    {
        public DbSet<DailyHour> dailyHours {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            //ToDo: Change Database name
        {
            optionsBuilder.UseSqlite("Data Source=Data/DatabaseTesting.db;");
        }
    }
}
