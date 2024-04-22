namespace ExamProgramAPI.DTOs.ExamDTO
{
	public class ExamCreateDTO
	{
		public string LessonCode { get; set; }
		public int StudentNumber { get; set; }
		public DateTime ExamDate { get; set; }
		public int Mark { get; set; }
	}
}
