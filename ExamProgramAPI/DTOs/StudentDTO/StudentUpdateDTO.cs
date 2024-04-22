using System.ComponentModel.DataAnnotations;

namespace ExamProgramAPI.DTOs.StudentDTO
{
	public class StudentUpdateDTO
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public int Class { get; set; }
	}
}
