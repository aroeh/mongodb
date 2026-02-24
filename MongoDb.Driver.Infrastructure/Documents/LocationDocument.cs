using MongoDB.Bson.Serialization.Attributes;

namespace MongoDb.Driver.Infrastructure.Documents;

public record LocationDocument
{
    [BsonElement("street")]
    public string Street { get; set; } = string.Empty;

    [BsonElement("city")]
    public string City { get; set; } = string.Empty;

    [BsonElement("state")]
    public string State { get; set; } = string.Empty;

    [BsonElement("country")]
    public string Country { get; set; } = "United States";

    [BsonElement("zipCode")]
    public string ZipCode { get; set; } = string.Empty;
}
