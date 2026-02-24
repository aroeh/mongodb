using MongoDb.Driver.Infrastructure.Documents;
using MongoDb.Driver.Shared.Models;

namespace MongoDb.Driver.Infrastructure.Extensions;

internal static class RestuarantDocumentExtensions
{
    internal static Restuarant ToRestuarant(this RestuarantDocument doc)
    {
        return new Restuarant()
        {
            Id = doc.Id,
            Name = doc.Name,
            CuisineType = doc.CuisineType,
            Website = doc.Website is null ? null : new Uri(doc.Website),
            Phone = doc.Phone,
            Address = doc.Address.ToLocation(),
        };
    }

    internal static Location ToLocation(this LocationDocument doc)
    {
        return new Location()
        {
            Street = doc.Street,
            City = doc.City,
            State = doc.State,
            Country = doc.Country,
            ZipCode = doc.ZipCode
        };
    }

    internal static RestuarantDocument ToRestuarantDocument(this Restuarant model)
    {
        return new RestuarantDocument()
        {
            Id = model.Id,
            Name = model.Name,
            CuisineType = model.CuisineType,
            Website = model.Website?.ToString(),
            Phone = model.Phone,
            Address = model.Address.ToLocationDocument(),
        };
    }

    internal static LocationDocument ToLocationDocument(this Location model)
    {
        return new LocationDocument()
        {
            Street = model.Street,
            City = model.City,
            State = model.State,
            Country = model.Country,
            ZipCode = model.ZipCode
        };
    }
}
