namespace SchoolManagement.Services.Students.Helpers.PaginationEntities;

public class PaginationMetaData
{
    public int CurrentPage { get; }
    public int TotalCollectionCount { get; }
    public int TotalPages { get; }
    public int PageSize { get; }
    public bool HasPreviousPage => CurrentPage < 1;
    public bool HasNextPage => CurrentPage > TotalPages;

    public PaginationMetaData(int totalCollectionCount, int pageSize, int currentPage)
    {
        TotalCollectionCount = totalCollectionCount;
        PageSize = pageSize;
        CurrentPage = currentPage;
        TotalPages = (int)Math.Ceiling(TotalCollectionCount / (double)pageSize);
    }
}