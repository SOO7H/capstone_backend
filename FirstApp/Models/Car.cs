using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FirstApp.Models
{
    public class Car
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        [BsonElement("registrationNo")]
        public string RegistrationNo { get; set; } = string.Empty;
        [BsonElement("lat")]
        public double Lat { get; set; } = 17.453746;
        [BsonElement("long")]
        public double Long { get; set; } = 78.393561;
        [BsonElement("vendorId")]
        public string? VendorId { get; set; } = string.Empty;
        [BsonElement("employeeId")]
        public string? EmployeeId { get; set; } = string.Empty;
        [BsonElement("address")]
        public string Address { get; set;} = string.Empty;
        [BsonElement("availability")]
        public bool Availability { get; set; } = true;
    }
}
