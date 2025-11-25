using Microsoft.EntityFrameworkCore;
using StudentCoursesApp.Models;

namespace StudentCoursesApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId);

            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Rofhiwa Sithari" },
                new Student { Id = 2, Name = "Bob De Builder" }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Title = "Math 101" },
                new Course { Id = 2, Title = "History 201" }
            );

            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment { Id = 1, StudentId = 1, CourseId = 1, Grade = "A" },
                new Enrollment { Id = 2, StudentId = 2, CourseId = 1, Grade = "B" },
                new Enrollment { Id = 3, StudentId = 1, CourseId = 2, Grade = "A" }
            );
        }
    }
}