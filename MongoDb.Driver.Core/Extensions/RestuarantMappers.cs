using MongoDb.Driver.Shared.Models;

namespace MongoDb.Driver.Core.Extensions;

internal static class RestuarantMappers
{
    internal static Restuarant MapToRestuarant(this CreateRestuarantRequest request, string id)
    {
        return new Restuarant()
        {
            Id = id,
            Name = request.Name,
            CuisineType = request.CuisineType,
            Website = request.Website,
            Phone = request.Phone,
            Address = request.Address.MapToLocation()
        };
    }

    internal static Location MapToLocation(this CreateLocationRequest request)
    {
        return new Location()
        {
            Street = request.Street,
            City = request.City,
            State = request.State,
            Country = request.Country,
            ZipCode = request.ZipCode
        };
    }
}
