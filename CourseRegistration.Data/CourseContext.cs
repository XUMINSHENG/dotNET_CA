using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CourseRegistration.Models;


namespace CourseRegistration.Data
{
    public class CourseContext : DbContext
    {
        public CourseContext():
            base("DefaultConnection")
        {
        }

        public CourseContext(String ConnectionString) :
            base(ConnectionString)
        {
        }

        public DbSet<Staff> Staff { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseClass> CourseClasses { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<IndividualUser> IndividualUsers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyHR> CompanyHRs { get; set; }

    }
}
