using ExamProgramAPI.Abstraction.Services;
using ExamProgramAPI.Contexts;
using ExamProgramAPI.DbEntities;
using ExamProgramAPI.DTOs.TeacherDTO;
using ExamProgramAPI.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace ExamProgramAPI.Implementations.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ApplicationDbContext _dbContext;
        public TeacherService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GenericResponseModel<TeacherCreateDTO>> CreateTeacher(TeacherCreateDTO teacherCreateDTO)
        {
            GenericResponseModel<TeacherCreateDTO> response = new();
            if (teacherCreateDTO == null)
            {
                response.StatusCode = 400;
                response.Data = null;
                return response;
            }

            var teacher = new Teacher()
            {
                Name = teacherCreateDTO.Name,
                Surname = teacherCreateDTO.Surname
            };
            await _dbContext.Teachers.AddAsync(teacher);
            int affectedRows = await _dbContext.SaveChangesAsync();
            if (affectedRows > 0)
            {
                response.Data = teacherCreateDTO;
                response.StatusCode = 201;
            }
            return response;
        }

        public async Task<GenericResponseModel<bool>> DeleteTeacherById(int teacherId)
        {
            GenericResponseModel<bool> response = new();
            var deletedTeacher = await _dbContext.Teachers.FindAsync(teacherId);
            if (deletedTeacher == null)
            {
                response.Data = false;
                response.StatusCode = 400;
                return response;
            }
            _dbContext.Teachers.Remove(deletedTeacher);
            int affectedRows = await _dbContext.SaveChangesAsync();
            if (affectedRows > 0)
            {
                response.Data = true;
                response.StatusCode = 200;
            }
            return response;
        }

        public async Task<GenericResponseModel<List<TeacherGetDTO>>> GetTeachers()
        {
            GenericResponseModel<List<TeacherGetDTO>> response = new();
            var teachers = _dbContext.Teachers
                .Select(t => new TeacherGetDTO
                {
                    TeacherId = t.TeacherId,
                    Name = t.Name,
                    Surname = t.Surname
                });

            if (teachers != null)
            {
                response.Data = teachers.ToList();
                response.StatusCode = 200;
            }
            return response;
        }

        public async Task<GenericResponseModel<TeacherUpdateDTO>> UpdateTeacherById(int id, TeacherUpdateDTO teacherUpdateDTO)
        {
            GenericResponseModel<TeacherUpdateDTO> response = new() { Data = null, StatusCode = 400 };
            var updatedTeacher = await _dbContext.Teachers.FindAsync(id);
            if (updatedTeacher != null)
            {
                updatedTeacher.Name = teacherUpdateDTO.Name;
                updatedTeacher.Surname = teacherUpdateDTO.Surname;
                _dbContext.Update(updatedTeacher);//todo bunu yazmadan yoxla
                int affectedRows = await _dbContext.SaveChangesAsync();
                if (affectedRows > 0)
                {
                    response.StatusCode = 200;
                    response.Data = teacherUpdateDTO;
                    return response;
                }
            }
            return response;
        }
    }
}
