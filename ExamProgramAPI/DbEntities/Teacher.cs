using System.ComponentModel.DataAnnotations;

namespace ExamProgramAPI.DbEntities
{
	public class Teacher
	{
		[Key]
		public int TeacherId { get; set; }

		[Required]
		[StringLength(30)]
		public string Name { get; set; }

		[Required]
		[StringLength(30)]
		public string Surname { get; set; }
	}
}
