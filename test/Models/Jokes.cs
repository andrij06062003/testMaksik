using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace test.Models;

public class Jokes
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    
    [BsonElement("description")]
    public string Description { get; set; }
    
    [BsonElement("rate")]
    public int Rate { get; set; }
}