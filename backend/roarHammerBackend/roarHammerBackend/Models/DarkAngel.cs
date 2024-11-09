using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace roarHammerBackend.Models;

public class DarkAngel
{
    [BsonId] // This attribute tells MongoDB to map the field to the _id field.
    [BsonRepresentation(BsonType.ObjectId)] // This ensures that MongoDB treats this property as an ObjectId.
    public string Id { get; set; }

    [BsonElement("name")] // Optional: this explicitly maps to a field called "name" in MongoDB
    public string name { get; set; }

    [BsonElement("points")]
    public int points { get; set; }

    [BsonElement("keywords")]
    public List<string> keywords { get; set; }
}