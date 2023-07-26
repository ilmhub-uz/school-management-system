using SchoolManagement.Services.Students.Context;
using SchoolManagement.Services.Students.Entities;
using SchoolManagement.Services.Students.Helpers.PaginationEntities;

namespace SchoolManagement.Services.Students.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly StudentsDbContext _studentsDbContext;
    private readonly HttpContextHelper _httpContextHelper;

    public UnitOfWork(StudentsDbContext studentsDbContext, HttpContextHelper httpContextHelper)
    {
        _studentsDbContext = studentsDbContext;
        _httpContextHelper = httpContextHelper;
    }


    private IStudentRepository? _studentRepository;
    public IStudentRepository Students =>
        _studentRepository ??= new StudentRepository(_studentsDbContext, _httpContextHelper);


    private IStudentScienceRepository? _studentScienceRepository;
    public IStudentScienceRepository StudentSciences =>
        _studentScienceRepository ??= new StudentScienceRepository(_studentsDbContext);


    private IGenericRepository<StudentTaskResult>? _studentTaskResultRepository;
    public IGenericRepository<StudentTaskResult> StudentTaskResults =>
        _studentTaskResultRepository ??= new GenericRepository<StudentTaskResult>(_studentsDbContext);


    private IStudentAttendanceRepository? _studentAttendanceRepository;
    public IStudentAttendanceRepository StudentAttendances =>
        _studentAttendanceRepository ??= new StudentAttendanceRepository(_studentsDbContext);

}