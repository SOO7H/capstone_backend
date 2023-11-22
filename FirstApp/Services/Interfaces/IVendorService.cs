using FirstApp.Models;

namespace FirstApp.Services.Interfaces
{
    public interface IVendorService
    {
        List<Vendor> Get();
        List<Vendor> GetApproved();
        List<Vendor> GetApprovalPending();
        List<Vendor> GetUnassigned();
        Vendor GetByUsername(string username);
        Vendor Get(string id);
        Vendor Signin(Vendor user);
        Vendor Create(Vendor vendor);
        void Update(string id, Vendor vendor);
        void Remove(string id);
    }
}
