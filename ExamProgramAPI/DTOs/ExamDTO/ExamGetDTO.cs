namespace ExamProgramAPI.DTOs.ExamDTO
{
	public class ExamGetDTO
	{
		public int ExamId { get; set; }
		public string LessonCode { get; set; }
		public int StudentNumber { get; set; }
		public DateTime ExamDate { get; set; }
		public int Mark { get; set; }
	}
}
