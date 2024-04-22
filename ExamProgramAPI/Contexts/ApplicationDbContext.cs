using ExamProgramAPI.Configurations;
using ExamProgramAPI.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace ExamProgramAPI.Contexts
{
	public class ApplicationDbContext:DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
		public DbSet<Student> Students { get; set; }
		public DbSet<Exam> Exams { get; set; }  
		public DbSet<Lesson> Lessons { get; set; }  
		public DbSet<Teacher> Teachers { get; set; }  

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfiguration(new StudentConfig());
			modelBuilder.ApplyConfiguration(new ExamConfig());
			modelBuilder.ApplyConfiguration(new LessonConfig());
		}
	}
}
