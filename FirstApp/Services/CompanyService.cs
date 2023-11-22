using FirstApp.Models;
using FirstApp.Services.Interfaces;
using MongoDB.Driver;

namespace FirstApp.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IMongoCollection<Company> _companies;

        public CompanyService(IAppStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _companies = database.GetCollection<Company>(settings.CompaniesCollectionName);
        }
        public Company Create(Company company)
        {
            _companies.InsertOne(company);
            return company;
        }

        public Company GetByUsername(string username)
        {
            return _companies.Find(company => company.UserName == username).FirstOrDefault();
        }

        public Company Signin(Company user)
        {
            return _companies.Find(company => company.UserName == user.UserName && company.Password == user.Password).FirstOrDefault();

        }


        public List<Company> Get()
        {
            return _companies.Find(company => true).ToList();
        }

        public List<Company> GetApproved()
        {
            return _companies.Find(company => company.ApprovalStatus == true).ToList();
        }

        public List<Company> GetApprovalPending()
        {
            return _companies.Find(company => company.ApprovalStatus != true).ToList();
        }

        public List<Company> GetUnassigned()
        {
            return _companies.Find(company =>(company.ApprovalStatus == true) && (company.VendorId == string.Empty)).ToList();
        }

        

        public Company Get(string id)
        {
            return _companies.Find(company => company.Id == id).FirstOrDefault();

        }

        public void Remove(string id)
        {
            _companies.DeleteOne(company => company.Id == id);

        }

        public void Update(string id, Company company)
        {
            _companies.ReplaceOne(company => company.Id == id, company);

        }
    }
}
