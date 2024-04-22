using ExamProgramAPI.Abstraction.Services;
using ExamProgramAPI.DTOs.ExamDTO;
using ExamProgramAPI.DTOs.TeacherDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProgramAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ExamController : ControllerBase
	{
		private readonly IExamService _examService;
		public ExamController(IExamService examService)
		{
			_examService = examService;
		}
		[HttpGet]
		public async Task<IActionResult> GetExams()
		{
			var result = await _examService.GetExams();
			return StatusCode(result.StatusCode, result);
		}

		[HttpPost]
		public async Task<IActionResult> CreateExam(ExamCreateDTO examCreateDTO)
		{
			var result = await _examService.CreateExam(examCreateDTO);
			return StatusCode(result.StatusCode, result);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateExam(int id,ExamUpdateDTO examUpdateDTO)
		{
			var result = await _examService.UpdateExamById(id, examUpdateDTO);
			return StatusCode(result.StatusCode, result);
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteExam(int id)
		{
			var result = await _examService.DeleteExamById(id);
			return StatusCode(result.StatusCode, result);
		}
	}
}
