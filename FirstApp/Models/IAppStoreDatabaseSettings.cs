namespace FirstApp.Models
{
    public interface IAppStoreDatabaseSettings
    {
        string CompaniesCollectionName { get; set; }
        string EmployeesCollectionName { get; set; }
        string VendorsCollectionName { get; set; }
        string AdminsCollectionName { get; set; }
        string CarsCollectionName { get; set; }
        string TravellingCarsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }

    }
}
