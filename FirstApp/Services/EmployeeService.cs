using FirstApp.Models;
using FirstApp.Services.Interfaces;
using MongoDB.Driver;

namespace FirstApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMongoCollection<Employee> _employees;

        public EmployeeService(IAppStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _employees = database.GetCollection<Employee>(settings.EmployeesCollectionName);
        }
        public Employee Create(Employee employee)
        {
            _employees.InsertOne(employee);
            return employee;
        }
        public Employee Signin(Employee user)
        {
            return _employees.Find(employee => employee.UserName == user.UserName && employee.Password == user.Password && employee.CompanyId == user.CompanyId).FirstOrDefault();

        }
        public Employee GetByUsername(string username)
        {
            return _employees.Find(employee => employee.UserName == username).FirstOrDefault();
        }
        public List<Employee> GetByCompany(string cid)
        {
            return _employees.Find(employee => employee.CompanyId == cid).ToList();
        }

        public Employee Get(string id)
        {
            return _employees.Find(employee => employee.Id == id).FirstOrDefault();
        }


        public void Remove(string id)
        {
            _employees.DeleteOne(employee => employee.Id == id);

        }

        public void Update(string id, Employee employee)
        {
            _employees.ReplaceOne(employee => employee.Id == id, employee);

        }
    }
}
