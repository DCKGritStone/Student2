using Microsoft.EntityFrameworkCore;
using Student2.API.Data;

namespace Student2.API.DataContext
{
    public class Student2DbContext : DbContext
    {
        public Student2DbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<AssessmentCategory> Categories { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<AssessmentResult> Results{ get; set; }
    }
}
