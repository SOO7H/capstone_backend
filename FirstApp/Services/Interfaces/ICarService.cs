using FirstApp.Models;

namespace FirstApp.Services.Interfaces
{
    public interface ICarService
    {
        List<Car> GetByVendor(string vid);
        Car Get(string id);
        Car Create(Car car);
        List<Car> GetAvailable();
        void Update(string id, Car car);
        void Remove(string id);
    }
}
