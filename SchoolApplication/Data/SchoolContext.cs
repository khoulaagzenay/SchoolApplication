using Microsoft.EntityFrameworkCore;
using SchoolApplication.Models;

namespace SchoolApplication.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Teacher> Teachers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //To establish Link in Db
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Teacher)
                .WithMany(t => t.Courses)
                .HasForeignKey(c => c.TeacherId);

            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Student)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.StudentId);

            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Course)
                .WithMany(c => c.Grades)
                .HasForeignKey(g => g.CourseId);
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher()
                {
                    Id = 1,
                    Name = "John",
                    Lastname = "Doe"
                },
                new Teacher()
                {
                    Id = 2,
                    Name = "Jane",
                    Lastname = "Smith"
                },
                new Teacher()
                {
                    Id = 3,
                    Name = "Alice",
                    Lastname = "Johnson"
                }

            );

            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    Id = 1,
                    Name = "Ragnar",
                    Lastname = "Lothbrok",
                    Birthdate = new DateTime(1992, 12, 12),
                    Email = "rag@gmail.com"
                },
                new Student()
                {
                    Id = 2,
                    Name = "Lagherta",
                    Lastname = "Lothbrok",
                    Birthdate = new DateTime(1996, 6, 6),
                    Email = "lag@gmail.com"
                },
                new Student()
                {
                    Id = 3,
                    Name = "Bjorn",
                    Lastname = "IronBorn",
                    Birthdate = new DateTime(2000, 2, 2),
                    Email = "bjorn@gmail.com"
                }
            );
            modelBuilder.Entity<Course>().HasData(
                new Course()
                {
                    Id = 1,
                    Name = "History",
                    TeacherId = 1
                },
                new Course()
                {
                    Id = 2,
                    Name = "Math",
                    TeacherId = 2
                },
                new Course()
                {
                    Id = 3,
                    Name = "War",
                    TeacherId = 3
                }
            );
            modelBuilder.Entity<Grade>().HasData(
                new Grade()
                {
                    Id = 1,
                    Observation = "Ok",
                    Value = 10.5,
                    StudentId = 1,
                    CourseId = 1
                },
                new Grade()
                {
                    Id = 2,
                    Observation = "TB",
                    Value = 16.5,
                    StudentId = 1,
                    CourseId = 1
                },
                new Grade()
                {
                    Id = 3,
                    Observation = "Ok",
                    Value = 10.5,
                    StudentId = 2,
                    CourseId = 2
                },
                new Grade()
                {
                    Id = 4,
                    Observation = "TB",
                    Value = 16.5,
                    StudentId = 3,
                    CourseId = 3
                },
                new Grade()
                {
                    Id = 5,
                    Observation = "TB",
                    Value = 16.5,
                    StudentId = 3,
                    CourseId = 1
                }
                );
        }
    }
}
    

