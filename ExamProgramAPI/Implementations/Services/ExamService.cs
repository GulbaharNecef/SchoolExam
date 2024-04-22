using ExamProgramAPI.Abstraction.Services;
using ExamProgramAPI.Contexts;
using ExamProgramAPI.DbEntities;
using ExamProgramAPI.DTOs.ExamDTO;
using ExamProgramAPI.DTOs.TeacherDTO;
using ExamProgramAPI.ResponseModels;

namespace ExamProgramAPI.Implementations.Services
{
    public class ExamService : IExamService
    {
        private readonly ApplicationDbContext _dbContext;
        public ExamService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<GenericResponseModel<ExamCreateDTO>> CreateExam(ExamCreateDTO examCreateDTO)
		{

			GenericResponseModel<ExamCreateDTO> response = new() { Data = null, StatusCode = 400};
			if (examCreateDTO == null)
				return response;
			var validLesson = await _dbContext.Lessons.FindAsync(examCreateDTO.LessonCode);
			var validStudent = await _dbContext.Students.FindAsync(examCreateDTO.StudentNumber);
			if(validLesson != null && validStudent != null)
			{
				var exam = new Exam()
				{
					ExamDate = examCreateDTO.ExamDate,
					LessonCode = examCreateDTO.LessonCode,
					StudentNumber = examCreateDTO.StudentNumber,
					Mark = examCreateDTO.Mark
				};
				await _dbContext.Exams.AddAsync(exam);
				int affectedRows = await _dbContext.SaveChangesAsync();
				if (affectedRows > 0)
				{
					response.Data = examCreateDTO;
					response.StatusCode = 201;
				}
			}
			return response;
		}

        public async Task<GenericResponseModel<bool>> DeleteExamById(int id)
        {
			GenericResponseModel<bool> response = new();
			var deletedExam = await _dbContext.Exams.FindAsync(id);
			if (deletedExam == null)
			{
				response.Data = false;
				response.StatusCode = 400;
				return response;
			}
			_dbContext.Exams.Remove(deletedExam);
			int affectedRows = await _dbContext.SaveChangesAsync();
			if (affectedRows > 0)
			{
				response.Data = true;
				response.StatusCode = 200;
			}
			return response;
		}

        public async Task<GenericResponseModel<List<ExamGetDTO>>> GetExams()
        {
			GenericResponseModel<List<ExamGetDTO>> response = new();
			var exams = _dbContext.Exams
				.Select(t => new ExamGetDTO
				{
					ExamDate = t.ExamDate,
					LessonCode = t.LessonCode,
					ExamId = t.ExamId,
					Mark = t.Mark,
					StudentNumber = t.StudentNumber
				});

			if (exams != null)
			{
				response.Data = exams.ToList();
				response.StatusCode = 200;
			}
			return response;
		}

        public async Task<GenericResponseModel<ExamUpdateDTO>> UpdateExamById(int id, ExamUpdateDTO examUpdateDTO)
        {
			GenericResponseModel<ExamUpdateDTO> response = new() { Data = null, StatusCode = 400 };
			var updatedExam = await _dbContext.Exams.FindAsync(id);
			if (updatedExam != null)
			{
				var validStudent = await _dbContext.Students.FindAsync(examUpdateDTO.StudentNumber);
				var validLesson = await _dbContext.Lessons.FindAsync(examUpdateDTO.LessonCode);
				if(validLesson != null && validStudent != null)
				{
					updatedExam.ExamDate = examUpdateDTO.ExamDate;
					updatedExam.LessonCode = examUpdateDTO.LessonCode;
					updatedExam.StudentNumber = examUpdateDTO.StudentNumber;
					updatedExam.Mark = examUpdateDTO.Mark;

					_dbContext.Update(updatedExam);
					int affectedRows = await _dbContext.SaveChangesAsync();
					if (affectedRows > 0)
					{
						response.StatusCode = 200;
						response.Data = examUpdateDTO;
					}
				}
			}
			return response;
		}
    }
}
