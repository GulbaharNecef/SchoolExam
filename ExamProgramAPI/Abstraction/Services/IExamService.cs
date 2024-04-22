using ExamProgramAPI.DTOs.ExamDTO;
using ExamProgramAPI.ResponseModels;

namespace ExamProgramAPI.Abstraction.Services
{
	public interface IExamService
	{
		Task<GenericResponseModel<List<ExamGetDTO>>> GetExams();
		Task<GenericResponseModel<ExamCreateDTO>> CreateExam(ExamCreateDTO examCreateDTO);
		Task<GenericResponseModel<ExamUpdateDTO>> UpdateExamById(int id, ExamUpdateDTO examUpdateDTO);
		Task<GenericResponseModel<bool>> DeleteExamById(int id);
	}
}
