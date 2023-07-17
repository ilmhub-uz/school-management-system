using Microsoft.OpenApi.Models;
using Student.API.Entities;
using Student.API.Exceptions;
using Student.API.FluentValidators;
using Student.API.Models.StudentScienceModels;
using Student.API.Repositories;
using Student.API.Repositories.Interfaces;

namespace Student.API.Managers
{
    public class StudentScienceManager
    {
        private readonly IStudentScienceRepository _studentScienceRepos;
        public StudentScienceManager(IStudentScienceRepository studentScienceRepos)
        {
            _studentScienceRepos = studentScienceRepos;
        }

        public async Task<List<StudentScienceModel>> GetStudentSciencesAsync()
        {
            var studentScience = await _studentScienceRepos.GetStudentSciencesAsync();

            return  ToStudentScienceModels(studentScience);
        }
        public async Task<StudentScienceModel> AddStudentScienceAsync(AddStudentScienceModel model)
        {
            var validator = new AddStudentScienceValidator();
            var result = validator.Validate(model);
            if (!result.IsValid)
            {
                throw new AddStudentAttendanceValiadtionIsNotValid("Invalid input try again");
            }
            var studentScience = new StudentScience()
            {
                ScienceId = model.ScienceId,
                StudentId = model.StudentId,
                CreatedAt = DateTime.UtcNow
            };
            await _studentScienceRepos.AddStudentScienceAsync(studentScience);
            return ToStudentScienceModel(studentScience);
        }

        public async Task<StudentScienceModel> GetStudentScienceByScienceIdAsync(Guid studentId,Guid scienceId)
        {
            var studentScience = await _studentScienceRepos.GetStudentScienceByScienceIdAsync(scienceId, studentId);

            return ToStudentScienceModel(studentScience);
        }

        public async Task<StudentScienceModel> UpdateStudentScienceAsync(UpdateStudentScienceModel model)
        {
            var validator = new UpdateStudentScienceValidor();
            var result = validator.Validate(model);
            if (!result.IsValid)
            {
                throw new UpdateStudentScienceValidationIsNotValid("Invalid update input try again");
            };
            var studentScience = new StudentScience()
            {
                ScienceId = model.ScienceId,
                StudentId = model.StudentId,
                CreatedAt = model.CreateAt,
                UpdatedAt = DateTime.UtcNow,
                Status = model.Status 
            };
            await _studentScienceRepos.UpdateStudentScienceAsync(studentScience);
            return ToStudentScienceModel(studentScience);
        }

        private StudentScienceModel ToStudentScienceModel(StudentScience studentScience)
        {
            var model = new StudentScienceModel()
            {
                ScienceId = studentScience.ScienceId,
                StudentId = studentScience.StudentId,
                CreatedAt = studentScience.CreatedAt,
            };
            if(studentScience.Status == Status.Created)
            {
                model.UpdatedAt = null;
            }
            else
            {
                model.UpdatedAt = studentScience.UpdatedAt;
            }
            return model;
        }
        private List<StudentScienceModel> ToStudentScienceModels(List<StudentScience> studentSciences)
        {
            if(studentSciences == null || studentSciences.Count == 0)
            {
                return new List<StudentScienceModel>();
            }
            var models = new List<StudentScienceModel>();
            foreach(var studentScience in studentSciences)
            {
                models.Add(ToStudentScienceModel(studentScience));
            }
            return models;
        }
        
    }
}
