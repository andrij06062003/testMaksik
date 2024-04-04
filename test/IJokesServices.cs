
using test.Models;

namespace test;

public interface IJokesServices
{
    public Task<List<Jokes>> JokesListAsync();
    public Task<Jokes> GetProductDetailByIdAsync(string jokesId);
    public Task AddJokesAsync(Jokes jokes);
    public Task DeleteJokesAsync(string jokesId);
    public Task ReplaceJikesAsync(string jokesId, Jokes jokes);
}