using Microsoft.EntityFrameworkCore;
using Sciences.API.Entities;

namespace Sciences.API.Context;

public class ScienceDbContext:DbContext
{
    public DbSet<Science> Sciences => Set<Science>();
    public DbSet<Topic>Topics => Set<Topic>();
    public DbSet<TopicTask> TopicTasks => Set<TopicTask>();

    public ScienceDbContext(DbContextOptions<ScienceDbContext> options) : base(options)
    {

    }

}