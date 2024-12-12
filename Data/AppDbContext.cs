using Berber_Salonu.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Berber_Salonu.Data
{
    public class AppDbContext : DbContext
    {
        //عن طريق الـ DbSet، بتقدر تضيف، تعدّل، تقرأ، وتحذف بيانات من كل جدول بسهولة.
        public DbSet<Salon>Salons { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Booking> Bookings { get; set; }


        // من دون هذا ما راح يعرف كيف يتواصل مع قاعدة البيانات  
        //بيقول: "خذ الإعدادات اللي جايه من options ومررها للـ DbContext عشان يقدر يشتغل مع قاعدة البيانات."
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        // بينشئ بينات اولية مشان لا يصير عندي اخطاء بس افتح البرنامج و اعملو تيست
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 1,
                Name = "Admin",
                Email = "admin@salon.com",
                Password = "admin123", 
                Role = "Admin"
            });
        }
    }
}
