using SchoolManagement.Services.Students.Context;
using SchoolManagement.Services.Students.Entities;
using SchoolManagement.Services.Students.Extensions;
using SchoolManagement.Services.Students.Helpers.PaginationEntities;

namespace SchoolManagement.Services.Students.Repositories;

public class StudentRepository : GenericRepository<Student, StudentsDbContext, Guid>, IStudentRepository
{
    private readonly HttpContextHelper _httpContext;

    public StudentRepository(StudentsDbContext dbContext, HttpContextHelper httpContext) : base(dbContext)
    {
        _httpContext = httpContext;
    }

    public async ValueTask<IEnumerable<Student>> GetAllWithFilterAsync(StudentFilter filter)
    {
        IQueryable<Student> query = Entities;

        if (filter.FromDateTime is not null)
            query = query.Where(p => p.CreatedAt > filter.FromDateTime);
        
        if (filter.ToDateTime is not null)
            query = query.Where(p => p.CreatedAt < filter.ToDateTime);

        if (filter.UsernameText is not null)
            query = query.Where(p => p.Username.Contains(filter.UsernameText));

        return await query.ToPagedListAsync(_httpContext, filter);
    }
}