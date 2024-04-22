using ExamProgramAPI.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamProgramAPI.Configurations
{
	public class StudentConfig : IEntityTypeConfiguration<Student>
	{
		public void Configure(EntityTypeBuilder<Student> builder)
		{
			builder.Property(s => s.StudentNumber)
				.IsRequired()
				.HasColumnType("numeric(5,0)");

			builder.Property(s => s.Class)
				.IsRequired()
				.HasColumnType("numeric(2,0)");
		}
	}
}
