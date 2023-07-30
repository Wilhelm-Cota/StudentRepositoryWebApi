using Microsoft.EntityFrameworkCore;

namespace StudentRestApi.Model
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) {


        }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    FirstName = " Paulus",
                    LastName = "Wilhelm",
                    Email = "pauluswilhelm85@gmail.com",
                    StudentId = 1,
                    Gender = Gender.Male,
                    Department = "Back-end Developer"
                },
                new Student
                {
                    FirstName = "Tangi",
                    LastName = "Kandjimwena",
                    Email = "TK@MAIL.COM",
                    StudentId = 2,
                    Gender = Gender.Male,
                    Department = "Front-end Developer"
                },
                new Student
                {
                    FirstName = "Imms",
                    LastName = "Immunel",
                    Email = "I@gmail.com",
                    StudentId = 3,
                    Gender = Gender.Male,
                    Department = "Graphics Designer"
                }
                );
        }
    }
}
