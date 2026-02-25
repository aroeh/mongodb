namespace MongoDb.Driver.Shared.Models;

public record UpdateLocationRequestBO
(
    string? Street,
    string? City,
    string? State,
    string? Country,
    string? ZipCode
);
