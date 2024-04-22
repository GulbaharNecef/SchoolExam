using System.ComponentModel.DataAnnotations;

namespace ExamProgramAPI.DTOs.LessonDTO
{
	public class LessonGetDTO
	{
		public string LessonCode { get; set; }
		public string LessonName { get; set; }
		public int Class { get; set; }
		public int TeacherId { get; set; }
	}
}
