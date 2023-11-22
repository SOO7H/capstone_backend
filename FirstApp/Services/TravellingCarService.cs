using FirstApp.Models;
using FirstApp.Services.Interfaces;
using MongoDB.Driver;
using System.Security.Cryptography;

namespace FirstApp.Services
{
    public class TravellingCarService : ITravellingCarService
    {
        private readonly IMongoCollection<TravellingCar> _travellingCars;

        public TravellingCarService(IAppStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _travellingCars = database.GetCollection<TravellingCar>(settings.TravellingCarsCollectionName);
        }
        public TravellingCar Create(TravellingCar travellingCar)
        {
            _travellingCars.InsertOne(travellingCar);
            return travellingCar;
        }

        public List<TravellingCar> GetTravellingCarsByCompany(string cid)
        {
            return _travellingCars.Find(travellingCar => travellingCar.CompanyId == cid).ToList();
        }

        public List<TravellingCar> GetTravellingCarsByVendor(string vid)
        {
            return _travellingCars.Find(travellingCar => travellingCar.VendorId == vid).ToList();
        }

        public void Remove(string id)
        {
            _travellingCars.DeleteOne(travellingCar => travellingCar.Id == id);
        }
    }
}
