using ExamProgramAPI.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamProgramAPI.Configurations
{
	public class ExamConfig : IEntityTypeConfiguration<Exam>
	{
		public void Configure(EntityTypeBuilder<Exam> builder)
		{
			builder.Property(s => s.StudentNumber)
				.IsRequired()
				.HasColumnType("numeric(5,0)");

			builder.Property(s => s.Mark)
				.IsRequired()
				.HasColumnType("numeric(1,0)");

			builder.Property(e => e.LessonCode)
				.IsRequired()
				.HasMaxLength(3)
				.HasColumnType("char");
		}
	}
}
