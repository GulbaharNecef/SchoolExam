using ExamProgramAPI.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamProgramAPI.Configurations
{
	public class LessonConfig : IEntityTypeConfiguration<Lesson>
	{
		public void Configure(EntityTypeBuilder<Lesson> builder)
		{
			builder.Property(s => s.Class)
				.IsRequired()
				.HasColumnType("numeric(2,0)");

			builder.Property(s => s.LessonCode)
				.IsRequired()
				.HasMaxLength(3)
				.HasColumnType("char");
		}
	}
}
