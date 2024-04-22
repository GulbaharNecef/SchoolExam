using ExamProgramAPI.DTOs.LessonDTO;
using ExamProgramAPI.DTOs.StudentDTO;
using ExamProgramAPI.ResponseModels;

namespace ExamProgramAPI.Abstraction.Services
{
	public interface ILessonService
	{
		Task<GenericResponseModel<List<LessonGetDTO>>> GetLessons();
		Task<GenericResponseModel<LessonCreateDTO>> CreateLesson(LessonCreateDTO lessonCreateDTO);
		Task<GenericResponseModel<LessonUpdateDTO>> UpdateLessonById(string lessonCode, LessonUpdateDTO lessonUpdateDTO);
		Task<GenericResponseModel<bool>> DeleteLessonById(string id);
	}
}
