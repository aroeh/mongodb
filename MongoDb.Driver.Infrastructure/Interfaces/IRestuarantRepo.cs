using MongoDb.Driver.Shared.Models;

namespace MongoDb.Driver.Infrastructure.Interfaces;

public interface IRestuarantRepo
{
    /// <summary>
    /// Query restuarants
    /// </summary>
    /// <param name="queryParameters">Optional - Query parameters to filter restuarants</param>
    /// <returns>Collection of available restuarant records.  Returns empty list if there are no records found matching criteria</returns>
    Task<List<Restuarant>> QueryRestuarants(FilterQueryParameters queryParameters);

    /// <summary>
    /// Get restuarant by id
    /// </summary>
    /// <param name="id">Id of the restuarant</param>
    /// <returns>Restuarant if not <see langword="null"/></returns>
    Task<Restuarant?> GetRestuarant(string id);

    /// <summary>
    /// Creates a new Restuarant
    /// </summary>
    /// <param name="restuarant">Restuarant properties and data</param>
    /// <returns>Restuarant object updated with the new id</returns>
    Task<Restuarant> CreateRestuarant(Restuarant restuarant);

    /// <summary>
    /// Create many new Restuarants
    /// </summary>
    /// <param name="restuarants">Collection of new restuarants</param>
    /// <returns>MongoDb results for the transaction</returns>
    Task<MongoTransactionResult> CreateManyRestuarants(Restuarant[] restuarants);

    /// <summary>
    /// Update an existing restuarant
    /// </summary>
    /// <param name="id">Id of the restuarant</param>
    /// <param name="request">Restuarant properties to update</param>
    /// <returns>MongoDb results for the transaction</returns>
    Task<MongoTransactionResult> UpdateRestuarant(string id, UpdateRestuarantRequest request);
}
