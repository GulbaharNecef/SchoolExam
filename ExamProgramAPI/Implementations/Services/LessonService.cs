using ExamProgramAPI.Abstraction.Services;
using ExamProgramAPI.Contexts;
using ExamProgramAPI.DbEntities;
using ExamProgramAPI.DTOs.LessonDTO;
using ExamProgramAPI.ResponseModels;

namespace ExamProgramAPI.Implementations.Services
{
    public class LessonService : ILessonService
    {
        private readonly ApplicationDbContext _dbContext;
        public LessonService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<GenericResponseModel<LessonCreateDTO>> CreateLesson(LessonCreateDTO lessonCreateDTO)
        {
			GenericResponseModel<LessonCreateDTO> response = new() { Data = null, StatusCode = 400 };
			if (lessonCreateDTO == null)
				return response;
			
			var validTeacher = await _dbContext.Teachers.FindAsync(lessonCreateDTO.TeacherId);
			if(validTeacher is not null)
			{
				var lesson = new Lesson()
				{
					LessonCode = lessonCreateDTO.LessonCode,
					LessonName = lessonCreateDTO.LessonName,
					Class = lessonCreateDTO.Class,
					TeacherId = lessonCreateDTO.TeacherId
				};
				await _dbContext.Lessons.AddAsync(lesson);
				int affectedRows = await _dbContext.SaveChangesAsync();
				if (affectedRows > 0)
				{
					response.Data = lessonCreateDTO;
					response.StatusCode = 201;
				}
			}
			return response;
		}

        public async Task<GenericResponseModel<bool>> DeleteLessonById(string id)
        {
			GenericResponseModel<bool> response = new();
			var deletedLesson = await _dbContext.Lessons.FindAsync(id);
			if (deletedLesson == null)
			{
				response.Data = false;
				response.StatusCode = 400;
				return response;
			}
			_dbContext.Lessons.Remove(deletedLesson);
			int affectedRows = await _dbContext.SaveChangesAsync();
			if (affectedRows > 0)
			{
				response.Data = true;
				response.StatusCode = 200;
			}
			return response;
		}

        public async Task<GenericResponseModel<List<LessonGetDTO>>> GetLessons()
        {
			GenericResponseModel<List<LessonGetDTO>> response = new();
			var lessons = _dbContext.Lessons
				.Select(t => new LessonGetDTO
				{
					LessonCode = t.LessonCode,
					LessonName = t.LessonName,
					Class = t.Class,
					TeacherId = t.TeacherId
				});

			if (lessons != null)
			{
				response.Data = lessons.ToList();
				response.StatusCode = 200;
			}
			return response;
		}

        public async Task<GenericResponseModel<LessonUpdateDTO>> UpdateLessonById(string lessonCode, LessonUpdateDTO lessonUpdateDTO)
        {
			GenericResponseModel<LessonUpdateDTO> response = new() { Data = null, StatusCode = 400 };
			var updatedLesson = await _dbContext.Lessons.FindAsync(lessonCode);
			if (updatedLesson != null)
			{
				var validTeacher = await _dbContext.Teachers.FindAsync(lessonUpdateDTO.TeacherId);
				if(validTeacher != null)
				{
					updatedLesson.LessonName = lessonUpdateDTO.LessonName;
					updatedLesson.Class = lessonUpdateDTO.Class;
					updatedLesson.TeacherId = lessonUpdateDTO.TeacherId;

					_dbContext.Update(updatedLesson);
					int affectedRows = await _dbContext.SaveChangesAsync();
					if (affectedRows > 0)
					{
						response.StatusCode = 200;
						response.Data = lessonUpdateDTO;
					}
				}
			}
			return response;
		}
    }
}
