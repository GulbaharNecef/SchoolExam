using ExamProgramAPI.Abstraction.Services;
using ExamProgramAPI.Contexts;
using ExamProgramAPI.DbEntities;
using ExamProgramAPI.DTOs.StudentDTO;
using ExamProgramAPI.ResponseModels;

namespace ExamProgramAPI.Implementations.Services
{
	public class StudentService : IStudentService
	{
		private readonly ApplicationDbContext _dbContext;
		public StudentService(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<GenericResponseModel<StudentCreateDTO>> CreateStudent(StudentCreateDTO studentCreateDTO)
		{

			GenericResponseModel<StudentCreateDTO> response = new();
			if (studentCreateDTO == null)
			{
				response.StatusCode = 400;
				response.Data = null;
				return response;
			}

			var student = new Student()
			{
				Name = studentCreateDTO.Name,
				Surname = studentCreateDTO.Surname,
				Class = studentCreateDTO.Class
			};
			await _dbContext.Students.AddAsync(student);
			int affectedRows = await _dbContext.SaveChangesAsync();
			if (affectedRows > 0)
			{
				response.Data = studentCreateDTO;
				response.StatusCode = 201;
			}
			return response;
		}

		public async Task<GenericResponseModel<bool>> DeleteStudentById(int id)
		{
			GenericResponseModel<bool> response = new();
			var deletedStudent = await _dbContext.Students.FindAsync(id);
			if (deletedStudent == null)
			{
				response.Data = false;
				response.StatusCode = 400;
				return response;
			}
			_dbContext.Students.Remove(deletedStudent);
			int affectedRows = await _dbContext.SaveChangesAsync();
			if (affectedRows > 0)
			{
				response.Data = true;
				response.StatusCode = 200;
			}
			return response;
		}

		public async Task<GenericResponseModel<List<StudentGetDTO>>> GetStudents()
		{
			GenericResponseModel<List<StudentGetDTO>> response = new();
			var students = _dbContext.Students
				.Select(s => new StudentGetDTO
				{
					StudentNumber = s.StudentNumber,
					Name = s.Name,
					Surname = s.Surname,
					Class = s.Class
				});

			if (students != null)
			{
				response.Data = students.ToList();
				response.StatusCode = 200;
			}
			return response;
		}

		public async Task<GenericResponseModel<StudentUpdateDTO>> UpdateStudentById(int id, StudentUpdateDTO studentUpdateDTO)
		{
			GenericResponseModel<StudentUpdateDTO> response = new() { Data = null, StatusCode = 400 };
			var updatedStudent = await _dbContext.Students.FindAsync(id);
			if (updatedStudent != null)
			{
				updatedStudent.Name = studentUpdateDTO.Name;
				updatedStudent.Surname = studentUpdateDTO.Surname;
				updatedStudent.Class = studentUpdateDTO.Class;
				_dbContext.Update(updatedStudent);
				int affectedRows = await _dbContext.SaveChangesAsync();
				if (affectedRows > 0)
				{
					response.StatusCode = 200;
					response.Data = studentUpdateDTO;
					return response;
				}
			}
			return response;
		}
	}
}
