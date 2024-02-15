using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Drivers.Api.Models;

public class Drive
{
    [BsonId] //Obtener el ID auto-generado por MongoDB
    [BsonRepresentation(BsonType.ObjectId)]

    public string id {get; set;} = string.Empty;

    
    [BsonElement("Name")]
    public string Name {get;set;} = string.Empty;
    
    [BsonElement("Number")]
    public int Number {get;set;}

    [BsonElement("Team")]
    public string Team {get;set;} = string.Empty;
    

}