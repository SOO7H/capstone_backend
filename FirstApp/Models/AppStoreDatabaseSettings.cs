namespace FirstApp.Models
{
    public class AppStoreDatabaseSettings : IAppStoreDatabaseSettings
    {
        public string EmployeesCollectionName { get; set; } = string.Empty;
        public string CompaniesCollectionName { get; set; } = string.Empty;
        public string VendorsCollectionName { get; set; } = string.Empty;
        public string AdminsCollectionName { get; set; } = string.Empty;
        public string CarsCollectionName { get; set; } = string.Empty;
        public string TravellingCarsCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }   
}
