using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FirstApp.Models
{
    public class TravellingCar
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        [BsonElement("companyId")]
        public string CompanyId { get; set; } = string.Empty;
        [BsonElement("vendorId")]
        public string VendorId { get; set; } = string.Empty;
        [BsonElement("carId")]
        public string CarId { get; set; } = string.Empty;
        [BsonElement("employeeId")]
        public string EmployeeId { get; set; } = string.Empty;
        [BsonElement("pickupAddress")]
        public string PickupAddress { get; set; } = string.Empty;
        [BsonElement("dropoffAddress")]
        public string DropoffAddress { get; set; } = string.Empty;
        [BsonElement("pLat")]
        public float PLat { get; set; }
        [BsonElement("pLong")]
        public float PLong { get; set; }
        [BsonElement("dLat")]
        public float DLat { get; set; }
        [BsonElement("dLong")]
        public float DLong { get; set; }
    }
}
