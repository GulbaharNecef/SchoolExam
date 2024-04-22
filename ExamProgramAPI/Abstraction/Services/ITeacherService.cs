using ExamProgramAPI.DTOs.LessonDTO;
using ExamProgramAPI.DTOs.TeacherDTO;
using ExamProgramAPI.ResponseModels;

namespace ExamProgramAPI.Abstraction.Services
{
	public interface ITeacherService
	{
		Task<GenericResponseModel<List<TeacherGetDTO>>> GetTeachers();
		Task<GenericResponseModel<TeacherCreateDTO>> CreateTeacher(TeacherCreateDTO teacherCreateDTO);
		Task<GenericResponseModel<TeacherUpdateDTO>> UpdateTeacherById(int id, TeacherUpdateDTO teacherUpdateDTO);
		Task<GenericResponseModel<bool>> DeleteTeacherById(int id);
	}
}
