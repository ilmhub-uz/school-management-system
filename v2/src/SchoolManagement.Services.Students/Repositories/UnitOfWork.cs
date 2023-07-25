using SchoolManagement.Services.Students.Context;
using SchoolManagement.Services.Students.Entities;

namespace SchoolManagement.Services.Students.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly StudentsDbContext _studentsDbContext;

    private IStudentRepository? _studentRepository;
    public IStudentRepository Students =>
        _studentRepository ??= new StudentRepository(_studentsDbContext);

    private IStudentScienceRepository? _studentScienceRepository;
    public IStudentScienceRepository StudentSciences =>
        _studentScienceRepository ??= new StudentScienceRepository(_studentsDbContext);

    private IGenericRepository<StudentTaskResult>? _studentTaskResultRepository;
    public IGenericRepository<StudentTaskResult> StudentTaskResults =>
        _studentTaskResultRepository ??= new GenericRepository<StudentTaskResult>(_studentsDbContext);


    private IStudentAttendanceRepository? _studentAttendanceRepository;

    public IStudentAttendanceRepository StudentAttendances =>
        _studentAttendanceRepository ??= new StudentAttendanceRepository(_studentsDbContext);

    public UnitOfWork(StudentsDbContext studentsDbContext)
    {
        _studentsDbContext = studentsDbContext;
    }
}