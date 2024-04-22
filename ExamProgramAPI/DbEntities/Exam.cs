using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExamProgramAPI.DbEntities
{
	public class Exam
	{
		[Key]
		public int ExamId { get; set; }

		[Required]
		[StringLength(3)]
		public string LessonCode { get; set; }

		public int StudentNumber { get; set; }

		public DateTime ExamDate { get; set; }

		public int Mark { get; set; }

		[ForeignKey("StudentNumber")]
		public virtual Student Student { get; set; }

		[ForeignKey("LessonCode")]
		public virtual Lesson Lesson { get; set; }
	}
}
