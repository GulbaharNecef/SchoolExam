using ExamProgramAPI.DTOs.ExamDTO;
using ExamProgramAPI.DTOs.StudentDTO;
using ExamProgramAPI.ResponseModels;

namespace ExamProgramAPI.Abstraction.Services
{
	public interface IStudentService
	{
		Task<GenericResponseModel<List<StudentGetDTO>>> GetStudents();
		Task<GenericResponseModel<StudentCreateDTO>> CreateStudent(StudentCreateDTO studentCreateDTO);
		Task<GenericResponseModel<StudentUpdateDTO>> UpdateStudentById(int id, StudentUpdateDTO studentUpdateDTO);
		Task<GenericResponseModel<bool>> DeleteStudentById(int id);
	}
}
