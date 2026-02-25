namespace MongoDb.Driver.Shared.Models;

public record LocationBO
(
    string Street,
    string City,
    string State,
    string Country,
    string ZipCode
);
