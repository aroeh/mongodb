using Microsoft.Extensions.Logging;
using MongoDb.Driver.Core.Extensions;
using MongoDb.Driver.Infrastructure.Interfaces;
using MongoDb.Driver.Shared.Models;
using MongoDb.Driver.Shared.Utils;

namespace MongoDb.Driver.Core.Orchestrations;

public class RestuarantOrchestration(ILogger<RestuarantOrchestration> log, IRestuarantRepo repo) : IRestuarantOrchestration
{
    private readonly ILogger<RestuarantOrchestration> _logger = log;
    private readonly IRestuarantRepo _repo = repo;

    /// <summary>
    /// List restuarants
    /// </summary>
    /// <param name="queryParameters">Optional - Query parameters to filter restuarants</param>
    /// <returns>List of restuarants matching <paramref name="queryParameters"/></returns>
    public async Task<List<Restuarant>> ListRestuarants(FilterQueryParameters queryParameters)
    {
        _logger.LogInformation("Querying restuarants");
        return await _repo.QueryRestuarants(queryParameters);
    }

    /// <summary>
    /// Get restuarant by id
    /// </summary>
    /// <param name="id">Id of the restuarant</param>
    /// <returns>Restuarant if not <see langword="null"/></returns>
    public async Task<Restuarant?> GetRestuarant(string id)
    {
        _logger.LogInformation("Getting restuarant by id");
        return await _repo.GetRestuarant(id);
    }

    /// <summary>
    /// Creates a new Restuarant
    /// </summary>
    /// <param name="request">Restuarant properties and data</param>
    /// <returns>Restuarant object updated with the new id</returns>
    public async Task<Restuarant> CreateRestuarant(CreateRestuarantRequest request)
    {
        _logger.LogInformation("Adding new restuarant");
        string newId = IdGenerator.GenerateId();
        Restuarant restuarant = request.MapToRestuarant(newId);

        return await _repo.CreateRestuarant(restuarant);
    }

    /// <summary>
    /// Create many new Restuarants
    /// </summary>
    /// <param name="requests">Collection of create restuarant requests</param>
    /// <returns>MongoDb results for the transaction</returns>
    public async Task<MongoTransactionResult> CreateManyRestuarants(CreateRestuarantRequest[] requests)
    {
        Restuarant[] requestCollection = new Restuarant[requests.Length];
        for (int i = 0; i < requests.Length; i++)
        {
            string newId = IdGenerator.GenerateId();
            Restuarant newItem = requests[i].MapToRestuarant(newId);
            requestCollection[i] = newItem;
        }

        _logger.LogInformation("Adding new restuarant");
        return await _repo.CreateManyRestuarants(requestCollection);
    }

    /// <summary>
    /// Updates a Restuarant record
    /// </summary>
    /// <param name="id">Id of the restuarant</param>
    /// <param name="request">Restuarant properties to update</param>
    /// <returns>Success result</returns>
    public async Task<bool> UpdateRestuarant(string id, UpdateRestuarantRequest request)
    {
        _ = await GetRestuarant(id) ?? throw new Exception("Restuarant does not exist.  Unable to update.");

        _logger.LogInformation("Updating restuarant");
        MongoTransactionResult result = await _repo.UpdateRestuarant(id, request);
        return result.Success;
    }
}
