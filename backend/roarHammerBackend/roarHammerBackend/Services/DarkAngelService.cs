using MongoDB.Driver;
using roarHammerBackend.Models;
using Microsoft.Extensions.Options;

namespace roarHammerBackend.Services;

public class DarkAngelService
{
    private readonly IMongoCollection<DarkAngel> _darkAngelsCollection;

    public DarkAngelService(IOptions<MongoDbSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        var database = client.GetDatabase(settings.Value.DatabaseName);
        _darkAngelsCollection = database.GetCollection<DarkAngel>("dark-angels");
    }

    public async Task<List<DarkAngel>> GetAsync()
    {
        return await _darkAngelsCollection.Find(_ => true).ToListAsync();
    }

    public async Task CreateAsync(DarkAngel newDarkAngel)
    {
        await _darkAngelsCollection.InsertOneAsync(newDarkAngel);
    }
}