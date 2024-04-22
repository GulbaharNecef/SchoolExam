using System.ComponentModel.DataAnnotations;

namespace ExamProgramAPI.DTOs.TeacherDTO
{
	public class TeacherGetDTO
	{
		public int TeacherId { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
	}
}
