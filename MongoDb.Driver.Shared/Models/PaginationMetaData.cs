namespace MongoDb.Driver.Shared.Models;

public record PaginationMetaData
(
    int CurrentPage,
    int PageRecordCount,
    int PageSize,
    long TotalRecords
)
{
    public PaginationMetaData(int currentPage, int pageRecordCount, int pageSize, int totalRecords) : this(currentPage, pageRecordCount, pageSize, (long)totalRecords)
    { }

    public int TotalPages => CalculateTotalPages((decimal)TotalRecords, (decimal)PageSize);

    private static int CalculateTotalPages(decimal totalRecords, decimal pageSize)
    {
        return (int)Math.Ceiling(totalRecords / pageSize);
    }
}
