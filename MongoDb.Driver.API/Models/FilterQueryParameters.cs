using Microsoft.AspNetCore.Mvc;

namespace MongoDb.Driver.API.Models;

public record FilterQueryParameters : PaginationQueryParameters
{
    [FromQuery(Name = "name")]
    public string[]? Names { get; init; } = default!;

    [FromQuery(Name = "cuisine")]
    public string? CuisineType { get; init; } = default!;
}
