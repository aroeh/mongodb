namespace MongoDb.Driver.Shared.Models;

public record FilterQueryParametersBO
(
    string[]? Names,
    string? CuisineType
) : PaginationQueryParametersBO;
