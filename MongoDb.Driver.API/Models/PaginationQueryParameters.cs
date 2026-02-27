using Microsoft.AspNetCore.Mvc;

namespace MongoDb.Driver.API.Models;

public record PaginationQueryParameters
{
    [FromQuery(Name = "page")]
    public int? Page { get; init; } = default!;

    [FromQuery(Name = "pageSize")]
    public int? PageSize { get; init; } = default!;
}
