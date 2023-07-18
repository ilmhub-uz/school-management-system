using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagement.Services.Identity.Helpers;

public static class CollectionExtensions
{
    public static async Task<IEnumerable<T>> ToPagedListAsync<T>(this IQueryable<T> source, PaginationParams? pageParams)
    {
        pageParams ??= new PaginationParams();

        HttpContextHelper.AddResponseHeader("X-Pagination",
            JsonSerializer.Serialize(new PaginationMetaData(source.Count(), pageParams.Size, pageParams.Page)));

        return await source.Skip(pageParams.Size * (pageParams.Page - 1)).Take(pageParams.Size).ToListAsync();
    }
}