using Microsoft.EntityFrameworkCore;
using Sciences.API.Context;
using Sciences.API.Entities;
using Sciences.API.Repositories.Interfaces;

namespace Sciences.API.Repositories;

public class ScienceRepository: IScienceRepository
{
    private readonly ScienceDbContext _context;

    public ScienceRepository(ScienceDbContext context)
    {
        _context = context;
    }

    public async Task<List<Science>> GetSciences()
    {
        return await _context.Sciences.ToListAsync();
    }

    public async Task AddScience(Science science)
    {
        _context.Sciences.Add(science);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateScience(Science science)
    {
        _context.Sciences.Update(science);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteScience(Science science)
    {
        _context.Sciences.Remove(science);
        await _context.SaveChangesAsync();
    }

    public async Task<Science> GetScienceById(Guid scienceId)
    {
        var science = await _context.Sciences.FirstOrDefaultAsync(s => s.Id == scienceId);
        if (science == null)
            throw new Exception("Science Not Found");
        return science;
    }
}