using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamProgramAPI.DbEntities
{
	public class Lesson
	{
		[Key]
		[StringLength(3)]
		public string LessonCode { get; set; }

		[Required]
		[StringLength(30)]
		public string LessonName { get; set; }

		public int Class { get; set; }

		[Required]
		public int TeacherId { get; set; }

		[ForeignKey("TeacherId")]
		public virtual Teacher Teacher { get; set; }
	}
}
