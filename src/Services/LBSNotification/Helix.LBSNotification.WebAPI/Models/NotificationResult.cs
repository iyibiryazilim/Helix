using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Helix.LBSNotification.WebAPI.Models;

public class NotificationResult
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;
    public Guid? Owner { get; set; } 
    public string? Content { get; set; }=string.Empty; 
    public DateTime CreatedOn { get; set; } = DateTime.Now;
}
