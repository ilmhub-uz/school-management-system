namespace SchoolManagement.Services.Identity.Helpers;

public class PaginationParams
{
    private const int MaxPageSize = 500;
    private const int MinPageNumber = 1;

    private int _pageSize = 5;
    private int _pageNumber = 1;

    public int Size
    {
        get => _pageSize > MaxPageSize ? MaxPageSize : _pageSize <= 0 ? 1 : _pageSize;
        set => _pageSize = value;
    }

    public int Page
    {
        get => _pageNumber = _pageNumber < MinPageNumber ? MinPageNumber : _pageNumber;
        set => _pageNumber = value;
    }
}