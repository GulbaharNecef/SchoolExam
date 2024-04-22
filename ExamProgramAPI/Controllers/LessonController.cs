using ExamProgramAPI.Abstraction.Services;
using ExamProgramAPI.DTOs.LessonDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProgramAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LessonController : ControllerBase
	{
		private readonly ILessonService _lessonService;
		public LessonController(ILessonService lessonService)
		{
			_lessonService = lessonService;
		}
		[HttpGet]
		public async Task<IActionResult> GetLessons()
		{
			var result = await _lessonService.GetLessons();
			return StatusCode(result.StatusCode, result);
		}

		[HttpPost]
		public async Task<IActionResult> CreateLesson(LessonCreateDTO lessonCreateDTO)
		{
			var result = await _lessonService.CreateLesson(lessonCreateDTO);
			return StatusCode(result.StatusCode, result);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateLessonById(string id, LessonUpdateDTO lessonUpdateDTO)
		{
			var result = await _lessonService.UpdateLessonById(id, lessonUpdateDTO);
			return StatusCode(result.StatusCode, result);
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteLessonById(string id)
		{
			var result = await _lessonService.DeleteLessonById(id);
			return StatusCode(result.StatusCode, result);
		}
	}
}
