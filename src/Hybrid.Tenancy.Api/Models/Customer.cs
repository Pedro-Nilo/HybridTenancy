using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Hybrid.Tenancy.Api.Models;

public class Customer
{
    [BsonElement("_id")]
    public string Id { get; protected set; } = ObjectId.GenerateNewId().ToString();

    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("national_insurance_number")]
    public string Nin { get; set; }

    [BsonElement("created_at")]
    public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
}
