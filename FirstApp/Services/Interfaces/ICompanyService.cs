using FirstApp.Models;

namespace FirstApp.Services.Interfaces
{
    public interface ICompanyService
    {
        List<Company> Get();
        List<Company> GetApproved();
        Company GetByUsername(string username);
        List<Company> GetApprovalPending();
        List<Company> GetUnassigned();
        Company Get(string id);
        Company Create(Company company);
        Company Signin(Company user);
        void Update(string id, Company company);
        void Remove(string id);
    }
}
