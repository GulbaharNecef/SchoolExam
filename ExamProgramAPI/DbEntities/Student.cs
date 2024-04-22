using System.ComponentModel.DataAnnotations;

namespace ExamProgramAPI.DbEntities
{
	public class Student
	{
		[Key]
		public int StudentNumber { get; set; }

		[Required]
		[StringLength(30)]
		public string Name { get; set; }

		[Required]
		[StringLength(30)]
		public string Surname { get; set; }

		public int Class { get; set; }
	}
}
