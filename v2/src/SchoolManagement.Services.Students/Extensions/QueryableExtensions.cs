using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SchoolManagement.Services.Students.Helpers.PaginationEntities;

namespace SchoolManagement.Services.Students.Extensions;

public static class QueryableExtensions
{
    public static async Task< IEnumerable<T>> ToPagedListAsync<T>(
        this IQueryable<T> collection,
        HttpContextHelper contextHelper,
        PaginationParams pageParams)
    {
        pageParams ??= new PaginationParams();

        contextHelper.AddResponseHeader("X-Pagination",
            JsonConvert.SerializeObject(
                new PaginationMetaData(collection.Count(), pageParams.Size, pageParams.Page)));

        return await collection.Skip(pageParams.Size * (pageParams.Page - 1)).Take(pageParams.Size).ToListAsync();
    }
}