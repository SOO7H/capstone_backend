using FirstApp.Models;
using FirstApp.Services.Interfaces;
using MongoDB.Driver;

namespace FirstApp.Services
{
    public class CarService : ICarService
    {
        private readonly IMongoCollection<Car> _cars;

        public CarService(IAppStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _cars = database.GetCollection<Car>(settings.CarsCollectionName);
        }
        public Car Create(Car car)
        {
            _cars.InsertOne(car);
            return car;
        }

        public List<Car> GetByVendor(string vid)
        {
            return _cars.Find(car => car.VendorId == vid).ToList();
        }

        public List<Car> GetAvailable()
        {
            return _cars.Find(car => car.Availability == true ).ToList();
        }

        public Car Get(string id)
        {
            return _cars.Find(car => car.Id == id).FirstOrDefault();
        }


        public void Remove(string id)
        {
            _cars.DeleteOne(car => car.Id == id);

        }

        public void Update(string id, Car car)
        {
            _cars.ReplaceOne(car => car.Id == id, car);

        }
    }
}
