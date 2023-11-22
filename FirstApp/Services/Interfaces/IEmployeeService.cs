using FirstApp.Models;

namespace FirstApp.Services.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> GetByCompany(string cid);
        Employee Get(string id);
        Employee GetByUsername(string username);
        Employee Create(Employee employee);
        Employee Signin(Employee user);
        void Update(string id, Employee employee);
        void Remove(string id);
    }
}
