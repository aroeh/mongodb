using MongoDB.Bson;

namespace MongoDb.Driver.Shared.Utils;

public static class IdGenerator
{
    public static string GenerateId()
    {
        ObjectId newId = ObjectId.GenerateNewId();
        return newId.ToString();
    }
}
