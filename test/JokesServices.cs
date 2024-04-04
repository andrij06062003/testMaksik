using Microsoft.Extensions.Options;
using MongoDB.Driver;
using test.Models;

namespace test;

public class JokesServices : IJokesServices
{
    private readonly IMongoCollection<Jokes> _jokesCollection;

    public JokesServices(IOptions<JokesDbSettings> jokesDatabaseSettings)
    {
        var mongoClient = new MongoClient(jokesDatabaseSettings.Value.ConnectionString);
        var mongoDataBase =  mongoClient.GetDatabase(jokesDatabaseSettings.Value.DatabaseName);
        _jokesCollection = mongoDataBase.GetCollection<Jokes>(jokesDatabaseSettings.Value.CollectionName);
    }
    
    
    
    public async Task<List<Jokes>> JokesListAsync()
    {
        return await _jokesCollection.Find(_ => true).ToListAsync();
    }

    public async Task<Jokes> GetProductDetailByIdAsync(string jokesId)
    {
        return await _jokesCollection.Find(x => x.Id ==jokesId).FirstOrDefaultAsync();
    }

    public async Task AddJokesAsync(Jokes jokes)
    { 
        await _jokesCollection.InsertOneAsync(jokes);
    }

    public async Task DeleteJokesAsync(string jokesId)
    {
        await _jokesCollection.DeleteOneAsync(x=>x.Id ==jokesId);
    }

    public async Task ReplaceJikesAsync(string jokesId, Jokes jokes)
    {
        await _jokesCollection.ReplaceOneAsync(x => x.Id == jokesId, jokes);
    }
}