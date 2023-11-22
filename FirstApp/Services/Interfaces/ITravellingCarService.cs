using FirstApp.Models;

namespace FirstApp.Services.Interfaces
{
    public interface ITravellingCarService
    {
        List<TravellingCar> GetTravellingCarsByCompany(string cid);
        List<TravellingCar> GetTravellingCarsByVendor(string vid);
        TravellingCar Create(TravellingCar travellingCar);
        void Remove(string id);
    }
}
