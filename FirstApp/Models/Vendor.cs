using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FirstApp.Models
{
    [BsonIgnoreExtraElements]
    public class Vendor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;
        [BsonElement("approvalStatus")]
        public bool ApprovalStatus { get; set; } = false;
        [BsonElement("companyId")]
        public string CompanyId { get; set; } = string.Empty;
        [BsonElement("email")]
        public string Email { get; set; } = string.Empty;
        [BsonElement("phone")]
        public string Phone { get; set; } = string.Empty;
        [BsonElement("userName")]
        public string UserName { get; set; } = string.Empty;
        [BsonElement("password")]
        public string Password { get; set; } = string.Empty;
        [BsonElement("address")]
        public string Address { get; set; } = string.Empty;
        [BsonElement("changeCompany")]
        public bool ChangeCompany { get; set; } = false;
    }
}
