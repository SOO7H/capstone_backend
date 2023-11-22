using FirstApp.Models;
using FirstApp.Services.Interfaces;
using MongoDB.Driver;

namespace FirstApp.Services
{
    public class AdminService : IAdminService
    {
        private readonly IMongoCollection<Admin> _admins;

        public AdminService(IAppStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _admins = database.GetCollection<Admin>(settings.AdminsCollectionName);
        }

        public Admin GetByUsername(string username) 
        { 
            return _admins.Find(admin => admin.UserName == username).FirstOrDefault();
        }
        public Admin Signin(Admin user)
        {
            return _admins.Find(admin => admin.UserName == user.UserName && admin.Password == user.Password).FirstOrDefault();

        }
        public Admin Get(string id)
        {
            return _admins.Find(admin => admin.Id == id).FirstOrDefault();
        }
        public Admin Create(Admin admin) 
        {
            _admins.InsertOne(admin);
            return admin;
        }
    }
}
