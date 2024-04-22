using ExamProgramAPI.Abstraction.Services;
using ExamProgramAPI.DTOs.StudentDTO;
using ExamProgramAPI.DTOs.TeacherDTO;
using ExamProgramAPI.Implementations.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProgramAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentController : ControllerBase
	{
		private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
		}

		[HttpGet]
		public async Task<IActionResult> GetStudents()
		{
			var result = await _studentService.GetStudents();
			return StatusCode(result.StatusCode, result);
		}

		[HttpPost]
		public async Task<IActionResult> CreateStudent(StudentCreateDTO studentCreateDTO)
		{
			var result = await _studentService.CreateStudent(studentCreateDTO);
			return StatusCode(result.StatusCode, result);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateStudent(int id, StudentUpdateDTO studentUpdateDTO)
		{
			var result = await _studentService.UpdateStudentById(id, studentUpdateDTO);
			return StatusCode(result.StatusCode, result);
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteStudent(int id)
		{
			var result = await _studentService.DeleteStudentById(id);
			return StatusCode(result.StatusCode, result);
		}
	}
}
