using System.ComponentModel.DataAnnotations;

namespace ExamProgramAPI.DTOs.StudentDTO
{
	public class StudentCreateDTO
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public int Class { get; set; }
	}
}
