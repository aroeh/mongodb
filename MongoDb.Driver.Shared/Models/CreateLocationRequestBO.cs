namespace MongoDb.Driver.Shared.Models;

public record CreateLocationRequestBO
(
    string Street,
    string City,
    string State,
    string Country,
    string ZipCode
);
