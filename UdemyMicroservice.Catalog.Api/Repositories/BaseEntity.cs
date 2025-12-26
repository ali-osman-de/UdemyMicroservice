using MongoDB.Bson.Serialization.Attributes;

namespace UdemyMicroservice.Catalog.Api.Repositories;

public class BaseEntity
{
    [BsonElement("_id")]
    public Guid Id { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
}
