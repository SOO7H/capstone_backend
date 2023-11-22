using FirstApp.Models;
using FirstApp.Services.Interfaces;
using MongoDB.Driver;
using System.Numerics;

namespace FirstApp.Services
{
    public class VendorService : IVendorService
    {
        private readonly IMongoCollection<Vendor> _vendors;

        public VendorService(IAppStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _vendors = database.GetCollection<Vendor>(settings.VendorsCollectionName);
        }
        public Vendor Create(Vendor vendor)
        {
            _vendors.InsertOne(vendor);
            return vendor;
        }

        public Vendor GetByUsername(string username)
        {
            return _vendors.Find(venodr => venodr.UserName == username).FirstOrDefault();
        }
        public Vendor Signin(Vendor user)
        {
            return _vendors.Find(vendor => vendor.UserName == user.UserName && vendor.Password == user.Password).FirstOrDefault();

        }
        public List<Vendor> Get()
        {
            return _vendors.Find(vendor => true).ToList();
        }

        public List<Vendor> GetApproved()
        {
            return _vendors.Find(vendor => vendor.ApprovalStatus == true).ToList();
        }

        public List<Vendor> GetApprovalPending()
        {
            return _vendors.Find(vendor => vendor.ApprovalStatus != true).ToList();
        }

        public List<Vendor> GetUnassigned()
        {
            return _vendors.Find(vendor => (vendor.ApprovalStatus == true) && (vendor.CompanyId == string.Empty)).ToList();
        }
        public Vendor Get(string id)
        {
            return _vendors.Find(vendor => vendor.Id == id).FirstOrDefault();

        }

        public void Remove(string id)
        {
            _vendors.DeleteOne(vendor => vendor.Id == id);

        }

        public void Update(string id, Vendor vendor)
        {
            _vendors.ReplaceOne(vendor => vendor.Id == id, vendor);

        }
    }
}
