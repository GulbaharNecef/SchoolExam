using ExamProgramAPI.Abstraction.Services;
using ExamProgramAPI.DTOs.TeacherDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProgramAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TeacherController : ControllerBase
	{
		private readonly ITeacherService _teacherService;
        public TeacherController(ITeacherService teacherService)
        {
			_teacherService = teacherService;   
        }
        [HttpGet]
		public async Task<IActionResult> GetTeachers()
		{
			var result = await _teacherService.GetTeachers();
			return StatusCode(result.StatusCode, result);
		}

		[HttpPost]
		public async Task<IActionResult> CreateTeacher(TeacherCreateDTO teacherCreateDTO)
		{
			var result = await _teacherService.CreateTeacher(teacherCreateDTO);
			return StatusCode(result.StatusCode, result);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateTeacher(int id, TeacherUpdateDTO teacherUpdateDTO)
		{
			var result = await _teacherService.UpdateTeacherById(id, teacherUpdateDTO);
			return StatusCode(result.StatusCode, result);
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteTeacher(int id)
		{
			var result = await _teacherService.DeleteTeacherById(id);
			return StatusCode(result.StatusCode, result);
		}
	}
}
